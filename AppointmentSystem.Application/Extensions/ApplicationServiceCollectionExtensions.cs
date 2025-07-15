using Microsoft.Extensions.DependencyInjection;
using AppointmentSystem.Application.Commands.Appointment;
using AppointmentSystem.Application.Behaviors;
using MediatR;

namespace AppointmentSystem.Application.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateAppointmentCommand>();
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}
