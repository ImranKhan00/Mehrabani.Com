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
    public class SellerTypeController : Controller
    {
        private readonly DataContext _context;

        public SellerTypeController(DataContext context)
        {
            _context = context;
        }

        // GET: SellerType
        public async Task<IActionResult> Index()
        {
            return View(await _context.SellerType.ToListAsync());
        }

        // GET: SellerType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSellerType = await _context.SellerType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cSellerType == null)
            {
                return NotFound();
            }

            return View(cSellerType);
        }

        // GET: SellerType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellerType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] cSellerType cSellerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cSellerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cSellerType);
        }

        // GET: SellerType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSellerType = await _context.SellerType.FindAsync(id);
            if (cSellerType == null)
            {
                return NotFound();
            }
            return View(cSellerType);
        }

        // POST: SellerType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] cSellerType cSellerType)
        {
            if (id != cSellerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cSellerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cSellerTypeExists(cSellerType.Id))
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
            return View(cSellerType);
        }

        // GET: SellerType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cSellerType = await _context.SellerType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cSellerType == null)
            {
                return NotFound();
            }

            return View(cSellerType);
        }

        // POST: SellerType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cSellerType = await _context.SellerType.FindAsync(id);
            _context.SellerType.Remove(cSellerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cSellerTypeExists(int id)
        {
            return _context.SellerType.Any(e => e.Id == id);
        }
    }
}
