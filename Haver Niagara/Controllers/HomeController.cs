using Haver_Niagara.Data;
using Haver_Niagara.Models;
using Haver_Niagara.Utilities;
using IronPdf.Extensions.Mvc.Core; //for pdf generator
using IronPdf.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Mvc.Html;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;


namespace Haver_Niagara.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HaverNiagaraDbContext _context; // allows for db access

        //for pdf converter
        private readonly IRazorViewRenderer _viewRenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // CONSTRUCTOR //
        public HomeController(ILogger<HomeController> logger, HaverNiagaraDbContext context, IRazorViewRenderer viewRenderService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _context = context;
            //for pdf converter
            _viewRenderService = viewRenderService;
            _httpContextAccessor = httpContextAccessor;
        }

        // MAIN NCR LOG //
        public IActionResult List(string sortOrder, string searchString, string selectedSupplier, string selectedDate, bool? selectedStatus, int? page, string currentFilter, NCRStage? ncrStage)
        {
            ViewBag.FormattedIDSortParam = sortOrder == "FormattedID_Asc" ? "FormattedID_Desc" : "FormattedID_Asc";
            ViewBag.NCRStageSortParam = sortOrder == "NCRStage_Asc" ? "NCRStage_Desc" : "NCRStage_Asc";
            // Sorting Functionality
            ViewBag.POSortParam = sortOrder == "ProductNum_Asc" ? "ProductNum_Desc" : "ProductNum_Asc";
            ViewBag.SupplierSortParam = sortOrder == "Supplier_Asc" ? "Supplier_Desc" : "Supplier_Asc";
            ViewBag.StageSortParam = sortOrder == "Stage_Asc" ? "Stage_Desc" : "Stage_Asc";
            ViewBag.DateSortParam = sortOrder == "Date_Asc" ? "Date_Desc" : "Date_Asc";
            ViewBag.CurrentFilter = currentFilter;
            ViewBag.SelectedSupplier = selectedSupplier;
            ViewBag.SelectedDate = selectedDate;
            ViewBag.SelectedStatus = selectedStatus;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var originalNCRs = _context.NCRs
                .Where(p => p.IsArchived == false & p.IsVoid == false)
                .Include(p => p.Part)
                .ThenInclude(s => s.Supplier)
                .Include(p => p.Part.DefectLists)
                .ThenInclude(d => d.Defect)
                .ToList();

            //Since 

            var ncrs = _context.NCRs
                .Where(p => p.IsArchived == false & p.IsVoid == false)
                .Include(p => p.Part)
                .ThenInclude(s => s.Supplier)
                .Include(p => p.Part.DefectLists)
                .ThenInclude(d => d.Defect)
                .AsQueryable();

            //depending on stage, filter list by stage of department and completed stage
            if (User.IsInRole("Engineer"))
            {
                ncrs = ncrs.Where(n => n.NCR_Stage == (NCRStage)1 || n.NCR_Stage == (NCRStage)5); //engineering stage
            }
            if (User.IsInRole("Operations"))
            {
                ncrs = ncrs.Where(n => n.NCR_Stage == (NCRStage)2 || n.NCR_Stage == (NCRStage)5); //operations stage
            }
            if (User.IsInRole("Procurement"))
            {
                ncrs = ncrs.Where(n => n.NCR_Stage == (NCRStage)3 || n.NCR_Stage == (NCRStage)5); //procurement stage
            }
            if (User.IsInRole("Quality Representative"))
            {
                ncrs = ncrs.Where(n => n.NCR_Stage == (NCRStage)4 || n.NCR_Stage == (NCRStage)5); //quality stage
            }

            // Apply filters
            if (!String.IsNullOrEmpty(selectedSupplier) && selectedSupplier != "Select Supplier")
            {
                var selectedSupplierID = _context.Suppliers //Retrieves the selected ID based on the name
                    .Where(s => s.Name == selectedSupplier)
                    .Select(s => s.ID)
                    .FirstOrDefault();
                //Use NCRSupplierID instead of Part.Name
                ncrs = ncrs.Where(x => x.NCRSupplierID == selectedSupplierID);
            }

            if (!selectedStatus.HasValue)
            {
                ncrs = ncrs.Where(x => x.NCR_Status == true);
            }
            else if (selectedStatus.HasValue)
            {
                ncrs = ncrs.Where(x => x.NCR_Status == selectedStatus.Value);
            }
            ViewBag.SelectedStatus = selectedStatus;

            // Apply NCRStage filter if selected
            if (ncrStage.HasValue)
            {
                ncrs = ncrs.Where(x => x.NCR_Stage == ncrStage.Value);
            }

            if (!selectedStatus.HasValue)
            {
                ncrs = ncrs.Where(x => x.IsVoid == false); //archive list shows closed ncr's on default
            }
            // Search Box
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                var parts = searchString.Split('-');

                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out int yearPart) && int.TryParse(parts[1], out int indexPart))
                    {
                        // This gets all NCRs from the specified year, orders them by ID, and then picks the one matching the index
                        var filteredNcrs = _context.NCRs
                            .Where(x => x.NCR_Date.Year == yearPart)
                            .OrderBy(x => x.ID)
                            .ToList(); // ToList to execute and use indexing

                        if (indexPart <= filteredNcrs.Count)
                        {
                            // Adjust index to zero-based by subtracting 1
                            var targetNcr = filteredNcrs.ElementAt(indexPart - 1);
                            ncrs = ncrs.Where(x => x.ID == targetNcr.ID);
                        }
                    }
                }
                else
                {
                    // Generic search for other fields if not in "YYYY-NNN" format
                    ncrs = ncrs.Where(x =>
                        x.NCR_Date.ToString().ToLower().Contains(searchString) ||
                        x.Part.ProductNumber.ToString().ToLower().Contains(searchString) ||
                        x.ID.ToString().ToLower().Contains(searchString) ||
                        x.Part.Supplier.Name.ToLower().Contains(searchString));
                }

            }

            // Filter by Date
            if (!String.IsNullOrEmpty(selectedDate))
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(selectedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    ncrs = ncrs.Where(x => x.NCR_Date.Date == parsedDate.Date);
                }
            }

            // Sorting
            IOrderedQueryable<NCR> sortedNCRs;
            switch (sortOrder)
            {
                case "FormattedID_Asc":
                    sortedNCRs = ncrs.OrderBy(x => x.NCR_Date.Year).ThenBy(x => x.ID);
                    break;
                case "FormattedID_Desc":
                    sortedNCRs = ncrs.OrderByDescending(x => x.NCR_Date.Year).ThenByDescending(x => x.ID);
                    break;
                case "NCRStage_Asc":
                    sortedNCRs = ncrs.OrderBy(x => x.NCR_Stage);
                    break;
                case "NCRStage_Desc":
                    sortedNCRs = ncrs.OrderByDescending(x => x.NCR_Stage);
                    break;
                // Existing sort cases
                case "ProductNum_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.Part.ProductNumber);
                    break;
                case "ProductNum_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.Part.ProductNumber);
                    break;
                case "Supplier_Desc":
                    sortedNCRs = ncrs.OrderByDescending(s => s.Part.Supplier.Name);
                    break;
                case "Supplier_Asc":
                    sortedNCRs = ncrs.OrderBy(n => n.Part.Supplier.Name);
                    break;
                case "Stage_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.NCR_Status);
                    break;
                case "Stage_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.NCR_Status);
                    break;
                case "Date_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.NCR_Date);
                    break;
                case "Date_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.NCR_Date);
                    break;
                default:
                    sortedNCRs = ncrs.OrderBy(b => b.ID);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var pagedNCRs = sortedNCRs.ToPagedList(pageNumber, pageSize);

            // Create a separate list for dropdown options
            var suppliersForDropdown = originalNCRs
                .Where(x => x.Part != null && x.Part.Supplier != null)
                .Select(x => x.Part.Supplier.Name)
                .Distinct()
                .OrderBy(name => name) 
                .ToList();

            // Update the ViewBag.SupplierList with the dropdown options
            ViewBag.SupplierList = new SelectList(suppliersForDropdown, selectedSupplier);

            // Get all unique suppliers for the dropdown list
            var allSuppliers = originalNCRs
                .Where(x => x.Part != null && x.Part.Supplier != null && x.Part.Supplier.Name != null)
                .Select(x => x.Part.Supplier.Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            ViewBag.SupplierList = new SelectList(allSuppliers, selectedSupplier);

            // Dropdown for NCRStages with specific stages and their display names
            var stagesToInclude = new[]
            {
                NCRStage.Engineering,
                NCRStage.Operations,
                NCRStage.Procurement,
                NCRStage.QualityRepresentative_Final
            };
            ViewBag.NCRStageList = ToSelectList(stagesToInclude);

            return View(pagedNCRs);
        }

        // ARCHIVED NCR LOG //
        public IActionResult ListArchive(string sortOrder, string searchString, string selectedSupplier, string selectedDate, bool? selectedStatus, int? page, string currentFilter, NCRStage? ncrStage)
        {
            ViewBag.FormattedIDSortParam = sortOrder == "FormattedID_Asc" ? "FormattedID_Desc" : "FormattedID_Asc";
            ViewBag.NCRStageSortParam = sortOrder == "NCRStage_Asc" ? "NCRStage_Desc" : "NCRStage_Asc";
            // Sorting Functionality
            ViewBag.POSortParam = sortOrder == "ProductNum_Asc" ? "ProductNum_Desc" : "ProductNum_Asc";
            ViewBag.SupplierSortParam = sortOrder == "Supplier_Asc" ? "Supplier_Desc" : "Supplier_Asc";
            ViewBag.StageSortParam = sortOrder == "Stage_Asc" ? "Stage_Desc" : "Stage_Asc";
            ViewBag.DateSortParam = sortOrder == "Date_Asc" ? "Date_Desc" : "Date_Asc";
            ViewBag.CurrentFilter = currentFilter;
            ViewBag.SelectedSupplier = selectedSupplier;
            ViewBag.SelectedDate = selectedDate;
            ViewBag.SelectedStatus = selectedStatus;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var originalNCRs = _context.NCRs
                .Where(p => p.IsArchived == true)
                .Include(p => p.Supplier)
                .Include(p => p.Part)
                .ThenInclude(s => s.Supplier)
                .Include(p => p.Part.DefectLists)
                .ThenInclude(d => d.Defect)
                .ToList();

            var ncrs = _context.NCRs
                .Where(p => p.IsArchived == true)
                .Include(p => p.Supplier)
                .Include(p => p.Part)
                .ThenInclude(s => s.Supplier)
                .Include(p => p.Part.DefectLists)
                .ThenInclude(d => d.Defect)
                .AsQueryable();

            // Apply filters
            if (!String.IsNullOrEmpty(selectedSupplier) && selectedSupplier != "Select Supplier")
            {
                var selectedSupplierID = _context.Suppliers //Retrieves the selected ID based on the name
                 .Where(s => s.Name == selectedSupplier)
                 .Select(s => s.ID)
                 .FirstOrDefault();
                //Use NCRSupplierID instead of Part.Name
                ncrs = ncrs.Where(x => x.NCRSupplierID == selectedSupplierID);
            }

            if (!selectedStatus.HasValue)
            {
                ncrs = ncrs.Where(x => x.NCR_Status == false); //archive list shows closed ncr's on default
            }
            // Apply NCRStage filter if selected
            if (ncrStage.HasValue)
            {
                ncrs = ncrs.Where(x => x.NCR_Stage == ncrStage.Value);
            }

            // Search Box
            if (!String.IsNullOrEmpty(searchString))
            {
                // Split the searchString to potentially match the "YYYY-NNN" format
                searchString = searchString.ToLower();
                var parts = searchString.Split('-');
                int idPart;


                //If the length is exactly 0000-000 format
                if (searchString.Length == 8)
                {      //if it was successfuly split 
                    if (parts.Length == 2 && int.TryParse(parts[1], out idPart))
                    {
                        //Search by that ID + 20 (since we already have 20 existing seeded NCRs).
                        ncrs = ncrs.Where(x => x.ID == idPart + 20);
                    }
                }
                else if (searchString.Length == 3 || (searchString.Length == 4 && searchString.Contains("-")))
                {
                    //replace the hyphen is user searches like -010  //didnt do anything but i guess have it just in case idk
                    searchString = searchString.Replace("-", "");
                    //remove the leading 0 from the nnn  if it exists, add 20 and searchhhh
                    int.TryParse(searchString, out idPart);
                    searchString = (idPart + 20).ToString();
                }
                else
                {
                    ncrs = ncrs.Where(x =>
                        x.NCR_Date.ToString().ToLower().Contains(searchString) ||
                        x.Part.ProductNumber.ToString().ToLower().Contains(searchString) ||
                        x.ID.ToString().ToLower().Contains(searchString) ||
                        x.Part.Supplier.Name.ToLower().Contains(searchString));
                }

            }


            // Filter by Date
            if (!String.IsNullOrEmpty(selectedDate))
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(selectedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    ncrs = ncrs.Where(x => x.NCR_Date.Date == parsedDate.Date);
                }
            }

            // Sorting
            IOrderedQueryable<NCR> sortedNCRs;
            switch (sortOrder)
            {
                case "FormattedID_Asc":
                    sortedNCRs = ncrs.OrderBy(x => x.NCR_Date.Year).ThenBy(x => x.ID);
                    break;
                case "FormattedID_Desc":
                    sortedNCRs = ncrs.OrderByDescending(x => x.NCR_Date.Year).ThenByDescending(x => x.ID);
                    break;
                case "NCRStage_Asc":
                    sortedNCRs = ncrs.OrderBy(x => x.NCR_Stage);
                    break;
                case "NCRStage_Desc":
                    sortedNCRs = ncrs.OrderByDescending(x => x.NCR_Stage);
                    break;
                // Existing sort cases
                case "ProductNum_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.Part.ProductNumber);
                    break;
                case "ProductNum_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.Part.ProductNumber);
                    break;
                case "Supplier_Desc":
                    sortedNCRs = ncrs.OrderByDescending(s => s.Part.Supplier.Name);
                    break;
                case "Supplier_Asc":
                    sortedNCRs = ncrs.OrderBy(n => n.Part.Supplier.Name);
                    break;
                case "Stage_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.NCR_Status);
                    break;
                case "Stage_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.NCR_Status);
                    break;
                case "Date_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.NCR_Date);
                    break;
                case "Date_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.NCR_Date);
                    break;
                default:
                    sortedNCRs = ncrs.OrderBy(b => b.ID);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var pagedNCRs = sortedNCRs.ToPagedList(pageNumber, pageSize);

            // Create a separate list for dropdown options
            var suppliersForDropdown = originalNCRs
                .Where(x => x.Part != null && x.Part.Supplier != null)
                .Select(x => x.Part.Supplier.Name)
                .Distinct()
                .ToList();

            // Update the ViewBag.SupplierList with the dropdown options
            ViewBag.SupplierList = new SelectList(suppliersForDropdown, selectedSupplier);

            // Get all unique suppliers for the dropdown list
            var allSuppliers = originalNCRs
                .Where(x => x.Part != null && x.Part.Supplier != null && x.Part.Supplier.Name != null)
                .Select(x => x.Part.Supplier.Name)
                .Distinct()
                .ToList();

            ViewBag.SupplierList = new SelectList(allSuppliers, selectedSupplier);

            // Dropdown for NCRStages with specific stages and their display names
            var stagesToInclude = new[]
            {
                NCRStage.Engineering,
                NCRStage.Operations,
                NCRStage.Procurement,
                NCRStage.QualityRepresentative_Final
            };
            ViewBag.NCRStageList = ToSelectList(stagesToInclude);

            return View(pagedNCRs);
        }

        /// NCR VOIDED LOG 
        public IActionResult ListVoided(string sortOrder, string searchString, string selectedSupplier, string selectedDate, bool? selectedStatus, int? page, string currentFilter, NCRStage? ncrStage)
        {
            ViewBag.FormattedIDSortParam = sortOrder == "FormattedID_Asc" ? "FormattedID_Desc" : "FormattedID_Asc";
            ViewBag.NCRStageSortParam = sortOrder == "NCRStage_Asc" ? "NCRStage_Desc" : "NCRStage_Asc";
            // Sorting Functionality
            ViewBag.POSortParam = sortOrder == "ProductNum_Asc" ? "ProductNum_Desc" : "ProductNum_Asc";
            ViewBag.SupplierSortParam = sortOrder == "Supplier_Asc" ? "Supplier_Desc" : "Supplier_Asc";
            ViewBag.StageSortParam = sortOrder == "Stage_Asc" ? "Stage_Desc" : "Stage_Asc";
            ViewBag.DateSortParam = sortOrder == "Date_Asc" ? "Date_Desc" : "Date_Asc";
            ViewBag.CurrentFilter = currentFilter;
            ViewBag.SelectedSupplier = selectedSupplier;
            ViewBag.SelectedDate = selectedDate;
            ViewBag.SelectedStatus = selectedStatus;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var originalNCRs = _context.NCRs
                .Where(p => p.IsVoid == true)
                .Include(p => p.Supplier)
                .Include(p => p.Part)
                .ThenInclude(s => s.Supplier)
                .Include(p => p.Part.DefectLists)
                .ThenInclude(d => d.Defect)
                .ToList();

            var ncrs = _context.NCRs
                .Where(p => p.IsVoid == true)
                .Include(p => p.Supplier)
                .Include(p => p.Part)
                .ThenInclude(s => s.Supplier)
                .Include(p => p.Part.DefectLists)
                .ThenInclude(d => d.Defect)
                .AsQueryable();

            // Apply filters
            if (!String.IsNullOrEmpty(selectedSupplier) && selectedSupplier != "Select Supplier")
            {
                var selectedSupplierID = _context.Suppliers //Retrieves the selected ID based on the name
                 .Where(s => s.Name == selectedSupplier)
                 .Select(s => s.ID)
                 .FirstOrDefault();
                //Use NCRSupplierID instead of Part.Name
                ncrs = ncrs.Where(x => x.NCRSupplierID == selectedSupplierID);
            }

            if (!selectedStatus.HasValue)
            {
                ncrs = ncrs.Where(x => x.IsVoid == true); //void list shows voided NCRs
            }

            // Apply NCRStage filter if selected
            if (ncrStage.HasValue)
            {
                ncrs = ncrs.Where(x => x.NCR_Stage == ncrStage.Value);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                // Split the searchString to potentially match the "YYYY-NNN" format
                searchString = searchString.ToLower();
                var parts = searchString.Split('-');
                int idPart;


                //If the length is exactly 0000-000 format
                if (searchString.Length == 8)
                {      //if it was successfuly split 
                    if (parts.Length == 2 && int.TryParse(parts[1], out idPart))
                    {
                        //Search by that ID + 20 (since we already have 20 existing seeded NCRs).
                        ncrs = ncrs.Where(x => x.ID == idPart + 20);
                    }
                }
                else if (searchString.Length == 3 || (searchString.Length == 4 && searchString.Contains("-")))
                {
                    //replace the hyphen is user searches like -010  //didnt do anything but i guess have it just in case idk
                    searchString = searchString.Replace("-", "");
                    //remove the leading 0 from the nnn  if it exists, add 20 and searchhhh
                    int.TryParse(searchString, out idPart);
                    searchString = (idPart + 20).ToString();
                }
                else
                {
                    ncrs = ncrs.Where(x =>
                        x.NCR_Date.ToString().ToLower().Contains(searchString) ||
                        x.Part.ProductNumber.ToString().ToLower().Contains(searchString) ||
                        x.ID.ToString().ToLower().Contains(searchString) ||
                        x.Part.Supplier.Name.ToLower().Contains(searchString));
                }

            }


            // Filter by Date
            if (!String.IsNullOrEmpty(selectedDate))
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(selectedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    ncrs = ncrs.Where(x => x.NCR_Date.Date == parsedDate.Date);
                }
            }

            // Sorting
            IOrderedQueryable<NCR> sortedNCRs;
            switch (sortOrder)
            {
                case "FormattedID_Asc":
                    sortedNCRs = ncrs.OrderBy(x => x.NCR_Date.Year).ThenBy(x => x.ID);
                    break;
                case "FormattedID_Desc":
                    sortedNCRs = ncrs.OrderByDescending(x => x.NCR_Date.Year).ThenByDescending(x => x.ID);
                    break;
                case "NCRStage_Asc":
                    sortedNCRs = ncrs.OrderBy(x => x.NCR_Stage);
                    break;
                case "NCRStage_Desc":
                    sortedNCRs = ncrs.OrderByDescending(x => x.NCR_Stage);
                    break;
                // Existing sort cases
                case "ProductNum_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.Part.ProductNumber);
                    break;
                case "ProductNum_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.Part.ProductNumber);
                    break;
                case "Supplier_Desc":
                    sortedNCRs = ncrs.OrderByDescending(s => s.Part.Supplier.Name);
                    break;
                case "Supplier_Asc":
                    sortedNCRs = ncrs.OrderBy(n => n.Part.Supplier.Name);
                    break;
                case "Stage_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.NCR_Status);
                    break;
                case "Stage_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.NCR_Status);
                    break;
                case "Date_Asc":
                    sortedNCRs = ncrs.OrderBy(b => b.NCR_Date);
                    break;
                case "Date_Desc":
                    sortedNCRs = ncrs.OrderByDescending(b => b.NCR_Date);
                    break;
                default:
                    sortedNCRs = ncrs.OrderBy(b => b.ID);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var pagedNCRs = sortedNCRs.ToPagedList(pageNumber, pageSize);

            // Create a separate list for dropdown options
            var suppliersForDropdown = originalNCRs
                .Where(x => x.Part != null && x.Part.Supplier != null)
                .Select(x => x.Part.Supplier.Name)
                .Distinct()
                .ToList();

            // Update the ViewBag.SupplierList with the dropdown options
            ViewBag.SupplierList = new SelectList(suppliersForDropdown, selectedSupplier);

            // Get all unique suppliers for the dropdown list
            var allSuppliers = originalNCRs
                .Where(x => x.Part != null && x.Part.Supplier != null && x.Part.Supplier.Name != null)
                .Select(x => x.Part.Supplier.Name)
                .Distinct()
                .ToList();

            ViewBag.SupplierList = new SelectList(allSuppliers, selectedSupplier);

            // Dropdown for NCRStages with specific stages and their display names
            var stagesToInclude = new[]
            {
                NCRStage.Engineering,
                NCRStage.Operations,
                NCRStage.Procurement,
                NCRStage.QualityRepresentative_Final
            };
            ViewBag.NCRStageList = ToSelectList(stagesToInclude);

            return View(pagedNCRs);
        }

        public IActionResult ClearFilters()
        {
            return RedirectToAction("List");
        }

        #region Dashboard

        // For Dashboard
        public async Task<IActionResult> Index()
        {
            //Summary Table
            var ncrs = await _context.NCRs
                .Include(n => n.Supplier)
                .Include(n => n.Part)
                    .ThenInclude(p => p.Supplier)
                .Where(n => n.NCR_Status == true)
                .OrderBy(n => n.NCR_Date)
                //.Take(5)
                .ToListAsync();

            //Finance NCR
            var financeNCRs = await _context.NCRs
                .Include(n => n.Supplier)
                .Include(n => n.Part)
                    .ThenInclude(p => p.Supplier)
                .Where(n => n.NCR_Status == false)
                .OrderBy(n => n.NCR_Date)
                //.Take(5)
                .ToListAsync();


            //depending on stage, filter list
            if (User.IsInRole("Engineer"))
            {
                ncrs = new List<NCR>(ncrs.Where(n => n.NCR_Stage == (NCRStage)1)); //engineering stage not working with .Take(5)
            }
            else if (User.IsInRole("Operations"))
            {
                ncrs = new List<NCR>(ncrs.Where(n => n.NCR_Stage == (NCRStage)2)); //operations stage not working with .Take(5)
            }
            else if (User.IsInRole("Procurement"))
            {
                ncrs = new List<NCR>(ncrs.Where(n => n.NCR_Stage == (NCRStage)3)); //procurement 
            }
            else if (User.IsInRole("Quality Representative"))
            {
                ncrs = new List<NCR>(ncrs.Where(n => n.NCR_Stage == (NCRStage)4)); //quality
            }
            //else if (User.IsInRole("Finance"))
            //{
            //    financeNCRs = financeNCRs.Where(n => n.NCR_Stage == (NCRStage)5)
            //                               .OrderByDescending(n => n.NCR_Date)
            //                               .Take(5)
            //                               .ToList();
            //    return View(financeNCRs);
            //}
            else
            {
                ncrs = new List<NCR>(ncrs.Take(5));
            }


            //returns 5 to the view after gathering all the records. 
            ncrs = ncrs.Take(5).ToList();

            return View(ncrs);
        }

        public async Task<IActionResult> GetOpenNCRCount()
        {
            var openNCRCount = await _context.NCRs.CountAsync(n => n.NCR_Status && n.NCR_Date.Year == DateTime.Now.Year);
            return Json(new { count = openNCRCount });
        }

        public async Task<IActionResult> GetClosedNCRCount()
        {
            var closedNCRCount = await _context.NCRs.CountAsync(n => !n.NCR_Status && n.NCR_Date.Year == DateTime.Now.Year);
            return Json(new { count = closedNCRCount });
        }

        public async Task<IActionResult> GetEngineeringStageCount()
        {
            var engineerStage = await _context.NCRs.CountAsync(n => n.NCR_Status && n.NCR_Date.Year == DateTime.Now.Year && n.NCR_Stage == NCRStage.Engineering);
            return Json(new { count = engineerStage });
        }

        public async Task<IActionResult> GetOperationsStageCount()
        {
            var operationsStage = await _context.NCRs.CountAsync(n => n.NCR_Status && n.NCR_Date.Year == DateTime.Now.Year && n.NCR_Stage == NCRStage.Operations);
            return Json(new { count = operationsStage });
        }

        public async Task<IActionResult> GetProcurementStageCount()
        {
            var procurementStage = await _context.NCRs.CountAsync(n => n.NCR_Status && n.NCR_Date.Year == DateTime.Now.Year && n.NCR_Stage == NCRStage.Procurement);
            return Json(new { count = procurementStage });
        }

        public async Task<IActionResult> GetQualityStageCount()
        {
            var qualityStage = await _context.NCRs.CountAsync(n => n.NCR_Status && n.NCR_Date.Year == DateTime.Now.Year && n.NCR_Stage == NCRStage.QualityRepresentative_Final);
            return Json(new { count = qualityStage });
        }


        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GENERATE PDF USING RAZOR VIEW LogPdf.cshtml in Home Controller
        public async Task<IActionResult> LogPdf(int? page)
        {
            var ncrs = _context.NCRs
             .Where(p => p.IsArchived == false && p.NCR_Status == true) //active ncrs that have not been archived
             .Include(p => p.Part)
             .ThenInclude(s => s.Supplier)
             .Include(p => p.Part.DefectLists)
             .ThenInclude(d => d.Defect)
             .AsQueryable();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            // Convert the query to a paged list
            var pagedNCRs = await ncrs.ToPagedListAsync(pageNumber, pageSize);

            if (_httpContextAccessor.HttpContext.Request.Method == HttpMethod.Post.Method)
            {
                ChromePdfRenderer renderer = new ChromePdfRenderer();

                renderer.RenderingOptions.MarginTop = 10;
                renderer.RenderingOptions.MarginLeft = 10;
                renderer.RenderingOptions.MarginRight = 10;
                renderer.RenderingOptions.MarginBottom = 10;

                // Choose screen or print CSS media
                renderer.RenderingOptions.CssMediaType = PdfCssMediaType.Print;

                // Render View to PDF document
                PdfDocument pdf = renderer.RenderRazorViewToPdf(_viewRenderService, "Views/Home/LogPdf.cshtml", pagedNCRs);
                Response.Headers.Add("Content-Disposition", "inline");
                // Output PDF document
                return File(pdf.BinaryData, "application/pdf", "NCR Log.pdf");
            }
            return View(pagedNCRs);
        }

        private string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            ?.GetName() ?? enumValue.ToString();
        }

        private SelectList ToSelectList<TEnum>(params TEnum[] filter) where TEnum : struct, Enum, IConvertible
        {
            var values = (filter == null || !filter.Any()) ? Enum.GetValues(typeof(TEnum)).Cast<Enum>() : filter.Cast<Enum>();
            var items = values.Select(value => new SelectListItem
            {
                Text = GetDisplayName(value),
                Value = value.ToString()
            }).ToList();

            return new SelectList(items, "Value", "Text");
        }
    }
}