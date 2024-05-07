using PuntoVenta.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.BLL.Services.Contracts
{
    public interface IClientService
    {
        Task<List<ClientDTO>> List ( );

       
        Task<ClientDTO> Create (ClientDTO client);

        Task<bool> Edit (ClientDTO client);

        Task<bool> Delete (int id);
    }
}
