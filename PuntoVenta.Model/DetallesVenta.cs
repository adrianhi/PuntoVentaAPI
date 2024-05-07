using System;
using System.Collections.Generic;

namespace PuntoVenta.Model;

public partial class DetallesVenta
{
    public int IdDetallesVentas { get; set; }

    public int? IdVenta { get; set; }

    public int? IdTransaccion { get; set; }

    public int? IdTipoTransaccion { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioVenta { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual MaestroVenta? IdVentaNavigation { get; set; }
}
