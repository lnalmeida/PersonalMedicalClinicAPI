using FluentValidation.AspNetCore;
using FluentValidation;
using PMC.Manager.Validators;
using System.Globalization;

namespace PMC.WebAPI.Configuration
{
    public class ValidatorsConfig
    {
        public ValidatorsConfig() { }
        public void ConfigureValidators(IServiceCollection services) 
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
            services.AddValidatorsFromAssemblyContaining<NewClienteValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateClienteValidator>();
        }
    }
}
