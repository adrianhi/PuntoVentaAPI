using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DAL.DBContext;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.Model;

namespace PuntoVenta.DAL.Repositories
{
    public class GenericRepository <TModel> : IGenericRepository<TModel> where TModel : class
    {

        private readonly PuntoVentasContext _dbcontext;

        public GenericRepository (PuntoVentasContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<TModel> Get (Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel model = await _dbcontext.Set<TModel>().FirstOrDefaultAsync(filter);
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Create (TModel model)
        {
            try
            {
                _dbcontext.Set<TModel>().Add(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit (TModel model)
        {
            try
            {
                _dbcontext.Set<TModel>().Update(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }

        }
        public async Task<bool> Delete (TModel model)
        {
            try
            {
                _dbcontext.Set<TModel>().Remove(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModel>> Consultar (Expression<Func<TModel, bool>> filter = null)
        {
            try
            {
                IQueryable<TModel> query = filter == null ? _dbcontext.Set<TModel>() : _dbcontext.Set<TModel>().Where(filter);
                return query;

            }
            catch
            {
                throw;
            }
        }

        public Task<MaestroVenta> Register (MaestroVenta model)
        {
            throw new NotImplementedException();
        }
    }
}
