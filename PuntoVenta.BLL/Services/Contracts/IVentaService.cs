using PuntoVenta.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.BLL.Services.Contracts
{
    public interface IVentaService
    {

        Task<VentaDTO> Register(VentaDTO sale);

    }
}
