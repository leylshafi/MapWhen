using MapWhen.Middlewares;
using System.Runtime.CompilerServices;

namespace MapWhen.Extensions
{
    public static class Extension
    {
        public static IApplicationBuilder UseLogin(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoginMiddleware>();

        }
    }
}
