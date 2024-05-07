using AutoMapper;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DTO;
using PuntoVenta.Model;

namespace PuntoVenta.BLL.Services
{
    public class TipoTransaccionService : ITipoTransaccionService
    {
        private readonly ITipoTransaccionRepository _tipoTransaccionRepository;
        private readonly IMapper _mapper;

        public TipoTransaccionService (ITipoTransaccionRepository tipoTransaccionRepository, IMapper mapper)
        {
            _tipoTransaccionRepository = tipoTransaccionRepository;
            _mapper = mapper;
        }

        public async Task<TipoTransaccionDTO> Register (TipoTransaccionDTO tipoTransaccion)
        {
            try
            {
                var tipoTransaccionModel = _mapper.Map<TipoTransaccion>(tipoTransaccion);
                var tipoTransaccionRegistrado = await _tipoTransaccionRepository.Register(tipoTransaccionModel);

                if (tipoTransaccionRegistrado.IdTipoTransaccion == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el tipo de transacción.");
                }

                return _mapper.Map<TipoTransaccionDTO>(tipoTransaccionRegistrado);
            }
            catch 
            {
                
                throw;
            }
        }
    }
}
