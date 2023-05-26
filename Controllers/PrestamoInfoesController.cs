using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestDb.Data;
using TestDb.Models;

namespace TestDb.Controllers
{
    public class PrestamoInfoesController : Controller
    {
        private readonly TestDbContext _context;

        public PrestamoInfoesController(TestDbContext context)
        {
            _context = context;
        }

        // GET: PrestamoInfoes
        public async Task<IActionResult> Index()
        {
            var testDbContext = _context.PrestamoInfo.Include(p => p.Libro).Include(p => p.Prestamo);
            return View(await testDbContext.ToListAsync());
        }

        // GET: PrestamoInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrestamoInfo == null)
            {
                return NotFound();
            }

            var prestamoInfo = await _context.PrestamoInfo
                .Include(p => p.Libro)
                .Include(p => p.Prestamo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestamoInfo == null)
            {
                return NotFound();
            }

            return View(prestamoInfo);
        }

        // GET: PrestamoInfoes/Create
        public IActionResult Create()
        {
            ViewData["LibroId"] = new SelectList(_context.Libro, "IdLibro", "IdLibro");
            ViewData["PrestamoId"] = new SelectList(_context.Prestamo, "IdPrestamo", "IdPrestamo");
            return View();
        }

        // POST: PrestamoInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrestamoId,LibroId")] PrestamoInfo prestamoInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamoInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibroId"] = new SelectList(_context.Libro, "IdLibro", "IdLibro", prestamoInfo.LibroId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamo, "IdPrestamo", "IdPrestamo", prestamoInfo.PrestamoId);
            return View(prestamoInfo);
        }

        // GET: PrestamoInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrestamoInfo == null)
            {
                return NotFound();
            }

            var prestamoInfo = await _context.PrestamoInfo.FindAsync(id);
            if (prestamoInfo == null)
            {
                return NotFound();
            }
            ViewData["LibroId"] = new SelectList(_context.Libro, "IdLibro", "IdLibro", prestamoInfo.LibroId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamo, "IdPrestamo", "IdPrestamo", prestamoInfo.PrestamoId);
            return View(prestamoInfo);
        }

        // POST: PrestamoInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrestamoId,LibroId")] PrestamoInfo prestamoInfo)
        {
            if (id != prestamoInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamoInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoInfoExists(prestamoInfo.Id))
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
            ViewData["LibroId"] = new SelectList(_context.Libro, "IdLibro", "IdLibro", prestamoInfo.LibroId);
            ViewData["PrestamoId"] = new SelectList(_context.Prestamo, "IdPrestamo", "IdPrestamo", prestamoInfo.PrestamoId);
            return View(prestamoInfo);
        }

        // GET: PrestamoInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrestamoInfo == null)
            {
                return NotFound();
            }

            var prestamoInfo = await _context.PrestamoInfo
                .Include(p => p.Libro)
                .Include(p => p.Prestamo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestamoInfo == null)
            {
                return NotFound();
            }

            return View(prestamoInfo);
        }

        // POST: PrestamoInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrestamoInfo == null)
            {
                return Problem("Entity set 'TestDbContext.PrestamoInfo'  is null.");
            }
            var prestamoInfo = await _context.PrestamoInfo.FindAsync(id);
            if (prestamoInfo != null)
            {
                _context.PrestamoInfo.Remove(prestamoInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoInfoExists(int id)
        {
          return (_context.PrestamoInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
