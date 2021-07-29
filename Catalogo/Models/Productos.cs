using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.Models
{
    public class Productos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string imagenCaratula { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public List<Imagen> Imagenes { get; set; }
    }
}
