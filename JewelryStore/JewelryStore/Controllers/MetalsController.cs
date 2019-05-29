using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryStore.Data;
using JewelryStore.Models;

namespace JewelryStore.Controllers
{
    public class MetalsController : Controller
    {
        private readonly JewelryContext _context;

        public MetalsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: Metals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Metals.ToListAsync());
        }

        // GET: Metals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metals = await _context.Metals
                .FirstOrDefaultAsync(m => m.mID == id);
            if (metals == null)
            {
                return NotFound();
            }

            return View(metals);
        }

        // GET: Metals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Metals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mID,Name")] Metals metals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metals);
        }

        // GET: Metals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metals = await _context.Metals.FindAsync(id);
            if (metals == null)
            {
                return NotFound();
            }
            return View(metals);
        }

        // POST: Metals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mID,Name")] Metals metals)
        {
            if (id != metals.mID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetalsExists(metals.mID))
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
            return View(metals);
        }

        // GET: Metals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metals = await _context.Metals
                .FirstOrDefaultAsync(m => m.mID == id);
            if (metals == null)
            {
                return NotFound();
            }

            return View(metals);
        }

        // POST: Metals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metals = await _context.Metals.FindAsync(id);
            _context.Metals.Remove(metals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetalsExists(int id)
        {
            return _context.Metals.Any(e => e.mID == id);
        }
    }
}
