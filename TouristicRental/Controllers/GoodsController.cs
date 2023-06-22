using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristicRental.Data;
using TouristicRental.Models;

namespace TouristicRental.Controllers
{
    public class GoodsController : Controller
    {
        private readonly TouristicRentalContext _context;

        public GoodsController(TouristicRentalContext context)
        {
            _context = context;
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
              return View(await _context.Goods.ToListAsync());
        }

        // GET: Goods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .FirstOrDefaultAsync(m => m.GoodId == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodId,Name,DailyPrice,Description,Category,IsFree,ImagePath")] Good good)
        {
            if (ModelState.IsValid)
            {
                good.IsFree = true;
                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(good);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodId,Name,DailyPrice,Description,Category,IsFree,ImagePath")] Good good)
        {
            if (id != good.GoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.GoodId))
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
            return View(good);
        }

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .FirstOrDefaultAsync(m => m.GoodId == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Goods == null)
            {
                return Problem("Entity set 'TouristicRentalContext.Goods'  is null.");
            }
            var good = await _context.Goods.FindAsync(id);
            if (good != null)
            {
                _context.Goods.Remove(good);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodExists(int id)
        {
          return _context.Goods.Any(e => e.GoodId == id);
        }
    }
}
