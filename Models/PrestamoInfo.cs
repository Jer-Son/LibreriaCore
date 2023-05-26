
using System.ComponentModel.DataAnnotations;

namespace TestDb.Models
{
    public class PrestamoInfo
    {

        [Key]
        public int Id { get; set; }

        public Prestamo? Prestamo { get; set; }

        public int? PrestamoId { get; set;}

        public Libro? Libro { get; set; }
        public int? LibroId { get;set;}
    }
}
