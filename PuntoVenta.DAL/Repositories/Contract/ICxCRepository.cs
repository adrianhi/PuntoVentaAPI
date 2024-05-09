using PuntoVenta.Model;

namespace PuntoVenta.DAL.Repositories.Contract
{
    public interface ICxCRepository : IGenericRepository<MaestroCtasxcobrar>
    {
        Task<MaestroCtasxcobrar> Register (MaestroCtasxcobrar model);

    }
}
