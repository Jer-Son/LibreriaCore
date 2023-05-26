using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 namespace TestDb.Models
{
    public class Ciudad: Lugar
    {
       public string Gentilicio { get; set; }
        public List<Nacionalidad>? Nacionalidads { get; set; }


    }
}
