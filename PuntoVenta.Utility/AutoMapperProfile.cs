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
            #region Cliente
            CreateMap<ClientDTO, MaestroCliente>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono));

            CreateMap<MaestroCliente, ClientDTO>()
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono));

            #endregion

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

            

            #endregion Producto

            #region Venta
            CreateMap<MaestroVenta, VentaDTO>()
            .ForMember(dest => dest.MontoTotalTexto, opt => opt.MapFrom(src => Convert.ToString(src.MontoTotal.Value, new CultureInfo("es-DO"))))
            .ForMember(dest => dest.MontoRecibidoTexto, opt => opt.MapFrom(src => Convert.ToString(src.MontoRecibido.Value, new CultureInfo("es-DO"))))
            .ForMember(dest => dest.IdTipoTransaccion, opt => opt.MapFrom(src => Convert.ToString(src.IdTipoTransaccion.Value)))
            .ForMember(dest => dest.IdTransaccion, opt => opt.MapFrom(src => Convert.ToString(src.IdTransaccion.Value)))

            .ForMember(dest => dest.Fecha,
            opt => opt.MapFrom(src => src.Fecha.Value.ToString("dd/MM/yyyy")));




            CreateMap<VentaDTO, MaestroVenta>()
            .ForMember(dest => dest.MontoTotal, opt => opt.MapFrom(src => Convert.ToDecimal(src.MontoTotalTexto, new CultureInfo("es-DO"))))
            .ForMember(dest => dest.MontoRecibido, opt => opt.MapFrom(src => Convert.ToDecimal(src.MontoRecibidoTexto, new CultureInfo("es-DO"))))
            .ForMember(dest => dest.IdTransaccion, opt => opt.MapFrom(src => Convert.ToInt32(src.IdTransaccion)))
            .ForMember(dest => dest.IdTipoTransaccion, opt => opt.MapFrom(src => Convert.ToInt32(src.IdTipoTransaccion)))            ;
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

            #region TipoTransaccion

            CreateMap<TipoTransaccion, TipoTransaccionDTO>()
              .ForMember(dest => dest.IdTipoTransaccion, opt => opt.MapFrom(src => src.IdTipoTransaccion))
              .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
              .ForMember(dest => dest.EsCredito, opt => opt.MapFrom(src => src.EsCredito))
              .ForMember(dest => dest.FactCredito, opt => opt.MapFrom(src => src.EsCredito ? true : src.FactCredito))
              .ForMember(dest => dest.FactContado, opt => opt.MapFrom(src => src.EsCredito ? false : src.FactContado))
              .ForMember(dest => dest.ReciboCobro, opt => opt.MapFrom(src => src.EsCredito ? false : src.ReciboCobro));

            CreateMap<TipoTransaccionDTO, TipoTransaccion>()
                .ForMember(dest => dest.IdTipoTransaccion, opt => opt.MapFrom(src => src.IdTipoTransaccion))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.EsCredito, opt => opt.MapFrom(src => src.EsCredito))
                .ForMember(dest => dest.FactCredito, opt => opt.MapFrom(src => src.EsCredito ? src.FactCredito : false))
                .ForMember(dest => dest.FactContado, opt => opt.MapFrom(src => src.EsCredito ? false : src.FactContado))
                .ForMember(dest => dest.ReciboCobro, opt => opt.MapFrom(src => src.EsCredito ? false : src.ReciboCobro));
            #endregion

            #region Transacciones

            CreateMap<Transacciones, TransaccionDTO>()
                .ForMember(dest => dest.IdTransaccion, opt => opt.MapFrom(src => src.IdTransaccion))
                .ForMember(dest => dest.IdVenta, opt => opt.MapFrom(src => src.IdVenta))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.TipoTransaccionId, opt => opt.MapFrom(src => src.TipoTransaccionId))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));

            CreateMap<TransaccionDTO, Transacciones>()
                .ForMember(dest => dest.IdTransaccion, opt => opt.MapFrom(src => src.IdTransaccion))
                .ForMember(dest => dest.IdVenta, opt => opt.MapFrom(src => src.IdVenta))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.TipoTransaccionId, opt => opt.MapFrom(src => src.TipoTransaccionId))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));

            #endregion

            #region CxC
            CreateMap<CxCDTO, MaestroCtasxcobrar>()
                .ForMember(dest => dest.IdCxC, opt => opt.MapFrom(src => src.IdCxC))
                .ForMember(dest => dest.IdVenta, opt => opt.MapFrom(src => src.IdVenta))
                .ForMember(dest => dest.IdTipoTransaccion, opt => opt.MapFrom(src => src.IdTipoTransaccion))
                .ForMember(dest => dest.IdTransaccion, opt => opt.MapFrom(src => src.IdTransaccion))
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.MontoTotal, opt => opt.MapFrom(src => src.MontoTotal))
                .ForMember(dest => dest.MontoRecibido, opt => opt.MapFrom(src => src.MontoRecibido))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));

            CreateMap<MaestroCtasxcobrar, CxCDTO>()
                .ForMember(dest => dest.IdCxC, opt => opt.MapFrom(src => src.IdCxC))
                .ForMember(dest => dest.IdVenta, opt => opt.MapFrom(src => src.IdVenta))
                .ForMember(dest => dest.IdTipoTransaccion, opt => opt.MapFrom(src => src.IdTipoTransaccion))
                .ForMember(dest => dest.IdTransaccion, opt => opt.MapFrom(src => src.IdTransaccion))
                .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente))
                .ForMember(dest => dest.MontoTotal, opt => opt.MapFrom(src => src.MontoTotal))
                .ForMember(dest => dest.MontoRecibido, opt => opt.MapFrom(src => src.MontoRecibido))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));
            #endregion


        }


    }
}
