using Microsoft.EntityFrameworkCore;
using PMC.Data.Context;
using PMC.WebAPI.Configuration;

namespace PMC.WebAPI.Initializer
{
    public class AppInitializer
    {
        public AppInitializer() {}
        public void Initialize(WebApplicationBuilder app, IConfiguration configuration)
        {
            var env = app.Environment;

            //Initialize controllers
            app.Services.AddControllers();

            //Initialize Context
            var contextConfig = new ContextConfig();
            contextConfig.ConfigureContext(app.Services, configuration);
            //contextConfig.DatabaseConfig()

            //Initialize AutoMapper
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.ConfigureAutoMapper(app.Services);

            //Initialize Fluent Validation
            var fluentValidationConfig = new ValidatorsConfig();
            fluentValidationConfig.ConfigureValidators(app.Services);

            app.Services.AddEndpointsApiExplorer();
            //initialize Swagger
            var swaggerConfig = new SwaggerConfig();
            swaggerConfig.ConfigureSwagger(app.Services);
        }

        public void DatabaseInitilize(WebApplicationBuilder webapp) 
        {
            using var scope = webapp.Services.BuildServiceProvider().CreateScope();
            using var context = scope.ServiceProvider.GetService<PMC_Context>();
            if(context != null && !context.Database.EnsureCreated()) 
            {
                context.Database.Migrate();
            }
        }
    }
}
