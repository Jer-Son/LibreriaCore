using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDb.Data;
using TestDb.Models;

namespace TestDb.Services
{
    public class AutorService
    {

        private readonly AutorRepository AutorRepository;
        public AutorService(AutorRepository AutorRepository)
        {
            this.AutorRepository = AutorRepository;
        }

        public IEnumerable<Autor> listar()
        {
            return AutorRepository.ListAutor();
        }
        public void Crear(int id, string name)
        {
            Autor autor = new Autor();


            if (name == null)
                throw new Exception("Nombre invalido");
          
            else if (
            AutorRepository.AutorExists(id))
                throw new Exception("id repetido");
            autor.Id = id;
            autor.NombreAutor = name;
    
            AutorRepository.CreateAutor(autor);

        }
        public Autor Details(int? id)
        {
            if (id == null || AutorRepository.AutorExists == null)
            {
                return null;
            }

            var autor = AutorRepository.Details(id);
            if (autor == null)
            {
                return null;
            }
            Autor autor1 = new Autor();
            autor1.Id = autor.Result.Id;
            autor1.NombreAutor = autor.Result.NombreAutor;
            
            return autor1;
        }
        public Autor Edit(int? id)
        {
            if (id == null || AutorRepository.AutorExists== null)
            {
                return null;
            }

            var autor =  AutorRepository.Edit(id);
            if (autor == null)
            {
                return null;
            }
            Autor autor1 = new Autor();
            autor1.Id = autor.Result.Id;
            autor1.NombreAutor = autor.Result.NombreAutor;
            return autor1;
        }
        public void Edit(int id, [Bind("Id,NombreAutor")] Autor autor)
        {
            if (id != autor.Id)
            {
                throw new Exception("Id invalido");

            }


            try
                {
                   AutorRepository.Edit(id, autor);
                }
                catch (DbUpdateConcurrencyException)
                {
                throw new Exception("Concurrencia");


            }

        }
        public Boolean DeleteConfirmed(int id)
        {
            if ( AutorRepository.AutorExists == null)
            {
                return false;
            }
            AutorRepository.DeleteConfirmed(id);
            return true;
        }


    }
}
