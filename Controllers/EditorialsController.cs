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
    public class EditorialsController : Controller
    {
        private EditorialService editorialS;



        public EditorialsController(EditorialService editoriales)
        {
            editorialS = editoriales;
        }

        public ActionResult Index()
        {
            return View(editorialS.listar());
        }

        // GET: Editorials
       /* public async Task<IActionResult> Index()
        {
              return _context.Editorial != null ? 
                          View(await _context.Editorial.ToListAsync()) :
                          Problem("Entity set 'TestDbContext.Editorial'  is null.");
        }

        // GET: Editorials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Editorial == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial
                .FirstOrDefaultAsync(m => m.IdEditorial == id);
            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }
       */

        // GET: Editorials/Create
        public IActionResult Create()
        {
            return View();
        }
        

        // POST: Editorials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEditorial,NombreEditorial")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                editorialS.Crear(editorial.IdEditorial,editorial.NombreEditorial);
                
                return RedirectToAction(nameof(Index));
            }
            return View(editorial);
        }
        /*
        // GET: Editorials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Editorial == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }
            return View(editorial);
        }

        // POST: Editorials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEditorial,NombreEditorial")] Editorial editorial)
        {
            if (id != editorial.IdEditorial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialExists(editorial.IdEditorial))
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
            return View(editorial);
        }

        // GET: Editorials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Editorial == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial
                .FirstOrDefaultAsync(m => m.IdEditorial == id);
            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        // POST: Editorials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Editorial == null)
            {
                return Problem("Entity set 'TestDbContext.Editorial'  is null.");
            }
            var editorial = await _context.Editorial.FindAsync(id);
            if (editorial != null)
            {
                _context.Editorial.Remove(editorial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialExists(int id)
        {
          return (_context.Editorial?.Any(e => e.IdEditorial == id)).GetValueOrDefault();
        }*/
    }
}
