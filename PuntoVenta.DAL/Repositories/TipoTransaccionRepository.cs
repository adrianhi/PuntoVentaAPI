using PuntoVenta.DAL.DBContext;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.DAL.Repositories
{

    public class TipoTransaccionRepository : GenericRepository<TipoTransaccion>, ITipoTransaccionRepository
    {
    private readonly PuntoVentasContext _dbcontext;

        public TipoTransaccionRepository (PuntoVentasContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TipoTransaccion> Register (TipoTransaccion model)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    await _dbcontext.TipoTransaccions.AddAsync(model);
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
