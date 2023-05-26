using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestDb.Models
{
    public class Pais : Lugar
    {
        public char[] Iniciales = new char[3];

        public List<Nacionalidad>? NacionalidadList { get; set; }

        public string convertirIniciales()
        {
            string s = new string(Iniciales);
            return s;
        }

    }
}
