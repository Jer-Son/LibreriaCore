
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestDb.Models
{
    public class Editorial
    {
        [Key]
        public int IdEditorial { get; set; }
        public string? NombreEditorial { get; set;}

        /*public Editorial() { }
        public Editorial(int ideditorial,string nombre) {
        IdEditorial = ideditorial;
            NombreEditorial = nombre;
        
        }*/
        public List<Libro>? libros { get; set; }

    }
}
