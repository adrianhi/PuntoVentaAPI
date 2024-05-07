using System;
using System.Collections.Generic;

namespace PuntoVenta.Model;

public partial class DetallesCtasxcobrar
{
    public int IdDetalleCxC { get; set; }

    public int IdCxC { get; set; }

    public int IdTransaccion { get; set; }

    public int IdTipoTransaccion { get; set; }

    public int RefIdTransaccion { get; set; }

    public string Estado { get; set; } = null!;

    public decimal Balance { get; set; }

    public decimal MontoAbonado { get; set; }

    public DateTime Fecha { get; set; }
}
