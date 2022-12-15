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
    public class NhapSachController : Controller
    {
        private readonly MvcMovieContext _context;

        public NhapSachController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: NhapSach
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.NhapSach.Include(n => n.HangHoa).Include(n => n.Kho).Include(n => n.NhaCungCap);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: NhapSach/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NhapSach == null)
            {
                return NotFound();
            }

            var nhapSach = await _context.NhapSach
                .Include(n => n.HangHoa)
                .Include(n => n.Kho)
                .Include(n => n.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaNhap == id);
            if (nhapSach == null)
            {
                return NotFound();
            }

            return View(nhapSach);
        }

        // GET: NhapSach/Create
        public IActionResult Create()
        {
            ViewData["MaHH"] = new SelectList(_context.HangHoa, "MaHH", "TenHH");
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Dckho");
            ViewData["Mancc"] = new SelectList(_context.NhaCungCap, "Mancc", "Tenncc");
            return View();
        }

        // POST: NhapSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhap,MaHH,Mancc,Makho,SoluongNhap,ngayNhap")] NhapSach nhapSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhapSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHH"] = new SelectList(_context.HangHoa, "MaHH", "TenHH", nhapSach.MaHH);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Dckho", nhapSach.Makho);
            ViewData["Mancc"] = new SelectList(_context.NhaCungCap, "Mancc", "Tenncc", nhapSach.Mancc);
            return View(nhapSach);
        }

        // GET: NhapSach/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NhapSach == null)
            {
                return NotFound();
            }

            var nhapSach = await _context.NhapSach.FindAsync(id);
            if (nhapSach == null)
            {
                return NotFound();
            }
            ViewData["MaHH"] = new SelectList(_context.HangHoa, "MaHH", "TenHH", nhapSach.MaHH);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Dckho", nhapSach.Makho);
            ViewData["Mancc"] = new SelectList(_context.NhaCungCap, "Mancc", "Tenncc", nhapSach.Mancc);
            return View(nhapSach);
        }

        // POST: NhapSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhap,MaHH,Mancc,Makho,SoluongNhap,ngayNhap")] NhapSach nhapSach)
        {
            if (id != nhapSach.MaNhap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhapSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhapSachExists(nhapSach.MaNhap))
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
            ViewData["MaHH"] = new SelectList(_context.HangHoa, "MaHH", "TenHH", nhapSach.MaHH);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Dckho", nhapSach.Makho);
            ViewData["Mancc"] = new SelectList(_context.NhaCungCap, "Mancc", "Tenncc", nhapSach.Mancc);
            return View(nhapSach);
        }

        // GET: NhapSach/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NhapSach == null)
            {
                return NotFound();
            }

            var nhapSach = await _context.NhapSach
                .Include(n => n.HangHoa)
                .Include(n => n.Kho)
                .Include(n => n.NhaCungCap)
                .FirstOrDefaultAsync(m => m.MaNhap == id);
            if (nhapSach == null)
            {
                return NotFound();
            }

            return View(nhapSach);
        }

        // POST: NhapSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NhapSach == null)
            {
                return Problem("Entity set 'MvcMovieContext.NhapSach'  is null.");
            }
            var nhapSach = await _context.NhapSach.FindAsync(id);
            if (nhapSach != null)
            {
                _context.NhapSach.Remove(nhapSach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhapSachExists(string id)
        {
          return (_context.NhapSach?.Any(e => e.MaNhap == id)).GetValueOrDefault();
        }
    }
}
