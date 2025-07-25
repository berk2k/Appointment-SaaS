using AppointmentSystem.Common.Interfaces.Mediator;
using AppointmentSystem.Infrastructure.Mediator;
using AppointmentSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSystem.Infrastructure.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connStr = Environment.GetEnvironmentVariable("AppointmentProjectDefaultString") ??
                          configuration.GetConnectionString("AppointmentProjectDefaultString");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connStr));

            
            services.AddTransient<IMediator, ManualMediator>();

            services.AddJwtAuthentication(configuration);

            // other Infrastructure Services
            // services.AddTransient<IEmailService, EmailService>();
            // services.AddTransient<IFileService, FileService>();
            // services.AddHttpClient();

            return services;
        }
    }

}
