using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebAPI.Middlewares
{
    public static class RequestCarExceptionsMiddlewareExtension
    {
        public static IApplicationBuilder UseCarsExceptions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandleCarExceptionsMiddleware>();
        }
    }
}
