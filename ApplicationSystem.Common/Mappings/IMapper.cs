namespace AppointmentSystem.Common.Mappings
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
        TDestination Map(TSource source, TDestination destination);
        List<TDestination> Map(List<TSource> sources);
        Task<TDestination> MapAsync(TSource source);
        Task<List<TDestination>> MapAsync(List<TSource> sources);
    }
}
