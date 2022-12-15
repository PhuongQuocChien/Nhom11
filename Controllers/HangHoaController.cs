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
    public class HangHoaController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();

        public HangHoaController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: HangHoa
        public async Task<IActionResult> Index()
        {
              return _context.HangHoa != null ? 
                          View(await _context.HangHoa.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.HangHoa'  is null.");
        }

        // GET: HangHoa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HangHoa == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoa
                .FirstOrDefaultAsync(m => m.MaHH == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: HangHoa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HangHoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHH,TenHH,GiaVonHH,GiaBanHH")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangHoa);
        }

        // GET: HangHoa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HangHoa == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoa.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            return View(hangHoa);
        }

        // POST: HangHoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHH,TenHH,GiaVonHH,GiaBanHH")] HangHoa hangHoa)
        {
            if (id != hangHoa.MaHH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.MaHH))
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
            return View(hangHoa);
        }

        // GET: HangHoa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HangHoa == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoa
                .FirstOrDefaultAsync(m => m.MaHH == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // POST: HangHoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HangHoa == null)
            {
                return Problem("Entity set 'MvcMovieContext.HangHoa'  is null.");
            }
            var hangHoa = await _context.HangHoa.FindAsync(id);
            if (hangHoa != null)
            {
                _context.HangHoa.Remove(hangHoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangHoaExists(string id)
        {
          return (_context.HangHoa?.Any(e => e.MaHH == id)).GetValueOrDefault();
        }
    }
}
