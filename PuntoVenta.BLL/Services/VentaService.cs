using AutoMapper;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DTO;
using PuntoVenta.Model;


namespace PuntoVenta.BLL.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IGenericRepository<DetallesVenta> _detalleVentaReposity;
        private readonly IMapper _mapper;

        public VentaService (IVentaRepository ventaRepository, IGenericRepository<DetallesVenta> detalleVentaReposity, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _detalleVentaReposity = detalleVentaReposity;
            _mapper = mapper;
        }

        public async Task<VentaDTO> Register (VentaDTO sale)
        {
            try {
                var saleGenerated = await _ventaRepository.Register(_mapper.Map<MaestroVenta>(sale));
                if (saleGenerated.IdVenta == 0)
                    throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<VentaDTO>(saleGenerated);
            
            } 
            catch { 
            
            throw ;
            }
        }
    }
}
