using AppointmentSystem.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSystem.Common.Extensions
{
    public static class MappingServiceCollectionExtensions
    {
        public static IServiceCollection AddManualMapping(this IServiceCollection services)
        {
            services.AddScoped<IMapperFactory, MapperFactory>();
            return services;
        }
    }
}
