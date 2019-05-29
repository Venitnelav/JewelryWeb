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
    public class ProvisionersController : Controller
    {
        private readonly JewelryContext _context;

        public ProvisionersController(JewelryContext context)
        {
            _context = context;
        }

        // GET: Provisioners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Provisioners.ToListAsync());
        }

        // GET: Provisioners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provisioner = await _context.Provisioners
                .FirstOrDefaultAsync(m => m.pID == id);
            if (provisioner == null)
            {
                return NotFound();
            }

            return View(provisioner);
        }

        // GET: Provisioners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provisioners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pID,Name,TelNumber")] Provisioner provisioner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provisioner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provisioner);
        }

        // GET: Provisioners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provisioner = await _context.Provisioners.FindAsync(id);
            if (provisioner == null)
            {
                return NotFound();
            }
            return View(provisioner);
        }

        // POST: Provisioners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pID,Name,TelNumber")] Provisioner provisioner)
        {
            if (id != provisioner.pID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provisioner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvisionerExists(provisioner.pID))
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
            return View(provisioner);
        }

        // GET: Provisioners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provisioner = await _context.Provisioners
                .FirstOrDefaultAsync(m => m.pID == id);
            if (provisioner == null)
            {
                return NotFound();
            }

            return View(provisioner);
        }

        // POST: Provisioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provisioner = await _context.Provisioners.FindAsync(id);
            _context.Provisioners.Remove(provisioner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvisionerExists(int id)
        {
            return _context.Provisioners.Any(e => e.pID == id);
        }
    }
}
