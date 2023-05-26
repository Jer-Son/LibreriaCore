using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDb.Models;

namespace TestDb.Data
{
    public class AutorRepository
    {

        private readonly TestDbContext _context;

        public AutorRepository(TestDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Autor> ListAutor()
        {
            return _context.Autor.ToList();
        }
        public bool CreateAutor(Autor AutorToCreate)
        {
            try
            {
                _context.Autor.Add(AutorToCreate);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<Autor> Details(int? id)
        {
 
            var autor = await _context.Autor
                .FirstOrDefaultAsync(m => m.Id == id);

            
            return (autor);
        }
        public async Task<Autor> Edit(int? id)
        {
           

            var autor = await _context.Autor.FindAsync(id);
           
            return (autor);
        }
        public bool Edit(int id, [Bind("Id,NombreAutor")] Autor autor)
        {


            try
            {
                _context.Update(autor);
                 _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public Autor Delete(int? id)
        {


            var autor =  _context.Autor.FindAsync(id);
            Autor autor1 = new Autor();
               autor1.Id= autor.Result.Id;
            autor1.NombreAutor = autor.Result.NombreAutor;

            return (autor1);
        }
        public void DeleteConfirmed(int id)
        {
            var autor = _context.Autor.FindAsync(id);
            Autor autor1 = new Autor();
            autor1.Id = autor.Result.Id;
            autor1.NombreAutor = autor.Result.NombreAutor; 

         
                _context.Autor.Remove(autor1);

            

             _context.SaveChanges();
           
        }

        public bool AutorExists(int id)
        {
            return (_context.Autor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
