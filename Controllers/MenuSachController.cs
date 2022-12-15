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
    public class MenuSachController : Controller
    {
        private readonly MvcMovieContext _context;

        public MenuSachController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: MenuSach
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.MenuSach.Include(m => m.NhapSach).Include(m => m.TheLoai);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: MenuSach/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MenuSach == null)
            {
                return NotFound();
            }

            var menuSach = await _context.MenuSach
                .Include(m => m.NhapSach)
                .Include(m => m.TheLoai)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (menuSach == null)
            {
                return NotFound();
            }

            return View(menuSach);
        }

        // GET: MenuSach/Create
        public IActionResult Create()
        {
            ViewData["MaNhap"] = new SelectList(_context.NhapSach, "MaNhap", "MaHH");
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai");
            return View();
        }

        // POST: MenuSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSach,MaNhap,MaTheLoai,TacGia,GiaTien")] MenuSach menuSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNhap"] = new SelectList(_context.NhapSach, "MaNhap", "MaHH", menuSach.MaNhap);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", menuSach.MaTheLoai);
            return View(menuSach);
        }

        // GET: MenuSach/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MenuSach == null)
            {
                return NotFound();
            }

            var menuSach = await _context.MenuSach.FindAsync(id);
            if (menuSach == null)
            {
                return NotFound();
            }
            ViewData["MaNhap"] = new SelectList(_context.NhapSach, "MaNhap", "MaHH", menuSach.MaNhap);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", menuSach.MaTheLoai);
            return View(menuSach);
        }

        // POST: MenuSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSach,MaNhap,MaTheLoai,TacGia,GiaTien")] MenuSach menuSach)
        {
            if (id != menuSach.MaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuSachExists(menuSach.MaSach))
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
            ViewData["MaNhap"] = new SelectList(_context.NhapSach, "MaNhap", "MaHH", menuSach.MaNhap);
            ViewData["MaTheLoai"] = new SelectList(_context.TheLoai, "MaTheLoai", "TenTheLoai", menuSach.MaTheLoai);
            return View(menuSach);
        }

        // GET: MenuSach/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MenuSach == null)
            {
                return NotFound();
            }

            var menuSach = await _context.MenuSach
                .Include(m => m.NhapSach)
                .Include(m => m.TheLoai)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (menuSach == null)
            {
                return NotFound();
            }

            return View(menuSach);
        }

        // POST: MenuSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MenuSach == null)
            {
                return Problem("Entity set 'MvcMovieContext.MenuSach'  is null.");
            }
            var menuSach = await _context.MenuSach.FindAsync(id);
            if (menuSach != null)
            {
                _context.MenuSach.Remove(menuSach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuSachExists(string id)
        {
          return (_context.MenuSach?.Any(e => e.MaSach == id)).GetValueOrDefault();
        }
    }
}
