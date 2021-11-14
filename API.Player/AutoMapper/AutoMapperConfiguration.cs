using AutoMapper;

namespace API.Player.AutoMapper
{
    public class AutoMapperConfiguration
    {
        private readonly MapperConfiguration _mapperConfig;
        public AutoMapperConfiguration(Profile profile)
        {
            _mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(profile);
            });
        }

        public IMapper GetMapper()
        {
            return _mapperConfig.CreateMapper();
        }
    }
}
