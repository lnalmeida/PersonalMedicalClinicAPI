using PMC.Core.Domain;
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
        public ClienteManager(IClienteRepository clienteRepository) 
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            return await _clienteRepository.GetAllClientsAsync();
        }

        public async Task<Cliente> GetClientByIdAsync(int id)
        {
            return await _clienteRepository.GetClientByIdAsync(id);
        }
    }
}
