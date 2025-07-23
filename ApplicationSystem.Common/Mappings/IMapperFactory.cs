namespace AppointmentSystem.Common.Mappings
{
    public interface IMapperFactory
    {
        IMapper<TSource, TDestination> GetMapper<TSource, TDestination>();
        TDestination Map<TSource, TDestination>(TSource source);
        List<TDestination> Map<TSource, TDestination>(List<TSource> sources);
    }
}
