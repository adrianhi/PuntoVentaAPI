using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DTO
{
    public class ClientDTO
    {
        public int IdCliente { get; set; }

        public string? Nombre { get; set; }

        public string? Cedula { get; set; }

        public string? Direccion { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }
    }
}
