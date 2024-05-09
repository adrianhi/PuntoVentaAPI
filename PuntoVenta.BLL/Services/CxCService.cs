using AutoMapper;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DAL.Repositories;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DTO;
using PuntoVenta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoVenta.BLL.Services
{
    public class CxCService : ICxCService
    {
        private readonly ICxCRepository _cxcRepository;
        private readonly IMapper _mapper;

        public CxCService (ICxCRepository cxcRepository, IMapper mapper)
        {
            _cxcRepository = cxcRepository;
            _mapper = mapper;
        }

        public async Task<CxCDTO> Register (CxCDTO cxc)
        {
            try
            {
                var cxcModel = _mapper.Map<MaestroCtasxcobrar>(cxc);

                var cxcRegister = await _cxcRepository.Register(cxcModel);

                if (cxcRegister.IdCxC == 0)
                {
                    throw new TaskCanceledException("No se pudo crear la cuenta por cobrar.");
                }

                return _mapper.Map<CxCDTO>(cxcRegister);
            }
            catch
            {
                throw;
            }
        }
    }
}
