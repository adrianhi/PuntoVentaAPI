using System;
using System.Collections.Generic;

namespace PuntoVentaAPI.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int IdVenta { get; set; }

    public int IdTipoTransaccion { get; set; }

    public int? IdTransaccion { get; set; }

    public DateTime FechaEmision { get; set; }

    public int IdCliente { get; set; }

    public decimal Total { get; set; }

    public decimal TotalPagado { get; set; }

    public string EstadoPago { get; set; } = null!;
}
