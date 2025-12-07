using haktanemresenel.com.webUI.Middlewares;

namespace haktanemresenel.com.webUI.Extensions
{
    public static class CustomMiddlewaresExtensions
    {

        public static IApplicationBuilder CustomMiddlewares(this IApplicationBuilder app)
        {
             app.UseMiddleware<ExceptionMiddleware>();

             return app;
        }
    }
}
