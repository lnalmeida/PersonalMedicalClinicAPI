using Microsoft.EntityFrameworkCore;
using PMC.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMC.Data.Context
{
    public class PMC_Context: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public PMC_Context(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
