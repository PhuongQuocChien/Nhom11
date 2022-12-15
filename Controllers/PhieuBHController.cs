using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNhom11.Models;

namespace BTLNhom11.Controllers
{
    public class PhieuBHController : Controller
    {
        private readonly MvcMovieContext _context;

        public PhieuBHController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: PhieuBH
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.PhieuBH.Include(p => p.KhachHang).Include(p => p.NhanVien);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: PhieuBH/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PhieuBH == null)
            {
                return NotFound();
            }

            var phieuBH = await _context.PhieuBH
                .Include(p => p.KhachHang)
                .Include(p => p.NhanVien)
                .FirstOrDefaultAsync(m => m.MaPBH == id);
            if (phieuBH == null)
            {
                return NotFound();
            }

            return View(phieuBH);
        }

        // GET: PhieuBH/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "TenKH");
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "TenNV");
            return View();
        }

        // POST: PhieuBH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPBH,MaKH,MaNV,NgayBan,TinhTrang")] PhieuBH phieuBH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieuBH);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "TenKH", phieuBH.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "TenNV", phieuBH.MaNV);
            return View(phieuBH);
        }

        // GET: PhieuBH/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PhieuBH == null)
            {
                return NotFound();
            }

            var phieuBH = await _context.PhieuBH.FindAsync(id);
            if (phieuBH == null)
            {
                return NotFound();
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "TenKH", phieuBH.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "TenNV", phieuBH.MaNV);
            return View(phieuBH);
        }

        // POST: PhieuBH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaPBH,MaKH,MaNV,NgayBan,TinhTrang")] PhieuBH phieuBH)
        {
            if (id != phieuBH.MaPBH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuBH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuBHExists(phieuBH.MaPBH))
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
            ViewData["MaKH"] = new SelectList(_context.KhachHang, "MaKH", "TenKH", phieuBH.MaKH);
            ViewData["MaNV"] = new SelectList(_context.NhanVien, "MaNV", "TenNV", phieuBH.MaNV);
            return View(phieuBH);
        }

        // GET: PhieuBH/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PhieuBH == null)
            {
                return NotFound();
            }

            var phieuBH = await _context.PhieuBH
                .Include(p => p.KhachHang)
                .Include(p => p.NhanVien)
                .FirstOrDefaultAsync(m => m.MaPBH == id);
            if (phieuBH == null)
            {
                return NotFound();
            }

            return View(phieuBH);
        }

        // POST: PhieuBH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PhieuBH == null)
            {
                return Problem("Entity set 'MvcMovieContext.PhieuBH'  is null.");
            }
            var phieuBH = await _context.PhieuBH.FindAsync(id);
            if (phieuBH != null)
            {
                _context.PhieuBH.Remove(phieuBH);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuBHExists(string id)
        {
          return (_context.PhieuBH?.Any(e => e.MaPBH == id)).GetValueOrDefault();
        }
    }
}
