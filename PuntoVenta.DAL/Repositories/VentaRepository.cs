using PuntoVenta.DAL.DBContext;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.Model;

namespace PuntoVenta.DAL.Repositories
{
    public class VentaRepository : GenericRepository<MaestroVenta>,IVentaRepository
    {

        private readonly PuntoVentasContext _dbcontext;

        public VentaRepository (PuntoVentasContext dbcontext): base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<MaestroVenta> Register (MaestroVenta model)
        {
            MaestroVenta generatedSale = new MaestroVenta();

            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {

                    foreach (DetallesVenta dv in model.DetallesVenta)
                    {
                        Producto product = _dbcontext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        product.Stock = product.Stock - dv.Cantidad;
                        _dbcontext.Update(product);
                    }
                    await _dbcontext.SaveChangesAsync();

                    await _dbcontext.MaestroVentas.AddAsync(model);
                    await _dbcontext.SaveChangesAsync();
                    generatedSale = model;
                    transaction.Commit();

                }
                catch
                {
                    
                    transaction.Rollback();
                    throw;
                }
            }
            return generatedSale;
        }


    }
}
