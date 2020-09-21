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
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var workApppContext = _context.Item.Include(i => i.SubCategory);
            return View( workApppContext.ToList());
        }
        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _context.Item
                .Include(i => i.SubCategory)
                .SingleOrDefault(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        
        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "SubCategoryName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ItemName,Price,Quantity,DiscountPrice,Details,SubCategoryId")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "SubCategoryName", item.SubCategoryId);
            return View(item);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _context.Item.SingleOrDefault(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "SubCategoryName", item.SubCategoryId);
            return View(item);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ItemName,Price,Quantity,DiscountPrice,Details,SubCategoryId")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
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
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategory, "Id", "SubCategoryName", item.SubCategoryId);
            return View(item);
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = _context.Item
                .Include(i => i.SubCategory)
                .SingleOrDefault(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.Item.SingleOrDefault(m => m.Id == id);
            _context.Item.Remove(item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
    }
}
