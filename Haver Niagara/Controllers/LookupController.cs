using Haver_Niagara.CustomController;
using Haver_Niagara.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Haver_Niagara.Controllers
{
    public class LookupController : CognizantController
    {
        private readonly HaverNiagaraDbContext _context;
        public LookupController(HaverNiagaraDbContext context) 
        {
            _context = context;
        }

		public IActionResult Index(string Tab = "Supplier-Tab")
		{
			ViewData["Tab"] = Tab;
			return View();
		}
        public PartialViewResult Supplier()
        {
            ViewData["SupplierID"] = new
                SelectList(_context.Suppliers
                .OrderBy(s => s.Name), "ID", "Name");
            return PartialView("_Supplier");
        }

        public PartialViewResult Defect()
        {
            ViewData["DefectID"] = new
                SelectList(_context.Defects
                .OrderBy(d => d.Name), "ID", "Name");
            return PartialView("_Defect");
        }

        public PartialViewResult SAPNumber()
        {
            ViewData["SAPNumberID"] = new
                SelectList(_context.SAPNumbers
                .OrderBy(d => d.Number), "ID", "Number");
            return PartialView("_SAPNumber");
        }

        public PartialViewResult PartName()
        {
            ViewData["PartNameID"] = new
                SelectList(_context.PartNames
                .OrderBy(d => d.Name), "ID", "Name");
            return PartialView("_PartName");
        }
    }
}
