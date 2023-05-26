using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestDb.Models
{
    public class Nacionalidad
      
    {
        [Key]
        public int IdNacionalidad { get; set; }
        public Pais? Pais { get; set; }
        public int? PaisId { get; set; }
        public Boolean DocumentoNacional { get; set; }

        public Ciudad? ciudad { get; set; }
        public int? CiudadId { get; set; }

        List<Autor>?Autors { get; set; }

       /* public Nacionalidad(int idnacionalidad,string gentilicio, int idLugar, 
            string nombre,Boolean documento, char[] iniciales, int idLugarp, string nombrep)
        {
            //COMPOSICION
            IdNacionalidad = idnacionalidad;
            ciudad = new Ciudad(gentilicio,idLugar,nombre);
            Pais = new Pais(iniciales, idLugarp, nombrep);
            DocumentoNacional = documento;
        }*/
        

    }
}
