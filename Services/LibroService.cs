using Microsoft.EntityFrameworkCore;
using TestDb.Data;
using TestDb.Migrations;
using TestDb.Models;

namespace TestDb.Services
{
    public class LibroService
    {
        private readonly LibroRespository LibroRepository;
        public LibroService(LibroRespository LibroRepository)
        {
            this.LibroRepository = LibroRepository;
        }
        public DbSet<Autor> autorObj()
        {
            return LibroRepository.autorObj();
        }

        public DbSet<Editorial> EditorialObj()
        {
            return LibroRepository.EditorialObj();
        }

        public List <Libro> listar()
        {
            var testDbContext = LibroRepository.libroObj().Include(l => l.Autor).Include(l => l.Editorial);
            return testDbContext.ToList();
           
        }
        public void Crear(int id, string titulo,string isbn,int IdEditorial,int IdAutor)
        {
            Libro libro = new Libro();


            if (titulo == null)
                throw new Exception("Nombre invalido");
           else if (isbn== null)
                throw new Exception("isbn invalido");
           else if (IdEditorial == null)
                throw new Exception("Editorial invalido");
            else if (IdAutor == null)
                throw new Exception("Autor invalido");
            else if (
           LibroRepository.LibroExist(id))
                throw new Exception("id repetido");
            libro.IdLibro= id;
            libro.Titulo= titulo;
            libro.ISBN = isbn;
            libro.EditorialId= IdEditorial;
            libro.AutorId= IdAutor;

            LibroRepository.CreateLibro(libro);

        }
        
    }
}
