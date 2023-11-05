using Microsoft.OpenApi.Models;

namespace PMC.WebAPI.Configuration
{
    public class SwaggerConfig
    {
        public SwaggerConfig() { }
        public void ConfigureSwagger(IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Personal Medical Clinic API", Version = "v1" });
            });
        }
    }
}
