using Microsoft.EntityFrameworkCore;

using TestDb.Models;

namespace TestDb.Data
{
    public class LibroRespository
    {
        private readonly TestDbContext _context;

        public LibroRespository(TestDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Libro> Libros()
        {
            return _context.Libro.ToList();
        }
        
        public bool CreateLibro(Libro LibroToCreate)
        {
            try
            {
                _context.Libro.Add(LibroToCreate);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DbSet<Autor> autorObj()
        {
            return _context.Autor;
        }
        public DbSet<Editorial> EditorialObj()
        {
            return _context.Editorial;
        }
        public DbSet<Libro> libroObj()
        {
            return _context.Libro;
        }
        public bool LibroExist(int id)
        {
            return (_context.Libro?.Any(e => e.IdLibro == id)).GetValueOrDefault();
        }
    }
}
