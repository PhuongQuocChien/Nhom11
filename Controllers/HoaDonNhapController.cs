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
    public class HoaDonNhapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoaDonNhapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoaDonNhap
        public async Task<IActionResult> Index()
        {
              return _context.HoaDonNhap != null ? 
                          View(await _context.HoaDonNhap.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HoaDonNhap'  is null.");
        }

        // GET: HoaDonNhap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaDonNhap == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhap
                .FirstOrDefaultAsync(m => m.MaHoaDonNhap == id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }

            return View(hoaDonNhap);
        }

        // GET: HoaDonNhap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoaDonNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoaDonNhap,TenHoaDonNhap,NhaCungCap,TenVatPham,SoLuong,TongTien,NgayNhap")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonNhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoaDonNhap == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhap.FindAsync(id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }
            return View(hoaDonNhap);
        }

        // POST: HoaDonNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHoaDonNhap,TenHoaDonNhap,NhaCungCap,TenVatPham,SoLuong,TongTien,NgayNhap")] HoaDonNhap hoaDonNhap)
        {
            if (id != hoaDonNhap.MaHoaDonNhap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonNhapExists(hoaDonNhap.MaHoaDonNhap))
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
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaDonNhap == null)
            {
                return NotFound();
            }

            var hoaDonNhap = await _context.HoaDonNhap
                .FirstOrDefaultAsync(m => m.MaHoaDonNhap == id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }

            return View(hoaDonNhap);
        }

        // POST: HoaDonNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaDonNhap == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HoaDonNhap'  is null.");
            }
            var hoaDonNhap = await _context.HoaDonNhap.FindAsync(id);
            if (hoaDonNhap != null)
            {
                _context.HoaDonNhap.Remove(hoaDonNhap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonNhapExists(string id)
        {
          return (_context.HoaDonNhap?.Any(e => e.MaHoaDonNhap == id)).GetValueOrDefault();
        }
    }
}
