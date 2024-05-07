using PuntoVenta.DAL.DBContext;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DTO;
using PuntoVenta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DAL.Repositories
{
    public class TransactionRepository : GenericRepository<Transacciones>, ITransactionRepository
    {
         private readonly PuntoVentasContext _dbcontext;

        public TransactionRepository (PuntoVentasContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Transacciones> Register (Transacciones model)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    _dbcontext.Transacciones.Add(model);
                    await _dbcontext.SaveChangesAsync();
                    transaction.Commit();
                    return model;
                }
                catch 
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
