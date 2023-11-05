using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PMC.Data.Context;
using PMC.Data.Repositories;
using PMC.Manager.Implementation;
using PMC.Manager.Interfaces;

namespace PMC.WebAPI.Configuration
{
    public class ContextConfig
    {
        public ContextConfig() { }
        public void ConfigureContext(IServiceCollection services, IConfiguration configuration) 
        {
            string strConnection = configuration.GetConnectionString("PMC_Connection") ?? string.Empty;
            //contexts
            services.AddDbContext<PMC_Context>(options => options.UseSqlServer(strConnection));

            //data core life cycle
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();

        }
    }
}
