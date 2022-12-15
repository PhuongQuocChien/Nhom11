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
    public class KhachHangController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();
        public KhachHangController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: KhachHang
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.KhachHang.Include(k => k.GioiTinh);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: KhachHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang
                .Include(k => k.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaKH == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: KhachHang/Create
        public IActionResult Create()
        {
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "MaGioiTinh");
            var newKhachHang = "KH001";
            var countKhachHang = _context.KhachHang.Count();
            if (countKhachHang > 0)
            {
                var MaKhachHang = _context.KhachHang.OrderByDescending(m => m.MaKH).First().MaKH;
                newKhachHang = strPro.AutoGenerateCode(MaKhachHang);
            }
            ViewBag.newID = newKhachHang;
            return View();
            return View();
        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKH,TenKH,MaGioiTinh,SDTKH,DiaChi")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "MaGioiTinh", khachHang.MaGioiTinh);
            return View(khachHang);
        }

        // GET: KhachHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "MaGioiTinh", khachHang.MaGioiTinh);
            return View(khachHang);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKH,TenKH,MaGioiTinh,SDTKH,DiaChi")] KhachHang khachHang)
        {
            if (id != khachHang.MaKH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.MaKH))
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
            ViewData["MaGioiTinh"] = new SelectList(_context.GioiTinh, "MaGioiTinh", "MaGioiTinh", khachHang.MaGioiTinh);
            return View(khachHang);
        }

        // GET: KhachHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhachHang == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHang
                .Include(k => k.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaKH == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhachHang == null)
            {
                return Problem("Entity set 'MvcMovieContext.KhachHang'  is null.");
            }
            var khachHang = await _context.KhachHang.FindAsync(id);
            if (khachHang != null)
            {
                _context.KhachHang.Remove(khachHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(string id)
        {
          return (_context.KhachHang?.Any(e => e.MaKH == id)).GetValueOrDefault();
        }
    }
}
