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
    public class HoaDonBanHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess strPro = new StringProcess();

        public HoaDonBanHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoaDonBanHang
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HoaDonBanHang.Include(h => h.KhachHang).Include(h => h.NhanVien).Include(h => h.Sach);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HoaDonBanHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaDonBanHang == null)
            {
                return NotFound();
            }

            var hoaDonBanHang = await _context.HoaDonBanHang
                .Include(h => h.KhachHang)
                .Include(h => h.NhanVien)
                .Include(h => h.Sach)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);
            if (hoaDonBanHang == null)
            {
                return NotFound();
            }

            return View(hoaDonBanHang);
        }

        // GET: HoaDonBanHang/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHang, "MaKhachHang", "TenKhachHang");
            ViewData["MaNhanVien"] = new SelectList(_context.NhanVien, "MaNhanVien", "HoVaTen");
            ViewData["MaSach"] = new SelectList(_context.Sach, "MaSach", "TenSach");
             var newMaHoaDon = "HD001";
            var countHoaDon = _context.HoaDonNhap.Count();
            if(countHoaDon>0)
            {
                var maHoaDon = _context.HoaDonNhap.OrderByDescending(m => m.MaHoaDonNhap).First().MaHoaDonNhap;
                newMaHoaDon = strPro.AutoGenerateCode(maHoaDon);
            }
            ViewBag.newMaHoaDon = newMaHoaDon;
            return View();
            return View();
        }

        // POST: HoaDonBanHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoaDon,MaKhachHang,MaSach,MaNhanVien,NgayLapHoaDon,TongTien")] HoaDonBanHang hoaDonBanHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonBanHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHang, "MaKhachHang", "TenKhachHang", hoaDonBanHang.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanVien, "MaNhanVien", "HoVaTen", hoaDonBanHang.MaNhanVien);
            ViewData["MaSach"] = new SelectList(_context.Sach, "MaSach", "TenSach", hoaDonBanHang.MaSach);
            return View(hoaDonBanHang);
        }

        // GET: HoaDonBanHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoaDonBanHang == null)
            {
                return NotFound();
            }

            var hoaDonBanHang = await _context.HoaDonBanHang.FindAsync(id);
            if (hoaDonBanHang == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHang, "MaKhachHang", "TenKhachHang", hoaDonBanHang.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanVien, "MaNhanVien", "HoVaTen", hoaDonBanHang.MaNhanVien);
            ViewData["MaSach"] = new SelectList(_context.Sach, "MaSach", "TenSach", hoaDonBanHang.MaSach);
            return View(hoaDonBanHang);
        }

        // POST: HoaDonBanHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHoaDon,MaKhachHang,MaSach,MaNhanVien,NgayLapHoaDon,TongTien")] HoaDonBanHang hoaDonBanHang)
        {
            if (id != hoaDonBanHang.MaHoaDon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonBanHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonBanHangExists(hoaDonBanHang.MaHoaDon))
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
            ViewData["MaKhachHang"] = new SelectList(_context.KhachHang, "MaKhachHang", "TenKhachHang", hoaDonBanHang.MaKhachHang);
            ViewData["MaNhanVien"] = new SelectList(_context.NhanVien, "MaNhanVien", "HoVaTen", hoaDonBanHang.MaNhanVien);
            ViewData["MaSach"] = new SelectList(_context.Sach, "MaSach", "TenSach", hoaDonBanHang.MaSach);
            return View(hoaDonBanHang);
        }

        // GET: HoaDonBanHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaDonBanHang == null)
            {
                return NotFound();
            }

            var hoaDonBanHang = await _context.HoaDonBanHang
                .Include(h => h.KhachHang)
                .Include(h => h.NhanVien)
                .Include(h => h.Sach)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);
            if (hoaDonBanHang == null)
            {
                return NotFound();
            }

            return View(hoaDonBanHang);
        }

        // POST: HoaDonBanHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaDonBanHang == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HoaDonBanHang'  is null.");
            }
            var hoaDonBanHang = await _context.HoaDonBanHang.FindAsync(id);
            if (hoaDonBanHang != null)
            {
                _context.HoaDonBanHang.Remove(hoaDonBanHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonBanHangExists(string id)
        {
          return (_context.HoaDonBanHang?.Any(e => e.MaHoaDon == id)).GetValueOrDefault();
        }
    }
}
