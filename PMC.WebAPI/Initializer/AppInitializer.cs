using PMC.WebAPI.Configuration;

namespace PMC.WebAPI.Initializer
{
    public class AppInitializer
    {
        public AppInitializer() {}
        public void Initialize(WebApplicationBuilder app, IConfiguration configuration)
        {
            //Initialize controllers
            app.Services.AddControllers();

            //Initialize Context
            var contextConfig = new ContextConfig();
            contextConfig.ConfigureContext(app.Services, configuration);

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
    }
}
