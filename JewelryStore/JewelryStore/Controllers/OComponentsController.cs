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
    public class OComponentsController : Controller
    {
        private readonly JewelryContext _context;

        public OComponentsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: OComponents
        public async Task<IActionResult> Index()
        {
            var jewelryContext = _context.OComponents.Include(o => o.provisioner);
            return View(await jewelryContext.ToListAsync());
        }

        // GET: OComponents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oComponent = await _context.OComponents
                .Include(o => o.provisioner)
                .FirstOrDefaultAsync(m => m.oID == id);
            if (oComponent == null)
            {
                return NotFound();
            }

            return View(oComponent);
        }

        // GET: OComponents/Create
        public IActionResult Create()
        {
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID");
            return View();
        }

        // POST: OComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("oID,Name,Cost,InStock,pID")] OComponent oComponent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oComponent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", oComponent.pID);
            return View(oComponent);
        }

        // GET: OComponents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oComponent = await _context.OComponents.FindAsync(id);
            if (oComponent == null)
            {
                return NotFound();
            }
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", oComponent.pID);
            return View(oComponent);
        }

        // POST: OComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("oID,Name,Cost,InStock,pID")] OComponent oComponent)
        {
            if (id != oComponent.oID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oComponent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OComponentExists(oComponent.oID))
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
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", oComponent.pID);
            return View(oComponent);
        }

        // GET: OComponents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oComponent = await _context.OComponents
                .Include(o => o.provisioner)
                .FirstOrDefaultAsync(m => m.oID == id);
            if (oComponent == null)
            {
                return NotFound();
            }

            return View(oComponent);
        }

        // POST: OComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oComponent = await _context.OComponents.FindAsync(id);
            _context.OComponents.Remove(oComponent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OComponentExists(int id)
        {
            return _context.OComponents.Any(e => e.oID == id);
        }
    }
}
