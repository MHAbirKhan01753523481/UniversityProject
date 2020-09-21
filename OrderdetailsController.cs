using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkAppp.Data;
using WorkAppp.Models;

namespace WorkAppp.Controllers
{
    public class OrderdetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderdetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var workApppContext = _context.Orderdetails.Include(o => o.OrderR);
            return View( workApppContext.ToList());
        }
        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetails = _context.Orderdetails
                .Include(o => o.OrderR)
                .SingleOrDefault(m => m.Id == id);
            if (orderdetails == null)
            {
                return NotFound();
            }

            return View(orderdetails);
        }
        
        public IActionResult Create()
        {
            ViewData["OrderRId"] = new SelectList(_context.OrderR, "Id", "Id");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ItemId,ItemPrice,Quantity,OrderRId")] Orderdetails orderdetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderdetails);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderRId"] = new SelectList(_context.OrderR, "Id", "Id", orderdetails.OrderRId);
            return View(orderdetails);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetails = _context.Orderdetails.SingleOrDefault(m => m.Id == id);
            if (orderdetails == null)
            {
                return NotFound();
            }
            ViewData["OrderRId"] = new SelectList(_context.OrderR, "Id", "Id", orderdetails.OrderRId);
            return View(orderdetails);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ItemId,ItemPrice,Quantity,OrderRId")] Orderdetails orderdetails)
        {
            if (id != orderdetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderdetails);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderdetailsExists(orderdetails.Id))
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
            ViewData["OrderRId"] = new SelectList(_context.OrderR, "Id", "Id", orderdetails.OrderRId);
            return View(orderdetails);
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetails = _context.Orderdetails
                .Include(o => o.OrderR)
                .SingleOrDefault(m => m.Id == id);
            if (orderdetails == null)
            {
                return NotFound();
            }

            return View(orderdetails);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderdetails = _context.Orderdetails.SingleOrDefault(m => m.Id == id);
            _context.Orderdetails.Remove(orderdetails);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderdetailsExists(int id)
        {
            return _context.Orderdetails.Any(e => e.Id == id);
        }
    }
}
