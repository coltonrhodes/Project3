using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarTracking.Data;
using WebApplication1.Models;

namespace CarTracking.Models
{
    public class AutoPartsStoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoPartsStoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AutoPartsStores
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutoPartsStore.ToListAsync());
        }

        // GET: AutoPartsStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoPartsStore = await _context.AutoPartsStore
                .SingleOrDefaultAsync(m => m.id == id);
            if (autoPartsStore == null)
            {
                return NotFound();
            }

            return View(autoPartsStore);
        }

        // GET: AutoPartsStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutoPartsStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,StoreName,Address")] AutoPartsStore autoPartsStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoPartsStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoPartsStore);
        }

        // GET: AutoPartsStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoPartsStore = await _context.AutoPartsStore.SingleOrDefaultAsync(m => m.id == id);
            if (autoPartsStore == null)
            {
                return NotFound();
            }
            return View(autoPartsStore);
        }

        // POST: AutoPartsStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,StoreName,Address")] AutoPartsStore autoPartsStore)
        {
            if (id != autoPartsStore.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoPartsStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoPartsStoreExists(autoPartsStore.id))
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
            return View(autoPartsStore);
        }

        // GET: AutoPartsStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoPartsStore = await _context.AutoPartsStore
                .SingleOrDefaultAsync(m => m.id == id);
            if (autoPartsStore == null)
            {
                return NotFound();
            }

            return View(autoPartsStore);
        }

        // POST: AutoPartsStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoPartsStore = await _context.AutoPartsStore.SingleOrDefaultAsync(m => m.id == id);
            _context.AutoPartsStore.Remove(autoPartsStore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoPartsStoreExists(int id)
        {
            return _context.AutoPartsStore.Any(e => e.id == id);
        }
    }
}
