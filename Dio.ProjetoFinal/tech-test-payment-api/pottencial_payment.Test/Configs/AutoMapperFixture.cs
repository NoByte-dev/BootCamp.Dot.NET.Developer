using AutoMapper;
using pottencial_payment.Api.Profiles;

namespace pottencial_payment.Test.Configs
{
    public abstract class BaseAutoMapperFixture
    {
        public IMapper mapper { get; set; }

        public BaseAutoMapperFixture()
        {
            mapper = new AutoMapperFixture().GetMapper();
        }

    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose() { }
    }
}
