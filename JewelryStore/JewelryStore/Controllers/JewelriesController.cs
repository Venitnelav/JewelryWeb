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
    public class JewelriesController : Controller
    {
        private readonly JewelryContext _context;

        public JewelriesController(JewelryContext context)
        {
            _context = context;
        }

        // GET: Jewelries
        public async Task<IActionResult> Index()
        {
            var jewelryContext = _context.Jewelries.Include(j => j.EResins).Include(j => j.MComponents).Include(j => j.OComponents);
            return View(await jewelryContext.ToListAsync());
        }

        // GET: Jewelries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelry = await _context.Jewelries
                .Include(j => j.EResins)
                .Include(j => j.MComponents)
                .Include(j => j.OComponents)
                .FirstOrDefaultAsync(m => m.jID == id);
            if (jewelry == null)
            {
                return NotFound();
            }

            return View(jewelry);
        }

        // GET: Jewelries/Create
        public IActionResult Create()
        {
            ViewData["erID"] = new SelectList(_context.EResins, "erID", "erID");
            ViewData["mcID"] = new SelectList(_context.MComponents, "mcID", "mcID");
            ViewData["oID"] = new SelectList(_context.OComponents, "oID", "oID");
            return View();
        }

        // POST: Jewelries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("jID,Image,Name,Cost,InStock,mcID,erID,oID")] Jewelry jewelry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jewelry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["erID"] = new SelectList(_context.EResins, "erID", "erID", jewelry.erID);
            ViewData["mcID"] = new SelectList(_context.MComponents, "mcID", "mcID", jewelry.mcID);
            ViewData["oID"] = new SelectList(_context.OComponents, "oID", "oID", jewelry.oID);
            return View(jewelry);
        }

        // GET: Jewelries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelry = await _context.Jewelries.FindAsync(id);
            if (jewelry == null)
            {
                return NotFound();
            }
            ViewData["erID"] = new SelectList(_context.EResins, "erID", "erID", jewelry.erID);
            ViewData["mcID"] = new SelectList(_context.MComponents, "mcID", "mcID", jewelry.mcID);
            ViewData["oID"] = new SelectList(_context.OComponents, "oID", "oID", jewelry.oID);
            return View(jewelry);
        }

        // POST: Jewelries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("jID,Image,Name,Cost,InStock,mcID,erID,oID")] Jewelry jewelry)
        {
            if (id != jewelry.jID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jewelry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JewelryExists(jewelry.jID))
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
            ViewData["erID"] = new SelectList(_context.EResins, "erID", "erID", jewelry.erID);
            ViewData["mcID"] = new SelectList(_context.MComponents, "mcID", "mcID", jewelry.mcID);
            ViewData["oID"] = new SelectList(_context.OComponents, "oID", "oID", jewelry.oID);
            return View(jewelry);
        }

        // GET: Jewelries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelry = await _context.Jewelries
                .Include(j => j.EResins)
                .Include(j => j.MComponents)
                .Include(j => j.OComponents)
                .FirstOrDefaultAsync(m => m.jID == id);
            if (jewelry == null)
            {
                return NotFound();
            }

            return View(jewelry);
        }

        // POST: Jewelries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jewelry = await _context.Jewelries.FindAsync(id);
            _context.Jewelries.Remove(jewelry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JewelryExists(int id)
        {
            return _context.Jewelries.Any(e => e.jID == id);
        }
    }
}
