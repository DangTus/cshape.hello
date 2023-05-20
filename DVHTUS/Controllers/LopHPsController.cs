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
    public class LopHPsController : Controller
    {
        private readonly DKHPContext _context;

        public LopHPsController(DKHPContext context)
        {
            _context = context;
        }

        // GET: LopHPs
        public async Task<IActionResult> Index()
        {
              return _context.LopHP != null ? 
                          View(await _context.LopHP.ToListAsync()) :
                          Problem("Entity set 'DKHPContext.LopHP'  is null.");
        }

        // GET: LopHPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LopHP == null)
            {
                return NotFound();
            }

            var lopHP = await _context.LopHP
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lopHP == null)
            {
                return NotFound();
            }

            return View(lopHP);
        }

        // GET: LopHPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LopHPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenLopHP,Khoa,SoLuong")] LopHP lopHP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHP);
        }

        // GET: LopHPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LopHP == null)
            {
                return NotFound();
            }

            var lopHP = await _context.LopHP.FindAsync(id);
            if (lopHP == null)
            {
                return NotFound();
            }
            return View(lopHP);
        }

        // POST: LopHPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenLopHP,Khoa,SoLuong")] LopHP lopHP)
        {
            if (id != lopHP.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHPExists(lopHP.ID))
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
            return View(lopHP);
        }

        // GET: LopHPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LopHP == null)
            {
                return NotFound();
            }

            var lopHP = await _context.LopHP
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lopHP == null)
            {
                return NotFound();
            }

            return View(lopHP);
        }

        // POST: LopHPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LopHP == null)
            {
                return Problem("Entity set 'DKHPContext.LopHP'  is null.");
            }
            var lopHP = await _context.LopHP.FindAsync(id);
            if (lopHP != null)
            {
                _context.LopHP.Remove(lopHP);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHPExists(int id)
        {
          return (_context.LopHP?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
