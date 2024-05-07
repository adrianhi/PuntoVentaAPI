using PuntoVenta.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.BLL.Services.Contracts
{
    public interface IProductService
    {
        Task<List<ProductoDTO>> List();
        Task<ProductoDTO> Create (ProductoDTO product);
        Task<bool> Edit(ProductoDTO product);
        Task<bool> Delete(int id);
    }
}
