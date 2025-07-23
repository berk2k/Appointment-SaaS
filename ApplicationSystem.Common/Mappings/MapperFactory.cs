using Microsoft.Extensions.DependencyInjection;



namespace AppointmentSystem.Common.Mappings
{
    public class MapperFactory : IMapperFactory
    {
        private readonly IServiceProvider _provider;

        public MapperFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IMapper<TSource, TDestination> GetMapper<TSource, TDestination>()
        {
            var mapper = _provider.GetService<IMapper<TSource, TDestination>>();
            if (mapper == null)
            {
                throw new InvalidOperationException(
                    $"Mapper for {typeof(TSource).Name} -> {typeof(TDestination).Name} was not registered.");
            }
            return mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var mapper = GetMapper<TSource, TDestination>();
            return mapper.Map(source);
        }

        public List<TDestination> Map<TSource, TDestination>(List<TSource> sources)
        {
            var mapper = GetMapper<TSource, TDestination>();
            return mapper.Map(sources);
        }
    }
}


