using PMC.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Manager.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientsAsync();
        Task<Cliente> GetClientByIdAsync(int id);
        Task<Cliente> InsertClientAsync(Cliente cliente);
        Task<Cliente> UpdateClientAsync(Cliente cliente);
        Task DeleteClientAsync(int id);
    }
}
