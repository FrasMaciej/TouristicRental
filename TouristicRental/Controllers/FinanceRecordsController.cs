using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristicRental.Data;
using TouristicRental.Models;

namespace TouristicRental.Controllers
{
    [Authorize]
    public class FinanceRecordsController : Controller
    {
        private readonly TouristicRentalContext _context;

        public FinanceRecordsController(TouristicRentalContext context)
        {
            _context = context;
        }

        // GET: FinanceRecords
        public async Task<IActionResult> Index()
        {
              return View(await _context.Finances.ToListAsync());
        }

        // GET: FinanceRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Finances == null)
            {
                return NotFound();
            }

            var financeRecord = await _context.Finances
                .FirstOrDefaultAsync(m => m.FinanceRecordId == id);
            if (financeRecord == null)
            {
                return NotFound();
            }

            return View(financeRecord);
        }

        // GET: FinanceRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinanceRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinanceRecordId,Value,Date,Description")] FinanceRecord financeRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financeRecord);
        }

        // GET: FinanceRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Finances == null)
            {
                return NotFound();
            }

            var financeRecord = await _context.Finances.FindAsync(id);
            if (financeRecord == null)
            {
                return NotFound();
            }
            return View(financeRecord);
        }

        // POST: FinanceRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinanceRecordId,Value,Date,Description")] FinanceRecord financeRecord)
        {
            if (id != financeRecord.FinanceRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinanceRecordExists(financeRecord.FinanceRecordId))
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
            return View(financeRecord);
        }

        // GET: FinanceRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Finances == null)
            {
                return NotFound();
            }

            var financeRecord = await _context.Finances
                .FirstOrDefaultAsync(m => m.FinanceRecordId == id);
            if (financeRecord == null)
            {
                return NotFound();
            }

            return View(financeRecord);
        }

        // POST: FinanceRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Finances == null)
            {
                return Problem("Entity set 'TouristicRentalContext.Finances'  is null.");
            }
            var financeRecord = await _context.Finances.FindAsync(id);
            if (financeRecord != null)
            {
                _context.Finances.Remove(financeRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinanceRecordExists(int id)
        {
          return _context.Finances.Any(e => e.FinanceRecordId == id);
        }
    }
}
