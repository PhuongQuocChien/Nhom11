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
    public class QueQuanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess strPro = new StringProcess();
        private ExcelProcess _excelProcess = new ExcelProcess();

        public QueQuanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QueQuan
        public async Task<IActionResult> Index()
        {
              return _context.QueQuan != null ? 
                          View(await _context.QueQuan.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QueQuan'  is null.");
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
            var newMaQueQuan = "QQ001";
            var countQueQuan = _context.QueQuan.Count();
            if (countQueQuan>0)
            {
                var maQueQuan = _context.QueQuan.OrderByDescending(m => m.MaQueQuan).First().MaQueQuan;
                newMaQueQuan = strPro.AutoGenerateCode(maQueQuan);
            }
            ViewBag.newMaQueQuan = newMaQueQuan;
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
                return Problem("Entity set 'ApplicationDbContext.QueQuan'  is null.");
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
                    //rename file when upload to sever
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data from dt
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            var qq = new QueQuan();
                            //set values for attributes
                            qq.MaQueQuan = dt.Rows[i][0].ToString();
                            qq.TenQueQuan = dt.Rows[i][1].ToString();
                            //add object to context
                            _context.QueQuan.Add(qq);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
