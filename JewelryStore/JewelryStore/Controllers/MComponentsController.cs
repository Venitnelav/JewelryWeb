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
    public class MComponentsController : Controller
    {
        private readonly JewelryContext _context;

        public MComponentsController(JewelryContext context)
        {
            _context = context;
        }

        // GET: MComponents
        public async Task<IActionResult> Index()
        {
            var jewelryContext = _context.MComponents.Include(m => m.JType).Include(m => m.Metals).Include(m => m.provisioner);
            return View(await jewelryContext.ToListAsync());
        }

        // GET: MComponents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mComponent = await _context.MComponents
                .Include(m => m.JType)
                .Include(m => m.Metals)
                .Include(m => m.provisioner)
                .FirstOrDefaultAsync(m => m.mcID == id);
            if (mComponent == null)
            {
                return NotFound();
            }

            return View(mComponent);
        }

        // GET: MComponents/Create
        public IActionResult Create()
        {
            ViewData["jtID"] = new SelectList(_context.jTypes, "jtID", "jtID");
            ViewData["mID"] = new SelectList(_context.Metals, "mID", "mID");
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID");
            return View();
        }

        // POST: MComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mcID,Name,Cost,InStock,mID,jtID,pID")] MComponent mComponent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mComponent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["jtID"] = new SelectList(_context.jTypes, "jtID", "jtID", mComponent.jtID);
            ViewData["mID"] = new SelectList(_context.Metals, "mID", "mID", mComponent.mID);
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", mComponent.pID);
            return View(mComponent);
        }

        // GET: MComponents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mComponent = await _context.MComponents.FindAsync(id);
            if (mComponent == null)
            {
                return NotFound();
            }
            ViewData["jtID"] = new SelectList(_context.jTypes, "jtID", "jtID", mComponent.jtID);
            ViewData["mID"] = new SelectList(_context.Metals, "mID", "mID", mComponent.mID);
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", mComponent.pID);
            return View(mComponent);
        }

        // POST: MComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("mcID,Name,Cost,InStock,mID,jtID,pID")] MComponent mComponent)
        {
            if (id != mComponent.mcID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mComponent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MComponentExists(mComponent.mcID))
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
            ViewData["jtID"] = new SelectList(_context.jTypes, "jtID", "jtID", mComponent.jtID);
            ViewData["mID"] = new SelectList(_context.Metals, "mID", "mID", mComponent.mID);
            ViewData["pID"] = new SelectList(_context.Provisioners, "pID", "pID", mComponent.pID);
            return View(mComponent);
        }

        // GET: MComponents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mComponent = await _context.MComponents
                .Include(m => m.JType)
                .Include(m => m.Metals)
                .Include(m => m.provisioner)
                .FirstOrDefaultAsync(m => m.mcID == id);
            if (mComponent == null)
            {
                return NotFound();
            }

            return View(mComponent);
        }

        // POST: MComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mComponent = await _context.MComponents.FindAsync(id);
            _context.MComponents.Remove(mComponent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MComponentExists(int id)
        {
            return _context.MComponents.Any(e => e.mcID == id);
        }
    }
}
