using Microsoft.AspNetCore.Builder;
using PersonManagement.Middlewares;

namespace PersonManagement.Common.Extensions
{
    public static class CultureMiddlewareExtention
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
