using System;
using System.Collections.Generic;

namespace PuntoVentaAPI.Models;

public partial class MaestroCliente
{
    public int IdCliente { get; set; }

    public string? Cedula { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Nombre { get; set; }
}
