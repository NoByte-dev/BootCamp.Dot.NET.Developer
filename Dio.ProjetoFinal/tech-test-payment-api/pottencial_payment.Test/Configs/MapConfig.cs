using AutoMapper;

namespace pottencial_payment.Test.Configs
{
    public static class MapConfig
    {
        public static IMapper Get()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Api.Profiles.MappingProfile());
            });

            return mockMapper.CreateMapper();
        }
    }

}
