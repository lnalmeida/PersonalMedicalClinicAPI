using PMC.Core.Domain;
using PMC.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Manager.Interfaces
{
    public interface IClienteManager
    {
        Task<IEnumerable<Cliente>> GetAllClientsAsync();
        Task<Cliente> GetClientByIdAsync(int id);
        Task<Cliente> InsertClientAsync(NewClienteModelView cliente);
        Task<Cliente> UpdateClientAsync(UpdateClienteModelView cliente);
        Task DeleteClientAsync(int id);
    }
}
