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
    public class TheLoaiController : Controller
    {
        private readonly MvcMovieContext _context;

        public TheLoaiController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: TheLoai
        public async Task<IActionResult> Index()
        {
              return _context.TheLoai != null ? 
                          View(await _context.TheLoai.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.TheLoai'  is null.");
        }

        // GET: TheLoai/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TheLoai == null)
            {
                return NotFound();
            }

            var theLoai = await _context.TheLoai
                .FirstOrDefaultAsync(m => m.MaTheLoai == id);
            if (theLoai == null)
            {
                return NotFound();
            }

            return View(theLoai);
        }

        // GET: TheLoai/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheLoai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTheLoai,TenTheLoai")] TheLoai theLoai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theLoai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theLoai);
        }

        // GET: TheLoai/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TheLoai == null)
            {
                return NotFound();
            }

            var theLoai = await _context.TheLoai.FindAsync(id);
            if (theLoai == null)
            {
                return NotFound();
            }
            return View(theLoai);
        }

        // POST: TheLoai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTheLoai,TenTheLoai")] TheLoai theLoai)
        {
            if (id != theLoai.MaTheLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theLoai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheLoaiExists(theLoai.MaTheLoai))
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
            return View(theLoai);
        }

        // GET: TheLoai/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TheLoai == null)
            {
                return NotFound();
            }

            var theLoai = await _context.TheLoai
                .FirstOrDefaultAsync(m => m.MaTheLoai == id);
            if (theLoai == null)
            {
                return NotFound();
            }

            return View(theLoai);
        }

        // POST: TheLoai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TheLoai == null)
            {
                return Problem("Entity set 'MvcMovieContext.TheLoai'  is null.");
            }
            var theLoai = await _context.TheLoai.FindAsync(id);
            if (theLoai != null)
            {
                _context.TheLoai.Remove(theLoai);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheLoaiExists(string id)
        {
          return (_context.TheLoai?.Any(e => e.MaTheLoai == id)).GetValueOrDefault();
        }
        private ExcelProcess _excelProcess = new ExcelProcess();

        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {//Lay file va xu ly
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload");
                }
                else
                {
                    //rename file when upload to sever(đổi tên file khi upload lên sever)
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever(lưu tập tin vào máy chủ)
                        await file.CopyToAsync(stream);
                        //read data from file and write to database(đọc dữ liệu từ tệp và ghi vào cơ sở dữ liệu)
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data from dt(sử dụng vòng lặp for để đọc dữ liệu từ dt)
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            var tl = new TheLoai();
                            //set values for attributes(đặt giá trị cho thuộc tính)
                            tl.MaTheLoai = dt.Rows[i][0].ToString();
                            tl.TenTheLoai = dt.Rows[i][1].ToString();
                            //add object to context(thêm đối tượng vào ngữ cảnh)
                            _context.TheLoai.Add(tl);
                        }
                        //save to database(lưu vào cơ sở dữ liệu)
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
