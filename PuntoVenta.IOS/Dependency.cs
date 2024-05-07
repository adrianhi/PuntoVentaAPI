using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PuntoVenta.DAL.DBContext;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DAL.Repositories;
using PuntoVenta.Utility;
namespace PuntoVenta.IOC
{
    public static class Dependency
    {
        public static void DependenciesInjections 
        ( 
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            services.AddDbContext<PuntoVentasContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionSql"));
            });
            services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository,VentaRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}
