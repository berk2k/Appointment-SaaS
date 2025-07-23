using AppointmentSystem.Application.Behaviors;
using AppointmentSystem.Application.Commands.Appointment;
using AppointmentSystem.Application.DTOs.Branch;
using AppointmentSystem.Application.Mappings;
using AppointmentSystem.Common.Behaviors;
using AppointmentSystem.Common.Interfaces.Mediator;
using AppointmentSystem.Common.Mappings;
using AppointmentSystem.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSystem.Application.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.RegisterHandlers();


            services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IMapperFactory, MapperFactory>();
            services.AddScoped<IMapper<CreateBranchRequest, Branch>, CreateBranchMapper>();
            services.AddScoped<IMapper<Branch, BranchResponse>, BranchResponseMapper>();




            return services;
        }


        private static IServiceCollection RegisterHandlers(this IServiceCollection services)
        {
            var assembly = typeof(CreateAppointmentCommand).Assembly;


            var handlerTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                             i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();


            foreach (var handlerType in handlerTypes)
            {
                var interfaceTypes = handlerType.GetInterfaces()
                    .Where(i => i.IsGenericType &&
                               i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                foreach (var interfaceType in interfaceTypes)
                {
                    services.AddTransient(interfaceType, handlerType);
                }
            }

            return services;
        }
    }
}
