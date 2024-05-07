using PuntoVenta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DAL.Repositories.Contract
{
    public interface ITipoTransaccionRepository : IGenericRepository<TipoTransaccion>
    {
        Task<TipoTransaccion> Register(TipoTransaccion model);

    }
}
