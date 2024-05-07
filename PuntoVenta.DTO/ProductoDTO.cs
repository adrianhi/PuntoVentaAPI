using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        
        public int? IdCategoria { get; set; }

        public string? PrecioVenta { get; set; }
     

        public string? Estado { get; set; }

        public int? Existencia { get; set; }

    }
}
