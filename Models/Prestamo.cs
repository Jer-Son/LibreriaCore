using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestDb.Models
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }
        public DateTime? fechaInicio { get;set; }
        public DateTime? fechaFinal { get; set; }

        public  Usuario? Usuario { get; set; }
        public int? UsuarioId { get; set; }

        public List<PrestamoInfo>? PrestamoInfo { get; set;}
      /*  public Prestamo(int idprestamo,DateTime fechainicio,DateTime fechafinal, Usuario u)
        {
            IdPrestamo = idprestamo;
            fechaInicio = fechainicio;
            fechaFinal = fechafinal;

            //Prestamo se compone de un Usuario
            Usuario = u;
        }

        public Prestamo()
        {
     
        }*/
    }
}
