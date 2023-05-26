using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDb.Models
{
    public class Lugar
    {
        [Key]
        public int IdLugar { get; set; }
        public string Nombre { get; set; }

        public Lugar() { }
       


    }
}
