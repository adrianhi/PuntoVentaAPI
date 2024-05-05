using System;
using System.Collections.Generic;

namespace PuntoVentaAPI.Models;

public partial class Transaccione
{
    public int IdTransaccion { get; set; }

    public int? IdVenta { get; set; }

    public DateTime? Fecha { get; set; }

    public int? TipoTransaccionId { get; set; }

    public decimal? Total { get; set; }
}
