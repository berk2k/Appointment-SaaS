using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AppointmentSystem.Infrastructure.Extensions
{
    public static class LoggingExtensions
    {
        public static IHostBuilder UseCustomSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Information()
                //.WriteTo.Console()
                //.WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return hostBuilder.UseSerilog();
        }
    }
}
