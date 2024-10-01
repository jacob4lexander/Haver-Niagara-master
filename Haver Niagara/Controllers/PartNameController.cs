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
    public class PartNameController : LookupsController
    {
        private readonly HaverNiagaraDbContext _context;

        public PartNameController(HaverNiagaraDbContext context)
        {
            _context = context;
        }

        // GET: PartName
        public IActionResult Index()
        {
			return Redirect(ViewData["returnURL"].ToString());
		}

        // GET: PartName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PartNames == null)
            {
                return NotFound();
            }

            var partName = await _context.PartNames
                .FirstOrDefaultAsync(m => m.ID == id);
            if (partName == null)
            {
                return NotFound();
            }

            return View(partName);
        }

        // GET: PartName/Create
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
        public async Task<IActionResult> CreatePartNames(string partnames)
        {
            try
            {
                //Splits the names by line breaks and commans and removes empty entries
                string[] partNames = partnames.Split(new[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);

                partNames = partNames.Select(name => name.Trim()).ToArray();

                //Make a copy of the defects being inserted so we dont convert them all to lower case
                var lowerPartNames = partNames.Select(name => name.ToLower());

                var allPartNames = _context.PartNames.Select(n => n.Name.ToLower());

                var duplicates = lowerPartNames.Intersect(allPartNames).ToList();

                if (duplicates.Any())
                {
                    ModelState.AddModelError("Name", "Unable to save changes. "
                         + "You cannot have duplicate Part Names");
                    return View("Create");
                }

                //If it gets here then all good
                var newPartNames = partNames.Select(name => new PartName { Name = name });

                _context.PartNames.AddRange(newPartNames);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());
            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed"))
                {
                    ModelState.AddModelError("Name", "Unable to save changes. "
                        + "You cannot have duplicate Part Names");
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

        // POST: PartName/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] PartName partName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partName);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());
            }
            return View(partName);
        }

        // GET: PartName/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PartNames == null)
            {
                return NotFound();
            }

            var partName = await _context.PartNames.FindAsync(id);
            if (partName == null)
            {
                return NotFound();
            }
            return View(partName);
        }

        // POST: PartName/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] PartName partName)
        {
            if (id != partName.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartNameExists(partName.ID))
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
            return View(partName);
        }

        // GET: PartName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PartNames == null)
            {
                return NotFound();
            }

            var partName = await _context.PartNames
                .FirstOrDefaultAsync(m => m.ID == id);
            if (partName == null)
            {
                return NotFound();
            }

            // Check if there are any parts associated with this part name
            var associatedParts = await _context.Parts
                .FirstOrDefaultAsync(p => p.PartNameID == id);

            // If there are associated parts, check if any of them have associated NCRs
            if (associatedParts != null)
            {
                var PartName = partName.Name;
                TempData["ErrorMessage"] = $"{PartName} cannot be deleted because it is associated with an NCR.";
                return RedirectToAction(nameof(Index));
            }

            return View(partName);
        }

        // POST: PartName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PartNames == null)
            {
                return Problem("Entity set 'HaverNiagaraDbContext.PartNames'  is null.");
            }
            var partName = await _context.PartNames.FindAsync(id);
            if (partName != null)
            {
                _context.PartNames.Remove(partName);
            }
            
            await _context.SaveChangesAsync();
            return Redirect(ViewData["returnURL"].ToString());
        }

        private bool PartNameExists(int id)
        {
          return _context.PartNames.Any(e => e.ID == id);
        }
    }
}
