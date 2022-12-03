using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapNhom11.Models;
using BaiTapNhom11.Models.Process;

namespace BaiTapNhom11.Controllers
{
    public class SachController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess strPro = new StringProcess();

        public SachController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sach
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sach.Include(s => s.KhoSach).Include(s => s.TheLoai);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sach/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.KhoSach)
                .Include(s => s.TheLoai)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: Sach/Create
        public IActionResult Create()
        {
            ViewData["TenSach"] = new SelectList(_context.KhoSach, "TenSach", "TenSach");
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai");
            var newsach = "SA001";
            var countsach = _context.Sach.Count();
            if (countsach > 0)
            {
                var MaSach = _context.Sach.OrderByDescending(m => m.MaSach).First().MaSach;
                newsach = strPro.AutoGenerateCode(MaSach);
            }
            ViewBag.newID = newsach;
            return View();
        }

        // POST: Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSach,TenSach,MaTheLoai,NamXuatBan,TacGia,GiaTien")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenSach"] = new SelectList(_context.KhoSach, "TenSach", "TenSach", sach.TenSach);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // GET: Sach/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["TenSach"] = new SelectList(_context.KhoSach, "TenSach", "TenSach", sach.TenSach);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // POST: Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSach,TenSach,MaTheLoai,NamXuatBan,TacGia,GiaTien")] Sach sach)
        {
            if (id != sach.MaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.MaSach))
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
            ViewData["TenSach"] = new SelectList(_context.KhoSach, "TenSach", "TenSach", sach.TenSach);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // GET: Sach/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Sach == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.KhoSach)
                .Include(s => s.TheLoai)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Sach == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sach'  is null.");
            }
            var sach = await _context.Sach.FindAsync(id);
            if (sach != null)
            {
                _context.Sach.Remove(sach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(string id)
        {
          return (_context.Sach?.Any(e => e.MaSach == id)).GetValueOrDefault();
        }
    }
}
