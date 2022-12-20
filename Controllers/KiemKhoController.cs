using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNhom11.Models;
using BTLNhom11.Models.Process;

namespace BTLNhom11.Controllers
{
    public class KiemKhoController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();

        public KiemKhoController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: KiemKho
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.KiemKho.Include(k => k.HangHoa).Include(k => k.Kho);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: KiemKho/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KiemKho == null)
            {
                return NotFound();
            }

            var kiemKho = await _context.KiemKho
                .Include(k => k.HangHoa)
                .Include(k => k.Kho)
                .FirstOrDefaultAsync(m => m.MaKK == id);
            if (kiemKho == null)
            {
                return NotFound();
            }

            return View(kiemKho);
        }

        // GET: KiemKho/Create
        public IActionResult Create()
        {
            ViewData["MaHH"] = new SelectList(_context.HangHoa, "MaHH", "TenHH");
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Dckho");
            var newKiemKho = "Kho001";
            var countKiemKho = _context.KiemKho.Count();
            if (countKiemKho > 0)
            {
                var MaKiemKho = _context.KiemKho.OrderByDescending(m => m.MaKK).First().MaKK;
                newKiemKho = strPro.AutoGenerateCode(MaKiemKho);
            }
            ViewBag.newID = newKiemKho;
            return View();
        }

        // POST: KiemKho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKK,NgayKK,MaHH,Makho,Sluongkk")] KiemKho kiemKho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kiemKho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHH"] = new SelectList(_context.HangHoa, "MaHH", "TenHH", kiemKho.MaHH);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Dckho", kiemKho.Makho);
            return View(kiemKho);
        }

        // GET: KiemKho/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KiemKho == null)
            {
                return NotFound();
            }

            var kiemKho = await _context.KiemKho.FindAsync(id);
            if (kiemKho == null)
            {
                return NotFound();
            }
            ViewData["MaHH"] = new SelectList(_context.HangHoa, "MaHH", "TenHH", kiemKho.MaHH);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Dckho", kiemKho.Makho);
            return View(kiemKho);
        }

        // POST: KiemKho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaKK,NgayKK,MaHH,Makho,Sluongkk")] KiemKho kiemKho)
        {
            if (id != kiemKho.MaKK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kiemKho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KiemKhoExists(kiemKho.MaKK))
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
            ViewData["MaHH"] = new SelectList(_context.HangHoa, "MaHH", "TenHH", kiemKho.MaHH);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Dckho", kiemKho.Makho);
            return View(kiemKho);
        }

        // GET: KiemKho/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KiemKho == null)
            {
                return NotFound();
            }

            var kiemKho = await _context.KiemKho
                .Include(k => k.HangHoa)
                .Include(k => k.Kho)
                .FirstOrDefaultAsync(m => m.MaKK == id);
            if (kiemKho == null)
            {
                return NotFound();
            }

            return View(kiemKho);
        }

        // POST: KiemKho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KiemKho == null)
            {
                return Problem("Entity set 'MvcMovieContext.KiemKho'  is null.");
            }
            var kiemKho = await _context.KiemKho.FindAsync(id);
            if (kiemKho != null)
            {
                _context.KiemKho.Remove(kiemKho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KiemKhoExists(string id)
        {
          return (_context.KiemKho?.Any(e => e.MaKK == id)).GetValueOrDefault();
        }
    }
}
