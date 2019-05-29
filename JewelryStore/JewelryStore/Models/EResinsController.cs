using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryStore.Data;

namespace JewelryStore.Models
{
    public class EResinsController : Controller
    {
        private readonly JewelryContext _context;

        public EResinsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: EResins
        public async Task<IActionResult> Index()
        {
            var jewelryContext = _context.EResins.Include(e => e.provisioner);
            return View(await jewelryContext.ToListAsync());
        }

        // GET: EResins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eResin = await _context.EResins
                .Include(e => e.provisioner)
                .FirstOrDefaultAsync(m => m.erID == id);
            if (eResin == null)
            {
                return NotFound();
            }

            return View(eResin);
        }

        // GET: EResins/Create
        public IActionResult Create()
        {
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID");
            return View();
        }

        // POST: EResins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("erID,Name,Cost,InStock,pID")] EResin eResin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eResin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", eResin.pID);
            return View(eResin);
        }

        // GET: EResins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eResin = await _context.EResins.FindAsync(id);
            if (eResin == null)
            {
                return NotFound();
            }
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", eResin.pID);
            return View(eResin);
        }

        // POST: EResins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("erID,Name,Cost,InStock,pID")] EResin eResin)
        {
            if (id != eResin.erID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eResin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EResinExists(eResin.erID))
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
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", eResin.pID);
            return View(eResin);
        }

        // GET: EResins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eResin = await _context.EResins
                .Include(e => e.provisioner)
                .FirstOrDefaultAsync(m => m.erID == id);
            if (eResin == null)
            {
                return NotFound();
            }

            return View(eResin);
        }

        // POST: EResins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eResin = await _context.EResins.FindAsync(id);
            _context.EResins.Remove(eResin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EResinExists(int id)
        {
            return _context.EResins.Any(e => e.erID == id);
        }
    }
}
