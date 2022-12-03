using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapNhom11.Models;

namespace BaiTapNhom11.Controllers
{
    public class KhoSachController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhoSachController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KhoSach
        public async Task<IActionResult> Index()
        {
              return _context.KhoSach != null ? 
                          View(await _context.KhoSach.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.KhoSach'  is null.");
        }

        // GET: KhoSach/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KhoSach == null)
            {
                return NotFound();
            }

            var khoSach = await _context.KhoSach
                .FirstOrDefaultAsync(m => m.TenSach == id);
            if (khoSach == null)
            {
                return NotFound();
            }

            return View(khoSach);
        }

        // GET: KhoSach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenSach,NgayNhap,DaBan,ConLai")] KhoSach khoSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoSach);
        }

        // GET: KhoSach/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhoSach == null)
            {
                return NotFound();
            }

            var khoSach = await _context.KhoSach.FindAsync(id);
            if (khoSach == null)
            {
                return NotFound();
            }
            return View(khoSach);
        }

        // POST: KhoSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TenSach,NgayNhap,DaBan,ConLai")] KhoSach khoSach)
        {
            if (id != khoSach.TenSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoSachExists(khoSach.TenSach))
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
            return View(khoSach);
        }

        // GET: KhoSach/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhoSach == null)
            {
                return NotFound();
            }

            var khoSach = await _context.KhoSach
                .FirstOrDefaultAsync(m => m.TenSach == id);
            if (khoSach == null)
            {
                return NotFound();
            }

            return View(khoSach);
        }

        // POST: KhoSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhoSach == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KhoSach'  is null.");
            }
            var khoSach = await _context.KhoSach.FindAsync(id);
            if (khoSach != null)
            {
                _context.KhoSach.Remove(khoSach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoSachExists(string id)
        {
          return (_context.KhoSach?.Any(e => e.TenSach == id)).GetValueOrDefault();
        }
    }
}
