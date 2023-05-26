
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestDb.Models
{
    public class Libro
    {
     [Key]
     public int IdLibro { get; set; }
     public string? Titulo { get; set; }
     public string? ISBN { get; set; }

    public Editorial? Editorial { get; set; }
    public int EditorialId { get; set; }
     
    public Autor? Autor { get; set; }
    public int AutorId { get; set; }

    public List<PrestamoInfo>? PrestamoList { get; set; }

        /* public Libro(int idlibro, string titulo,string isbn) { 

         IdLibro = idlibro;
         Titulo = titulo;
         ISBN = isbn;
     }
         //AGREGACION
     public void AgregandoEditorial(Editorial e)
         {
             Editorial = e;
         }*/
    }
}
