using AppointmentSystem.Application.Behaviors;
using AppointmentSystem.Application.Commands.Appointment;
using AppointmentSystem.Application.Configuration.Mapping;
using AppointmentSystem.Application.Mapping.Profiles;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

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

            var mapper = ApplicationMapperConfiguration.InitializeAutoMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
