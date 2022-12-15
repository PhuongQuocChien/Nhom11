using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNhom11.Models;
using BaiTapNhom11.Models.Process;

namespace BTLNhom11.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();

        public NhanVienController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.NhanVien.Include(n => n.ChucVu).Include(n => n.GioiTinh).Include(n => n.QueQuan);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.ChucVu)
                .Include(n => n.GioiTinh)
                .Include(n => n.QueQuan)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            ViewData["MaChucVu"] = new SelectList(_context.ChucVu, "MaChucVu", "TenChucVu");
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "TenGioiTinh");
            ViewData["MaQueQuan"] = new SelectList(_context.QueQuan, "MaQueQuan", "TenQueQuan");
            var newnhanvien = "NV001";
            var countnhanvien = _context.NhanVien.Count();
            if (countnhanvien > 0)
            {
                var MaNhanVien = _context.NhanVien.OrderByDescending(m => m.MaNV).First().MaNV;
                newnhanvien = strPro.AutoGenerateCode(MaNhanVien);
            }
            ViewBag.newID = newnhanvien;
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,TenNV,NgaySinh,MaQueQuan,MaGioiTinh,MaChucVu,SDTNV")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChucVu"] = new SelectList(_context.ChucVu, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "TenGioiTinh", nhanVien.MaGioiTinh);
            ViewData["MaQueQuan"] = new SelectList(_context.QueQuan, "MaQueQuan", "TenQueQuan", nhanVien.MaQueQuan);
            return View(nhanVien);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            ViewData["MaChucVu"] = new SelectList(_context.ChucVu, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "TenGioiTinh", nhanVien.MaGioiTinh);
            ViewData["MaQueQuan"] = new SelectList(_context.QueQuan, "MaQueQuan", "TenQueQuan", nhanVien.MaQueQuan);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,TenNV,NgaySinh,MaQueQuan,MaGioiTinh,MaChucVu,SDTNV")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNV))
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
            ViewData["MaChucVu"] = new SelectList(_context.ChucVu, "MaChucVu", "TenChucVu", nhanVien.MaChucVu);
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "TenGioiTinh", nhanVien.MaGioiTinh);
            ViewData["MaQueQuan"] = new SelectList(_context.QueQuan, "MaQueQuan", "TenQueQuan", nhanVien.MaQueQuan);
            return View(nhanVien);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien
                .Include(n => n.ChucVu)
                .Include(n => n.GioiTinh)
                .Include(n => n.QueQuan)
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhanVien == null)
            {
                return Problem("Entity set 'MvcMovieContext.NhanVien'  is null.");
            }
            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanVien.Remove(nhanVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(string id)
        {
          return (_context.NhanVien?.Any(e => e.MaNV == id)).GetValueOrDefault();
        }
    }
}
