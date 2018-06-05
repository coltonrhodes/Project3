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
    public class CarPartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarPartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarParts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarParts.ToListAsync());
        }

        // GET: CarParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carParts = await _context.CarParts
                .SingleOrDefaultAsync(m => m.id == id);
            if (carParts == null)
            {
                return NotFound();
            }

            return View(carParts);
        }

        // GET: CarParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,PartNumber,PartName,VehicleBrand")] CarParts carParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carParts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carParts);
        }

        // GET: CarParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carParts = await _context.CarParts.SingleOrDefaultAsync(m => m.id == id);
            if (carParts == null)
            {
                return NotFound();
            }
            return View(carParts);
        }

        // POST: CarParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,PartNumber,PartName,VehicleBrand")] CarParts carParts)
        {
            if (id != carParts.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carParts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarPartsExists(carParts.id))
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
            return View(carParts);
        }

        // GET: CarParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carParts = await _context.CarParts
                .SingleOrDefaultAsync(m => m.id == id);
            if (carParts == null)
            {
                return NotFound();
            }

            return View(carParts);
        }

        // POST: CarParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carParts = await _context.CarParts.SingleOrDefaultAsync(m => m.id == id);
            _context.CarParts.Remove(carParts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarPartsExists(int id)
        {
            return _context.CarParts.Any(e => e.id == id);
        }
    }
}
