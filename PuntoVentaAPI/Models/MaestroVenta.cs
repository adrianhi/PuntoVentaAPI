using System;
using System.Collections.Generic;

namespace PuntoVentaAPI.Models;

public partial class MaestroVenta
{
    public int IdVenta { get; set; }

    public int? IdTipoTransaccion { get; set; }

    public int? IdTransaccion { get; set; }

    public int? IdCliente { get; set; }

    public decimal? MontoTotal { get; set; }

    public decimal? MontoRecibido { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<DetallesVenta> DetallesVenta { get; set; } = new List<DetallesVenta>();
}
