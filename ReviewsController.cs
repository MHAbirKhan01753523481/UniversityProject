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
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var workApppContext = _context.Review.Include(r => r.Items);
            return View( workApppContext.ToList());
        }
        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = _context.Review
                .Include(r => r.Items)
                .SingleOrDefault(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }
        
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Set<Item>(), "Id", "ItemName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ReviewStatus,ItemId")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Set<Item>(), "Id", "ItemName", review.ItemId);
            return View(review);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = _context.Review.SingleOrDefault(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Set<Item>(), "Id", "ItemName", review.ItemId);
            return View(review);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ReviewStatus,ItemId")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
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
            ViewData["ItemId"] = new SelectList(_context.Set<Item>(), "Id", "ItemName", review.ItemId);
            return View(review);
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = _context.Review
                .Include(r => r.Items)
                .SingleOrDefault(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var review = _context.Review.SingleOrDefault(m => m.Id == id);
            _context.Review.Remove(review);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
    }
}
