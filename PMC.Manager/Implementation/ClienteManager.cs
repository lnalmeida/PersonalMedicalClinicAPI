using AutoMapper;
using PMC.Core.Domain;
using PMC.Core.Shared.ModelViews;
using PMC.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Manager.Implementation
{
    public class ClienteManager: IClienteManager
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteManager(IClienteRepository clienteRepository, IMapper mapper) 
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            return await _clienteRepository.GetAllClientsAsync();
        }

        public async Task<Cliente> GetClientByIdAsync(int id)
        {
            return await _clienteRepository.GetClientByIdAsync(id);
        }

        public async Task<Cliente> InsertClientAsync(NewClienteModelView newCliente)
        {
           var cliente =  _mapper.Map<Cliente>(newCliente);
           return await _clienteRepository.InsertClientAsync(cliente);
        }

        //update
        public async Task<Cliente> UpdateClientAsync(UpdateClienteModelView clienteToUpdate)
        {
            var cliente = _mapper.Map<Cliente>(clienteToUpdate);
            return await _clienteRepository.UpdateClientAsync(cliente);
        }

        //delete
        public async Task DeleteClientAsync(int id)
        {
            await _clienteRepository.DeleteClientAsync(id);
        }
    }
}
