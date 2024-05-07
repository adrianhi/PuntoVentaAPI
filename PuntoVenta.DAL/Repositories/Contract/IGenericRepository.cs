using PuntoVenta.Model;
using System.Linq.Expressions;
namespace PuntoVenta.DAL.Repositories.Contract
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> Get (Expression<Func<TModel, bool>> filter);
        Task<TModel> Create (TModel model);
        Task<bool> Edit (TModel model);
        Task<bool> Delete(TModel model);
        Task<IQueryable<TModel>> Consult(Expression<Func<TModel,bool>> filter =null);
    }
}
