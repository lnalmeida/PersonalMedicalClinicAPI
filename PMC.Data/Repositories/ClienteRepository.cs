using Microsoft.AspNetCore.Mvc;
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

        //insert
        public async Task<Cliente> InsertClientAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        //update
        public async Task<Cliente> UpdateClientAsync(Cliente cliente)
        {
            var clienteAtual = await _context.Clientes.FindAsync(cliente.Id);
            if(clienteAtual == null)
            {
                return null;
            }

            _context.Entry(clienteAtual).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
            return clienteAtual;
        }

        //delete
        public async Task DeleteClientAsync(int id)
        {
            var clienteAtual = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clienteAtual);
            await _context.SaveChangesAsync();

        }
    }
}
