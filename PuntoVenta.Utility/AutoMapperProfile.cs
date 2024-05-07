using AutoMapper;
using PuntoVenta.DTO;
using PuntoVenta.Model;
using System.Globalization;
namespace PuntoVenta.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region CategoriaProducto
            CreateMap<CategoriaProducto, CategoriaProductoDTO>().ReverseMap();
            #endregion CategoriaProducto

            #region Producto
            CreateMap<Producto, ProductoDTO>()
            .ForMember(dest => dest.PrecioVenta, opt => opt.MapFrom(src => src.PrecioVenta.HasValue ? Convert.ToString(src.PrecioVenta.Value, new CultureInfo("es-DO")) : string.Empty))
            .ForMember(dest => dest.Existencia, opt => opt.MapFrom(src => src.Estado == "Disponible" ? 1 : 0));
            CreateMap<ProductoDTO, Producto>()
           .ForMember(dest => dest.IdCategoriaNavigation, opt => opt.Ignore())
           .ForMember(dest => dest.PrecioVenta, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.PrecioVenta) ? (decimal?)null : Convert.ToDecimal(src.PrecioVenta, new CultureInfo("es-DO"))))
           .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Existencia == 0 ? "No Disponible" : "Disponible"));


            ;

            #endregion Producto

            #region Venta
            CreateMap<MaestroVenta, VentaDTO>()
            .ForMember(dest => dest.MontoTotalTexto, opt => opt.MapFrom(src => Convert.ToString(src.MontoTotal.Value, new CultureInfo("es-DO"))))

            .ForMember(dest => dest.Fecha,
            opt => opt.MapFrom(src => src.Fecha.Value.ToString("dd/MM/yyyy")));




            CreateMap<VentaDTO, MaestroVenta>()
            .ForMember(dest => dest.MontoTotal, opt => opt.MapFrom(src => Convert.ToDecimal(src.MontoTotalTexto, new CultureInfo("es-DO"))));
            #endregion

            #region DetalleVenta
            CreateMap<DetallesVenta, DetalleVentaDTO>()

            .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => Convert.ToString(src.PrecioVenta.Value, new CultureInfo("es-DO"))));
           
            CreateMap<DetalleVentaDTO, DetallesVenta>()
                .ForMember(dest => dest.PrecioVenta,
                opt => opt.MapFrom(
                src => Convert.ToDecimal(src.PrecioUnitario, new CultureInfo("es-DO"))
                ));

            #endregion



        }


    }
}
