using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data.Modelos
{
    public class Libro
    {
        public int Id { get; set; } // entity framawork por lo general ya la coloca id como llave primaria
        public string Nombre { get; set; }

        public int anio { get; set; }

        public Editorial Editorial { get; set; }

    }
}
