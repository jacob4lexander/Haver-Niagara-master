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
    public class SAPNumberController : LookupsController
    {
        private readonly HaverNiagaraDbContext _context;

        public SAPNumberController(HaverNiagaraDbContext context)
        {
            _context = context;
        }

        // GET: SAPNumber
        public IActionResult Index()
        {
			return Redirect(ViewData["returnURL"].ToString());
		}

        // GET: SAPNumber/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SAPNumbers == null)
            {
                return NotFound();
            }

            var sAPNumber = await _context.SAPNumbers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sAPNumber == null)
            {
                return NotFound();
            }

            return View(sAPNumber);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //To recreate, create a seperate Create(supplier/part) to not mess up the ones in the ddl
        //In the Create.cshtml, insert Create(supplier/part) in the form action  then 
        //    <label asp-for="Name" class="control-label"></label>
        //    <textarea class="form-control" id="defects" name="defects" rows="3" required></textarea>
        //    <span asp-validation-for="Name" class="text-danger"></span>
        public async Task<IActionResult> CreateSAPNumbers(string sapnumbers)
        {
            try
            {
                //Splits the names by line breaks and commas and removes empty entries
                string[] sapNames = sapnumbers.Split(new[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);

                sapNames = sapNames.Select(name => name.Trim()).ToArray();

                //Make a copy of the SAP numbers being inserted so we don't convert them all to lower case
                var lowerSAPNames = sapNames.Select(name => name.ToLower());

                var allSAPs = await _context.SAPNumbers.Select(n => n.Number.ToString().ToLower()).ToListAsync();

                var duplicates = lowerSAPNames.Intersect(allSAPs).ToList();

                if (duplicates.Any())
                {
                    ModelState.AddModelError("", "Unable to save changes. Duplicate SAP Numbers found.");
                    return View("Create");
                }

                //If it gets here then all good
                var newSAPs = sapNames.Select(name => new SAPNumber { Number = int.Parse(name) });

                _context.SAPNumbers.AddRange(newSAPs);
                await _context.SaveChangesAsync();

                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes. "
                        + "You cannot have duplicate SAP Numbers");
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

        // GET: SAPNumber/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SAPNumber/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Number")] SAPNumber sAPNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sAPNumber);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());
            }
            return View(sAPNumber);
        }

        // GET: SAPNumber/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SAPNumbers == null)
            {
                return NotFound();
            }

            var sAPNumber = await _context.SAPNumbers.FindAsync(id);
            if (sAPNumber == null)
            {
                return NotFound();
            }
            return View(sAPNumber);
        }

        // POST: SAPNumber/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Number")] SAPNumber sAPNumber)
        {
            if (id != sAPNumber.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sAPNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SAPNumberExists(sAPNumber.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect(ViewData["returnURL"].ToString());
            }
            return View(sAPNumber);
        }

        // GET: SAPNumber/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SAPNumbers == null)
            {
                return NotFound();
            }

            var sAPNumber = await _context.SAPNumbers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sAPNumber == null)
            {
                return NotFound();
            }

            // Check if there are any parts associated with this sap number
            var associatedParts = await _context.Parts
                .FirstOrDefaultAsync(p => p.PartNameID == id);

            // If there are associated parts, check if any of them have associated NCRs
            if (associatedParts != null)
            {
                var SAPNumber = sAPNumber.Number;
                TempData["ErrorMessage"] = $"{SAPNumber} cannot be deleted because it is associated with an NCR.";
                return RedirectToAction(nameof(Index));
            }


            return View(sAPNumber);
        }

        // POST: SAPNumber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SAPNumbers == null)
            {
                return Problem("Entity set 'HaverNiagaraDbContext.SAPNumbers'  is null.");
            }
            var sAPNumber = await _context.SAPNumbers.FindAsync(id);
            if (sAPNumber != null)
            {
                _context.SAPNumbers.Remove(sAPNumber);
            }
            
            await _context.SaveChangesAsync();
            return Redirect(ViewData["returnURL"].ToString());
        }

        private bool SAPNumberExists(int id)
        {
          return _context.SAPNumbers.Any(e => e.ID == id);
        }
    }
}
