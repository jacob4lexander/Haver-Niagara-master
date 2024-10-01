using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Haver_Niagara.Data;
using Haver_Niagara.Models;

namespace Haver_Niagara.Controllers
{
    public class TestController : Controller
    {
        private readonly HaverNiagaraDbContext _context;

        public TestController(HaverNiagaraDbContext context)
        {
            _context = context;
        }

        // GET: NCReport
        public async Task<IActionResult> Index(int? SupplierID, NCRStage Stage)
        {
            PopulateDropDownLists();

            var haverNiagaraDbContext = _context
                .NCRs
                .Include(n => n.Engineering)
                .Include(n => n.Operation)
                .Include(n => n.Part).Include(n => n.Procurement)
                .Include(n => n.QualityInspection)
                .Include(n => n.QualityInspectionFinal)
                .Include(n => n.Supplier);
            return View(await haverNiagaraDbContext.ToListAsync());
        }

        // GET: NCReport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NCRs == null)
            {
                return NotFound();
            }

            var nCR = await _context.NCRs
                .Include(n => n.Engineering)
                .Include(n => n.Operation)
                .Include(n => n.Part)
                .Include(n => n.Procurement)
                .Include(n => n.QualityInspection)
                .Include(n => n.QualityInspectionFinal)
                .Include(n => n.Supplier)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nCR == null)
            {
                return NotFound();
            }

            return View(nCR);
        }

        // GET: NCReport/Create
        public IActionResult Create()
        {
            ViewData["EngineeringID"] = new SelectList(_context.Engineerings, "ID", "Name");
            ViewData["OperationID"] = new SelectList(_context.Operations, "ID", "ID");
            ViewData["PartID"] = new SelectList(_context.Parts, "ID", "Description");
            ViewData["ProcurementID"] = new SelectList(_context.Procurements, "ID", "ID");
            ViewData["QualityInspectionID"] = new SelectList(_context.QualityInspections, "ID", "Name");
            ViewData["QualityInspectionFinalID"] = new SelectList(_context.QualityInspectionFinals, "ID", "ID");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "Name");
            return View();
        }

        // POST: NCReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NCR_Date,NCR_Status,NewNCRID,OldNCRID,IsArchived,NCR_Stage,SupplierID,PartID,OperationID,EngineeringID,QualityInspectionID,ProcurementID,QualityInspectionFinalID")] NCR nCR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nCR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineeringID"] = new SelectList(_context.Engineerings, "ID", "Name", nCR.EngineeringID);
            ViewData["OperationID"] = new SelectList(_context.Operations, "ID", "ID", nCR.OperationID);
            ViewData["PartID"] = new SelectList(_context.Parts, "ID", "Description", nCR.PartID);
            ViewData["ProcurementID"] = new SelectList(_context.Procurements, "ID", "ID", nCR.ProcurementID);
            ViewData["QualityInspectionID"] = new SelectList(_context.QualityInspections, "ID", "Name", nCR.QualityInspectionID);
            ViewData["QualityInspectionFinalID"] = new SelectList(_context.QualityInspectionFinals, "ID", "ID", nCR.QualityInspectionFinalID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID", nCR.NCRSupplierID);
            return View(nCR);
        }

        // GET: NCReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NCRs == null)
            {
                return NotFound();
            }

            var nCR = await _context.NCRs.FindAsync(id);
            if (nCR == null)
            {
                return NotFound();
            }
            ViewData["EngineeringID"] = new SelectList(_context.Engineerings, "ID", "Name", nCR.EngineeringID);
            ViewData["OperationID"] = new SelectList(_context.Operations, "ID", "ID", nCR.OperationID);
            ViewData["PartID"] = new SelectList(_context.Parts, "ID", "Description", nCR.PartID);
            ViewData["ProcurementID"] = new SelectList(_context.Procurements, "ID", "ID", nCR.ProcurementID);
            ViewData["QualityInspectionID"] = new SelectList(_context.QualityInspections, "ID", "Name", nCR.QualityInspectionID);
            ViewData["QualityInspectionFinalID"] = new SelectList(_context.QualityInspectionFinals, "ID", "ID", nCR.QualityInspectionFinalID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID", nCR.NCRSupplierID);
            return View(nCR);
        }

        // POST: NCReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NCR_Date,NCR_Status,NewNCRID,OldNCRID,IsArchived,NCR_Stage,SupplierID,PartID,OperationID,EngineeringID,QualityInspectionID,ProcurementID,QualityInspectionFinalID")] NCR nCR)
        {
            if (id != nCR.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nCR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NCRExists(nCR.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineeringID"] = new SelectList(_context.Engineerings, "ID", "Name", nCR.EngineeringID);
            ViewData["OperationID"] = new SelectList(_context.Operations, "ID", "ID", nCR.OperationID);
            ViewData["PartID"] = new SelectList(_context.Parts, "ID", "Description", nCR.PartID);
            ViewData["ProcurementID"] = new SelectList(_context.Procurements, "ID", "ID", nCR.ProcurementID);
            ViewData["QualityInspectionID"] = new SelectList(_context.QualityInspections, "ID", "Name", nCR.QualityInspectionID);
            ViewData["QualityInspectionFinalID"] = new SelectList(_context.QualityInspectionFinals, "ID", "ID", nCR.QualityInspectionFinalID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID", nCR.NCRSupplierID);
            return View(nCR);
        }

        // GET: NCReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NCRs == null)
            {
                return NotFound();
            }

            var nCR = await _context.NCRs
                .Include(n => n.Engineering)
                .Include(n => n.Operation)
                .Include(n => n.Part)
                .Include(n => n.Procurement)
                .Include(n => n.QualityInspection)
                .Include(n => n.QualityInspectionFinal)
                .Include(n => n.Supplier)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nCR == null)
            {
                return NotFound();
            }

            return View(nCR);
        }

        // POST: NCReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NCRs == null)
            {
                return Problem("Entity set 'HaverNiagaraDbContext.NCRs'  is null.");
            }
            var nCR = await _context.NCRs.FindAsync(id);
            if (nCR != null)
            {
                _context.NCRs.Remove(nCR);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NCRExists(int id)
        {
          return _context.NCRs.Any(e => e.ID == id);
        }

        private SelectList SupplierSelectList(int? selectedId)
        {
            return new SelectList(_context.Suppliers
                .OrderBy(s => s.Name), "ID", "Name", selectedId);
        }

        private SelectList StageSelectList(string selected)
        {
            return new SelectList(_context.NCRs
                .OrderBy(s => s.NCR_Stage),"Name", selected);
        }

        private void PopulateDropDownLists(NCR ncr = null)
        {
            ViewData["SupplierID"] = SupplierSelectList(ncr?.NCRSupplierID);
            ViewData["Stage"] = StageSelectList(ncr?.NCR_Stage.ToString());
        }
    }
}
