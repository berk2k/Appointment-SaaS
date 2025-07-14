using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSystem.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connStr = Environment.GetEnvironmentVariable("AppointmentProjectDefaultString") ??
                          configuration.GetConnectionString("AppointmentProjectDefaultString");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connStr));

            return services;
        }

    }

}
