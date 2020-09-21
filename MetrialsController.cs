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
    public class MetrialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MetrialsController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Metrial.ToList());
        }
        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrial =_context.Metrial
                .SingleOrDefault(m => m.Id == id);
            if (metrial == null)
            {
                return NotFound();
            }

            return View(metrial);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Store,Supply,Unit,Price,TotalQuantity,AvailableQuantity")] Metrial metrial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metrial);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(metrial);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrial = _context.Metrial.SingleOrDefault(m => m.Id == id);
            if (metrial == null)
            {
                return NotFound();
            }
            return View(metrial);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Store,Supply,Unit,Price,TotalQuantity,AvailableQuantity")] Metrial metrial)
        {
            if (id != metrial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metrial);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetrialExists(metrial.Id))
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
            return View(metrial);
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrial = _context.Metrial
                .SingleOrDefault(m => m.Id == id);
            if (metrial == null)
            {
                return NotFound();
            }

            return View(metrial);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var metrial = _context.Metrial.SingleOrDefault(m => m.Id == id);
            _context.Metrial.Remove(metrial);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool MetrialExists(int id)
        {
            return _context.Metrial.Any(e => e.Id == id);
        }
    }
}
