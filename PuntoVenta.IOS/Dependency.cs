using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PuntoVenta.DAL.DBContext;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DAL.Repositories;
using PuntoVenta.Utility;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.BLL.Services;
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


            services.AddScoped<IClientService,ClientService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IVentaService,VentaService>();
        }
    }
}
