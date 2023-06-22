using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TouristicRental.Data;
using TouristicRental.Models;

namespace TouristicRental.Controllers
{
    public class OrdersController : Controller
    {
        private readonly TouristicRentalContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdersController(TouristicRentalContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var userRole = User.FindFirstValue(ClaimTypes.Role); // will give the user's userName
            if(userRole == "Worker")
                return View(await _context.Orders.ToListAsync());
            else
            {
                var client = _context.Clients.FirstOrDefault(c => c.userId == userId);
                var clientID = client.ClientId;
                var orders = _context.Orders.Where(o => o.ClientFK == clientID);
                return View(await orders.ToListAsync());
            }
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["Good"] = new SelectList(_context.Goods.Where(g => g.IsFree == true), "GoodId", "Name", "DailyPrice", "DailyPrice");

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,RentDate,ReturnDate,GoodFK, ClientId")] Order order)
        {
            if (ModelState.IsValid)
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
                var userRole = User.FindFirstValue(ClaimTypes.Role); // will give the user's userName
                if (userRole == "Client")
                { 
                    var client = _context.Clients.FirstOrDefault(c => c.userId == userId);
                    var clientID = client.ClientId;
                    order.ClientFK = clientID;
                }
                order.isFinished = false;
                order.isPaid = false;
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,RentDate,ReturnDate,isPaid,isFinished,GoodFK,ClientFK")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(order.isFinished)
                    {
                        order.isPaid = true;
                    }
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'TouristicRentalContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
