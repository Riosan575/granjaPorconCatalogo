using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Models
{
    public class Imagen
    {
        public int id { get; set; }
        public string ruta { get; set; }
        public int idProductos { get; set; }
    }
}
