using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PuntoVenta.BLL.Services.Contracts;
using PuntoVenta.DAL.Repositories.Contract;
using PuntoVenta.DTO;
using PuntoVenta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuntoVenta.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IGenericRepository<MaestroCliente> _clientRepository;
        private readonly IMapper _mapper;

        public ClientService (IGenericRepository<MaestroCliente> clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<List<ClientDTO>> List ( )
        {
            try
            {
                var clients = await _clientRepository.Consult();
                var clientsList = clients.ToList();
             

                return _mapper.Map<List<ClientDTO>>(clientsList);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ClientDTO> Create (ClientDTO client)
        {
            try
            {
                var createdClient = await _clientRepository.Create(_mapper.Map<MaestroCliente>(client));
                if (createdClient.IdCliente == 0)
                    throw new TaskCanceledException("No se pudo crear el cliente");

                return _mapper.Map<ClientDTO>(createdClient);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit (ClientDTO client)
        {
            try
            {
                var existingClient = await _clientRepository.Get(u => u.IdCliente == client.IdCliente);
                if (existingClient == null)
                    throw new TaskCanceledException("El cliente no existe");

                _mapper.Map(client, existingClient);

                bool response = await _clientRepository.Edit(existingClient);
                if (!response)
                    throw new TaskCanceledException("No se pudo editar el cliente");

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete (int id)
        {
            try
            {
                var existingClient = await _clientRepository.Get(u => u.IdCliente == id);
                if (existingClient == null)
                    throw new TaskCanceledException("El cliente no existe");

                bool response = await _clientRepository.Delete(existingClient);
                if (!response)
                    throw new TaskCanceledException("No se pudo eliminar el cliente");


                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
