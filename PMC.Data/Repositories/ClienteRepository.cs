using Microsoft.EntityFrameworkCore;
using PMC.Core.Domain;
using PMC.Data.Context;
using PMC.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PMC_Context _context;
        public ClienteRepository(PMC_Context context)
        {
            _context = context;
        }

       public async Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetClientByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }
    }
}
