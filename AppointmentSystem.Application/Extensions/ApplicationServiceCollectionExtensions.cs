using Microsoft.Extensions.DependencyInjection;
using AppointmentSystem.Application.Commands.Appointment;
using AppointmentSystem.Application.Behaviors;
using MediatR;
using FluentValidation;

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

            services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
