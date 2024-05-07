using PuntoVenta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DAL.Repositories.Contract
{
    public interface ITransactionRepository : IGenericRepository<Transacciones>
    {
        Task<Transacciones> Register (Transacciones model);

    }
}
