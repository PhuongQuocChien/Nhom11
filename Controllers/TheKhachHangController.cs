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
    public class TheKhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheKhachHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TheKhachHang
        public async Task<IActionResult> Index()
        {
              return _context.TheKhachHang != null ? 
                          View(await _context.TheKhachHang.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TheKhachHang'  is null.");
        }

        // GET: TheKhachHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TheKhachHang == null)
            {
                return NotFound();
            }

            var theKhachHang = await _context.TheKhachHang
                .FirstOrDefaultAsync(m => m.MaThe == id);
            if (theKhachHang == null)
            {
                return NotFound();
            }

            return View(theKhachHang);
        }

        // GET: TheKhachHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheKhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThe,MauThe")] TheKhachHang theKhachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theKhachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theKhachHang);
        }

        // GET: TheKhachHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TheKhachHang == null)
            {
                return NotFound();
            }

            var theKhachHang = await _context.TheKhachHang.FindAsync(id);
            if (theKhachHang == null)
            {
                return NotFound();
            }
            return View(theKhachHang);
        }

        // POST: TheKhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaThe,MauThe")] TheKhachHang theKhachHang)
        {
            if (id != theKhachHang.MaThe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theKhachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheKhachHangExists(theKhachHang.MaThe))
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
            return View(theKhachHang);
        }

        // GET: TheKhachHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TheKhachHang == null)
            {
                return NotFound();
            }

            var theKhachHang = await _context.TheKhachHang
                .FirstOrDefaultAsync(m => m.MaThe == id);
            if (theKhachHang == null)
            {
                return NotFound();
            }

            return View(theKhachHang);
        }

        // POST: TheKhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TheKhachHang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TheKhachHang'  is null.");
            }
            var theKhachHang = await _context.TheKhachHang.FindAsync(id);
            if (theKhachHang != null)
            {
                _context.TheKhachHang.Remove(theKhachHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheKhachHangExists(string id)
        {
          return (_context.TheKhachHang?.Any(e => e.MaThe == id)).GetValueOrDefault();
        }
    }
}
