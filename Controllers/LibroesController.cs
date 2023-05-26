using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestDb.Data;
using TestDb.Models;
using TestDb.Services;

namespace TestDb.Controllers
{
    public class LibroesController : Controller
    {
        private LibroService LibroS;
        


        public LibroesController(LibroService LibroSe)
        {
            LibroS = LibroSe;
        }

        public ActionResult Index()
        {
            //ViewData["AutorId"] = new SelectList(LibroS.autorObj(), "Id", "Id");
            //ViewData["EditorialId"] = new SelectList(LibroS.EditorialObj(), "IdEditorial", "IdEditorial");
            return View(LibroS.listar());
        }
        /*

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libro == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }*/

        // GET: Libroes/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(LibroS.autorObj(), "Id", "Id");
            ViewData["EditorialId"] = new SelectList(LibroS.EditorialObj(), "IdEditorial", "IdEditorial");
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,Titulo,ISBN,EditorialId,AutorId")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                LibroS.Crear(libro.IdLibro,libro.Titulo,libro.ISBN,libro.EditorialId,libro.AutorId);
              
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(LibroS.autorObj(), "Id", "Id", libro.AutorId);
            ViewData["EditorialId"] = new SelectList(LibroS.EditorialObj(), "IdEditorial", "IdEditorial", libro.EditorialId);
            return View(libro);
        }
        /*
        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libro == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id", libro.AutorId);
            ViewData["EditorialId"] = new SelectList(_context.Editorial, "IdEditorial", "IdEditorial", libro.EditorialId);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,Titulo,ISBN,EditorialId,AutorId")] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IdLibro))
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
            ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "Id", libro.AutorId);
            ViewData["EditorialId"] = new SelectList(_context.Editorial, "IdEditorial", "IdEditorial", libro.EditorialId);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libro == null)
            {
                return NotFound();
            }

            var libro = await _context.Libro
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libro == null)
            {
                return Problem("Entity set 'TestDbContext.Libro'  is null.");
            }
            var libro = await _context.Libro.FindAsync(id);
            if (libro != null)
            {
                _context.Libro.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return (_context.Libro?.Any(e => e.IdLibro == id)).GetValueOrDefault();
        }*/
    }
}
