using Serilog.Events;
using Serilog;
using Serilog.Filters;

namespace PMC.WebAPI.Configuration
{
    public static class SerilogConfig
    {
        public static void  ConfigureLogger()
        {

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
             .Enrich.FromLogContext()
             .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
             .Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
             .WriteTo.Console()
             .CreateLogger();
        }


    }
}
