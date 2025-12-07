using AutoMapper;
using haktanemresenelk.com.services.Profiles;

namespace haktanemresenel.com.webUI.Extensions
{
    public static class MapperConfigsExtensions
    {

        public static IMapperConfigurationExpression AddMapperConfig(this IMapperConfigurationExpression config)
        {

            config.AddProfile<SessionProfile>();
            return config;
        }
    }
}
