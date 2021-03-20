using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MehrabaniCom.Data;
using MehrabaniCom.Models;

namespace MehrabaniCom.Controllers
{
    public class RatingController : Controller
    {
        private readonly DataContext _context;

        public RatingController(DataContext context)
        {
            _context = context;
        }

        // GET: Rating
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ratings.ToListAsync());
        }

        // GET: Rating/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRatings = await _context.Ratings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cRatings == null)
            {
                return NotFound();
            }

            return View(cRatings);
        }

        // GET: Rating/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rating/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Date,StarCount")] cRatings cRatings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cRatings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cRatings);
        }

        // GET: Rating/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRatings = await _context.Ratings.FindAsync(id);
            if (cRatings == null)
            {
                return NotFound();
            }
            return View(cRatings);
        }

        // POST: Rating/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Date,StarCount")] cRatings cRatings)
        {
            if (id != cRatings.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cRatings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cRatingsExists(cRatings.ID))
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
            return View(cRatings);
        }

        // GET: Rating/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cRatings = await _context.Ratings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cRatings == null)
            {
                return NotFound();
            }

            return View(cRatings);
        }

        // POST: Rating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cRatings = await _context.Ratings.FindAsync(id);
            _context.Ratings.Remove(cRatings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cRatingsExists(int id)
        {
            return _context.Ratings.Any(e => e.ID == id);
        }
    }
}
