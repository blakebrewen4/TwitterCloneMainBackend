using Microsoft.AspNetCore.Builder;
using TwitterCloneAPIUserAuth2._0.Middlewares;

namespace TwitterCloneAPIUserAuth2._0.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
