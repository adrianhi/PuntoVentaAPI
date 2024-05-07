using System;
using System.Collections.Generic;

namespace PuntoVenta.Model;

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

    public virtual CategoriaProducto? IdCategoriaNavigation { get; set; }
}
