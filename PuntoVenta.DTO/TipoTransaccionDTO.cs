using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DTO
{
    public class TipoTransaccionDTO
    {
        public int IdTipoTransaccion { get; set; }

        public string? Descripcion { get; set; }

        public bool EsCredito { get; set; }

        public bool? FactCredito { get; set; }

        public bool? FactContado { get; set; }

        public bool? ReciboCobro { get; set; }
    }
}
