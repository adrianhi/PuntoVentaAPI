using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PuntoVenta.DTO
{
    public class VentaDTO
    {
        public int IdVenta { get; set; }

        public string? IdTipoTransaccion { get; set; }

        public string? IdTransaccion { get; set; }

        public string?  IdCliente { get; set; }

        public string? MontoTotalTexto { get; set; }

        public string? MontoRecibidoTexto { get; set; }

        public DateTime? Fecha { get; set; }
        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; }

    }
}
