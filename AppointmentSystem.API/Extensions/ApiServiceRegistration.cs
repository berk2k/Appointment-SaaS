using AppointmentSystem.API.Handlers;
using AppointmentSystem.API.Handlers.Interfaces;

namespace AppointmentSystem.API.Extensions
{
    public static class ApiServiceRegistration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<IExceptionHandler, NotFoundExceptionHandler>();
            services.AddTransient<IExceptionHandler, ValidationExceptionHandler>();
            services.AddTransient<IExceptionHandler, UnauthorizedExceptionHandler>();

            return services;
        }
    }
}
