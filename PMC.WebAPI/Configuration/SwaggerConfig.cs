using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace PMC.WebAPI.Configuration
{
    public class SwaggerConfig
    {
        public SwaggerConfig() { }
        public void ConfigureSwagger(IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Personal Medical Clinic API",
                        Version = "v1",
                        Description = "Personal Medical Clinic API, developed for teaching purposes.",
                        Contact = new OpenApiContact
                        {
                            Name = "Luiz Almeida",
                            Email = "l.n.almeida.dev@outlook.com",
                            Url = new Uri("https://github.com/lnalmeida/PersonalMedicalClinicAPI")
                        }, License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        },
                        TermsOfService = new Uri("https://opensource.org/osd")
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile) ;
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "PMC.Core.Shared.xml");
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "PMC.Core.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
