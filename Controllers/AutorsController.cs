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
    public class AutorsController : Controller
    {
       

        private AutorService AutorS;



        public AutorsController(AutorService AutorSe)
        {
            AutorS = AutorSe;
        }

        public ActionResult Index()
        {
            return View(AutorS.listar());
        }

        // GET: Autors/Details/5
        public ActionResult Details(int? id)
        {

            Autor autor = AutorS.Details(id);
            return View(autor);
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreAutor")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                AutorS.Crear(autor.Id, autor.NombreAutor);
              
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }
        

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Autor autor = AutorS.Edit(id);

          
            return View(autor);
        }
        

        // POST: Autors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreAutor")] Autor autor)
        {
           

            if (ModelState.IsValid)
            {
                AutorS.Edit(id, autor);
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autors/Delete/5
        public ActionResult Delete(int? id)
        {
            Autor autor = AutorS.Edit(id);


            return View(autor);
        }

        
        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutorS.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }
        /*
        private bool AutorExists(int id)
        {
          return (_context.Autor?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}
