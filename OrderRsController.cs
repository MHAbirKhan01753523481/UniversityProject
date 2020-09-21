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
    public class OrderRsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderRsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View(_context.OrderR.ToList());
        }
        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderR = _context.OrderR
                .SingleOrDefault(m => m.Id == id);
            if (orderR == null)
            {
                return NotFound();
            }

            return View(orderR);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,TableNo,OrderNumber,OrderDate,OrderType,EmployeeId,PaymentAmount,PaymentStautas,PaymentType,StatusType")] OrderR orderR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderR);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orderR);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderR = _context.OrderR.SingleOrDefault(m => m.Id == id);
            if (orderR == null)
            {
                return NotFound();
            }
            return View(orderR);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,TableNo,OrderNumber,OrderDate,OrderType,EmployeeId,PaymentAmount,PaymentStautas,PaymentType,StatusType")] OrderR orderR)
        {
            if (id != orderR.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderR);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderRExists(orderR.Id))
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
            return View(orderR);
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderR = _context.OrderR
                .SingleOrDefault(m => m.Id == id);
            if (orderR == null)
            {
                return NotFound();
            }

            return View(orderR);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderR = _context.OrderR.SingleOrDefault(m => m.Id == id);
            _context.OrderR.Remove(orderR);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderRExists(int id)
        {
            return _context.OrderR.Any(e => e.Id == id);
        }
    }
}
