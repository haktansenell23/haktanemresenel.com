using haktanemresenel.com.core.Services;
using haktanemresenelk.com.services.Services;

namespace haktanemresenel.com.webUI.Extensions
{
    public static class CustomServicesExtensions
    {

        public static IServiceCollection CustomServices (this IServiceCollection services)
        {
            services.AddScoped<ISessionService, SessionService>();

            return services;
        }
    }
}
