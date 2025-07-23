using AppointmentSystem.Common.Multitenancy;
using Microsoft.Extensions.Logging;

namespace AppointmentSystem.Common.Mappings
{
    public abstract class BaseMapper<TSource, TDestination> : IMapper<TSource, TDestination>
    {
        protected readonly ITenantContext _tenantContext;
        protected readonly ILogger<BaseMapper<TSource, TDestination>> _logger;

        protected BaseMapper(ITenantContext tenantContext, ILogger<BaseMapper<TSource, TDestination>> logger)
        {
            _tenantContext = tenantContext;
            _logger = logger;
        }

        public abstract TDestination Map(TSource source);

        public virtual TDestination Map(TSource source, TDestination destination)
        {
            if (source == null) return destination;
            return Map(source);
        }

        public virtual List<TDestination> Map(List<TSource> sources)
        {
            if (sources == null || !sources.Any()) return new List<TDestination>();
            return sources.Select(Map).ToList();
        }

        public virtual async Task<TDestination> MapAsync(TSource source)
        {
            return await Task.FromResult(Map(source));
        }

        public virtual async Task<List<TDestination>> MapAsync(List<TSource> sources)
        {
            return await Task.FromResult(Map(sources));
        }
    }
}
