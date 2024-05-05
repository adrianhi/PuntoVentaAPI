using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PuntoVentaAPI.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public string? Estado { get; set; }

    public int? Existencia { get; set; }

    public int? Stock { get; set; }

    public int? IdCategoria { get; set; }

    [JsonIgnore]
    public virtual CategoriaProducto? IdCategoriaNavigation { get; set; }

    public static implicit operator Producto (ActionResult<Producto> v)
    {
        throw new NotImplementedException();
    }
}
