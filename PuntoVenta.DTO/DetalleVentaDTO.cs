using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DTO
{
    public class DetalleVentaDTO
    {
        public int IdDetallesVentas { get; set; }

        public int? ProductoId { get; set; }

        public string? IdTipoTransaccion { get; set; }

        public string? IdTransaccion { get; set; }
       
        public string? PrecioUnitario { get; set; }
        public int Cantidad { get; set; }


    }
}
