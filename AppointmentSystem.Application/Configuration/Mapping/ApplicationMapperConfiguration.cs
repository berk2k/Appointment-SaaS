using AppointmentSystem.Application.Mapping.Profiles;
using AutoMapper;

namespace AppointmentSystem.Application.Configuration.Mapping
{
    public static class ApplicationMapperConfiguration
    {
        public static IMapper InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BranchProfile>();

                //others
                
            });

            return config.CreateMapper();
        }
    }
}
