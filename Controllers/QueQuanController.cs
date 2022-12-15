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
    public class QueQuanController : Controller
    {
        private readonly MvcMovieContext _context;

        public QueQuanController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: QueQuan
        public async Task<IActionResult> Index()
        {
              return _context.QueQuan != null ? 
                          View(await _context.QueQuan.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.QueQuan'  is null.");
        }

        // GET: QueQuan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.QueQuan == null)
            {
                return NotFound();
            }

            var queQuan = await _context.QueQuan
                .FirstOrDefaultAsync(m => m.MaQueQuan == id);
            if (queQuan == null)
            {
                return NotFound();
            }

            return View(queQuan);
        }

        // GET: QueQuan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QueQuan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaQueQuan,TenQueQuan")] QueQuan queQuan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(queQuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(queQuan);
        }

        // GET: QueQuan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.QueQuan == null)
            {
                return NotFound();
            }

            var queQuan = await _context.QueQuan.FindAsync(id);
            if (queQuan == null)
            {
                return NotFound();
            }
            return View(queQuan);
        }

        // POST: QueQuan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaQueQuan,TenQueQuan")] QueQuan queQuan)
        {
            if (id != queQuan.MaQueQuan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(queQuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QueQuanExists(queQuan.MaQueQuan))
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
            return View(queQuan);
        }

        // GET: QueQuan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.QueQuan == null)
            {
                return NotFound();
            }

            var queQuan = await _context.QueQuan
                .FirstOrDefaultAsync(m => m.MaQueQuan == id);
            if (queQuan == null)
            {
                return NotFound();
            }

            return View(queQuan);
        }

        // POST: QueQuan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.QueQuan == null)
            {
                return Problem("Entity set 'MvcMovieContext.QueQuan'  is null.");
            }
            var queQuan = await _context.QueQuan.FindAsync(id);
            if (queQuan != null)
            {
                _context.QueQuan.Remove(queQuan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QueQuanExists(string id)
        {
          return (_context.QueQuan?.Any(e => e.MaQueQuan == id)).GetValueOrDefault();
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
            {
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
                        //save file to sever
                        await file.CopyToAsync(stream);
                        //read data from file and write to database(đọc dữ liệu từ tệp và ghi vào cơ sở dữ liệu)
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data from dt(sử dụng vòng lặp for để đọc dữ liệu từ dt)
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            var qq = new QueQuan();
                            //set values for attributes(đặt giá trị cho thuộc tính)
                            qq.MaQueQuan = dt.Rows[i][0].ToString();
                            qq.TenQueQuan = dt.Rows[i][1].ToString();
                            //add object to context(thêm đối tượng vào ngữ cảnh)
                            _context.QueQuan.Add(qq);
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
