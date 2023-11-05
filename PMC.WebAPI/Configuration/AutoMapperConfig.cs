using PMC.Manager.Mappings;

namespace PMC.WebAPI.Configuration
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig() { }
        public void ConfigureAutoMapper(IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(NewClientMappingProfile), typeof(UpdateClienteMappingProfile));
        }
    }
}
