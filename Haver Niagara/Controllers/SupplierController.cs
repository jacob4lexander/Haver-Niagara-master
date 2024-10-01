using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Haver_Niagara.Data;
using Haver_Niagara.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Haver_Niagara.CustomController;

namespace Haver_Niagara.Controllers
{
    public class SupplierController : LookupsController
	{
        private readonly HaverNiagaraDbContext _context;

        public SupplierController(HaverNiagaraDbContext context)
        {
            _context = context;
        }

        // GET: Supplier
        public IActionResult Index()
        {
            return Redirect(ViewData["returnURL"].ToString());
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //To recreate, create a seperate Create(supplier/part) to not mess up the ones in the ddl
        //In the Create.cshtml, insert Create(supplier/part) in the form action  then 
        //    <label asp-for="Name" class="control-label"></label>
        //    <textarea class="form-control" id="defects" name="defects" rows="3" required></textarea>
        //    <span asp-validation-for="Name" class="text-danger"></span>
        public async Task<IActionResult> CreateSuppliers(string suppliers)
        {
            try
            {
                //Splits the names by line breaks and commans and removes empty entries
                string[] supplierNames = suppliers.Split(new[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);

                supplierNames = supplierNames.Select(name => name.Trim()).ToArray();

                //Make a copy of the defects being inserted so we dont convert them all to lower case
                var lowerSupplierNames = supplierNames.Select(name => name.ToLower());

                var allSuppliers = _context.Suppliers.Select(n => n.Name.ToLower());

                var duplicates = lowerSupplierNames.Intersect(allSuppliers).ToList();

                if (duplicates.Any())
                {
                    ModelState.AddModelError("Name", "Unable to save changes. "
                         + "You cannot have duplicate Supplier Names");
                    return View("Create");
                }

                //If it gets here then all good
                var newSuppliers = supplierNames.Select(name => new Supplier { Name = name });

                _context.Suppliers.AddRange(newSuppliers);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes. "
                        + "You cannot have duplicate Supplier Names");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, " +
                        "If the problem persists contact your administrator.");
                }
            }
            if (!ModelState.IsValid && Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                string errorMessage = "";
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errorMessage += error.ErrorMessage + "|";
                    }
                }
                return BadRequest(errorMessage);
            }
            return Redirect(ViewData["returnURL"].ToString());
        }


        // POST: Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(supplier);
                    await _context.SaveChangesAsync();
                    return Redirect(ViewData["returnURL"].ToString());
                }
            }
            catch(DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes. "
                        + "You cannot have duplicate Supplier Names");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, " +
                        "If the problem persists contact your administrator.");
                }
            }
            if (!ModelState.IsValid && Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                string errorMessage = "";
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errorMessage += error.ErrorMessage + "|";
                    }
                }
                return BadRequest(errorMessage);
            }
            return View(supplier);
        }

        // GET: Supplier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Supplier supplier)
        {
            if (id != supplier.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException dex)
                {
                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed"))
                    {
                        ModelState.AddModelError("Name", "Unable to save changes. "
                            + "You cannot have duplicate Supplier Names");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, " +
                            "If the problem persists contact your administrator.");
                    }
                }
                if (!ModelState.IsValid && Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    string errorMessage = "";
                    foreach (var modelState in ViewData.ModelState.Values)
                    {
                        foreach (ModelError error in modelState.Errors)
                        {
                            errorMessage += error.ErrorMessage + "|";
                        }
                    }
                    return BadRequest(errorMessage);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            //looking to see if it has any ncrs associated
            var associatedNCR = await _context.NCRs.FirstOrDefaultAsync(c => c.NCRSupplierID == id);
            ////getting a list of the suppliers to display it dynamically in the error message
            //var suppliers = await _context.Suppliers.FindAsync(id);


            if (associatedNCR != null)
            {
                var SupplierName = supplier.Name;                
                TempData["ErrorMessage"] = $"{SupplierName} cannot be deleted because it is associated with an NCR.";
                return RedirectToAction(nameof(Index));
            }

            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Suppliers == null)
                {
                    return Problem("Entity set 'HaverNiagaraDbContext.Suppliers'  is null.");
                }
                var supplier = await _context.Suppliers.FindAsync(id);
                if (supplier != null)
                {
                    _context.Suppliers.Remove(supplier);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool SupplierExists(int id)
        {
          return _context.Suppliers.Any(e => e.ID == id);
        }
    }
}
