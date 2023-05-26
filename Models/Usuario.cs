using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestDb.Models
{
    public class Usuario

    {

        public int Id { get; set; }

        public int? Telefono { get; set; }

        List<Prestamo>? Prestamos { get; set; }
    }
}
