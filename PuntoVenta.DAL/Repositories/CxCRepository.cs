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
    public class CxCRepository : GenericRepository<MaestroCtasxcobrar>, ICxCRepository
    {
        private readonly PuntoVentasContext _dbcontext;

        public CxCRepository (PuntoVentasContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<MaestroCtasxcobrar> Register (MaestroCtasxcobrar model)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    _dbcontext.MaestroCtasxcobrars.Add(model);
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
