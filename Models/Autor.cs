using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDb.Models
{
    public class Autor

    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NombreAutor { get; set; }

        //ASOCIACION
        /*public void Nacionalidad(int idnacionalidad, string gentilicio, int idLugar,
            string nombre, Boolean documento, char[] iniciales, int idLugarp, string nombrep)
        {
            nacionalidad = new Nacionalidad(idnacionalidad, gentilicio, idLugar, nombre, documento, iniciales, idLugarp, nombrep);
        }*/

        public List<Libro>? libros {  get; set; }
    }
}
