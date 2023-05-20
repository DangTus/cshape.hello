using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DVHTUS.Data;
using DVHTUS.Models;

namespace DVHTUS.Controllers
{
    public class DangKyHocPhansController : Controller
    {
        private readonly DKHPContext _context;

        public DangKyHocPhansController(DKHPContext context)
        {
            _context = context;
        }

        // GET: DangKyHocPhans
        public async Task<IActionResult> Index()
        {
            var dKHPContext = _context.DangKyHocPhan.Include(d => d.LopHP).Include(d => d.SinhVien);
            return View(await dKHPContext.ToListAsync());
        }

        // GET: DangKyHocPhans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DangKyHocPhan == null)
            {
                return NotFound();
            }

            var dangKyHocPhan = await _context.DangKyHocPhan
                .Include(d => d.LopHP)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dangKyHocPhan == null)
            {
                return NotFound();
            }

            return View(dangKyHocPhan);
        }

        // GET: DangKyHocPhans/Create
        public IActionResult Create()
        {
            ViewData["LopHPID"] = new SelectList(_context.LopHP, "ID", "TenLopHP");
            ViewData["SinhVienID"] = new SelectList(_context.SinhVien, "Id", "HoTen");
            return View();
        }

        // POST: DangKyHocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NgayDangKy,SinhVienID,LopHPID")] DangKyHocPhan dangKyHocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangKyHocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LopHPID"] = new SelectList(_context.LopHP, "ID", "ID", dangKyHocPhan.LopHPID);
            ViewData["SinhVienID"] = new SelectList(_context.SinhVien, "Id", "Id", dangKyHocPhan.SinhVienID);
            return View(dangKyHocPhan);
        }

        // GET: DangKyHocPhans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DangKyHocPhan == null)
            {
                return NotFound();
            }

            var dangKyHocPhan = await _context.DangKyHocPhan.FindAsync(id);
            if (dangKyHocPhan == null)
            {
                return NotFound();
            }
            ViewData["LopHPID"] = new SelectList(_context.LopHP, "ID", "TenLopHP", dangKyHocPhan.LopHPID);
            ViewData["SinhVienID"] = new SelectList(_context.SinhVien, "Id", "HoTen", dangKyHocPhan.SinhVienID);
            return View(dangKyHocPhan);
        }

        // POST: DangKyHocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NgayDangKy,SinhVienID,LopHPID")] DangKyHocPhan dangKyHocPhan)
        {
            if (id != dangKyHocPhan.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangKyHocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangKyHocPhanExists(dangKyHocPhan.ID))
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
            ViewData["LopHPID"] = new SelectList(_context.LopHP, "ID", "ID", dangKyHocPhan.LopHPID);
            ViewData["SinhVienID"] = new SelectList(_context.SinhVien, "Id", "Id", dangKyHocPhan.SinhVienID);
            return View(dangKyHocPhan);
        }

        // GET: DangKyHocPhans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DangKyHocPhan == null)
            {
                return NotFound();
            }

            var dangKyHocPhan = await _context.DangKyHocPhan
                .Include(d => d.LopHP)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dangKyHocPhan == null)
            {
                return NotFound();
            }

            return View(dangKyHocPhan);
        }

        // POST: DangKyHocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DangKyHocPhan == null)
            {
                return Problem("Entity set 'DKHPContext.DangKyHocPhan'  is null.");
            }
            var dangKyHocPhan = await _context.DangKyHocPhan.FindAsync(id);
            if (dangKyHocPhan != null)
            {
                _context.DangKyHocPhan.Remove(dangKyHocPhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangKyHocPhanExists(int id)
        {
          return (_context.DangKyHocPhan?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
