using PuntoVenta.Model;
namespace PuntoVenta.DAL.Repositories.Contract
{
public interface IVentaRepository : IGenericRepository<MaestroVenta>
    {

        Task<MaestroVenta> Register (MaestroVenta model);

    }
}
