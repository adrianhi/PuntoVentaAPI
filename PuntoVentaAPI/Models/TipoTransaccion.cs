using System;
using System.Collections.Generic;

namespace PuntoVentaAPI.Models;

public partial class TipoTransaccion
{
    public int IdTipoTransaccion { get; set; }

    public string? Descripcion { get; set; }

    public bool EsCredito { get; set; }

    public bool? FactCredito { get; set; }

    public bool? FactContado { get; set; }

    public bool? ReciboCobro { get; set; }
}
