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
    public class JTypesController : Controller
    {
        private readonly JewelryContext _context;

        public JTypesController(JewelryContext context)
        {
            _context = context;
        }

        // GET: JTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.jTypes.ToListAsync());
        }

        // GET: JTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jType = await _context.jTypes
                .FirstOrDefaultAsync(m => m.jtID == id);
            if (jType == null)
            {
                return NotFound();
            }

            return View(jType);
        }

        // GET: JTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("jtID,Name")] JType jType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jType);
        }

        // GET: JTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jType = await _context.jTypes.FindAsync(id);
            if (jType == null)
            {
                return NotFound();
            }
            return View(jType);
        }

        // POST: JTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("jtID,Name")] JType jType)
        {
            if (id != jType.jtID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JTypeExists(jType.jtID))
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
            return View(jType);
        }

        // GET: JTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jType = await _context.jTypes
                .FirstOrDefaultAsync(m => m.jtID == id);
            if (jType == null)
            {
                return NotFound();
            }

            return View(jType);
        }

        // POST: JTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jType = await _context.jTypes.FindAsync(id);
            _context.jTypes.Remove(jType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JTypeExists(int id)
        {
            return _context.jTypes.Any(e => e.jtID == id);
        }
    }
}
