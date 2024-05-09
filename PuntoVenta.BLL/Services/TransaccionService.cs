using AutoMapper;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DTO;
using PuntoVenta.Model;

namespace PuntoVenta.BLL.Services
{
    public class TransaccionService : ITransaccionService
    {
        private readonly ITransactionRepository _transaccionRepository;
        private readonly IMapper _mapper;

        public TransaccionService (ITransactionRepository transaccionRepository, IMapper mapper)
        {
            _transaccionRepository = transaccionRepository;
            _mapper = mapper;
        }

        public async Task<TransaccionDTO> Register (TransaccionDTO transaction)
        {
            try
            {
                var transaccionModel = _mapper.Map<Transacciones>(transaction);

                var transaccionRegistrada = await _transaccionRepository.Register(transaccionModel);

                if (transaccionRegistrada.IdTransaccion == 0)
                {
                    throw new TaskCanceledException("No se pudo crear la transacción.");
                }

                return _mapper.Map<TransaccionDTO>(transaccionRegistrada);
            }
            catch
            {
                throw;
            }
        }
    }
}
