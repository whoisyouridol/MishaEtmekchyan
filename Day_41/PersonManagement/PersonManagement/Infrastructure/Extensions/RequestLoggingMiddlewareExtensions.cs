using Microsoft.AspNetCore.Builder;
using PersonManagement.Middlewares;

namespace PersonManagement.Extensions
{
    public static class RequestLoggingMiddlewareExtensions
    {
        internal static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestLogMiddleware>();

            return builder;
        }
    }
}
