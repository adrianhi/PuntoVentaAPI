﻿using System;
using System.Collections.Generic;

namespace PuntoVentaAPI.Models;

public partial class CategoriaProducto
{
    public int IdCategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
