using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithSerilog.Middlewares
{
    public class LoggingMiddleware
    {
        readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        } 

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Response.StatusCode >= 400 && context.Response.StatusCode < 500)
            {
                Log.Warning("We have got some 4xx error, here is code : " + context.Response.StatusCode);
            }
            else if (context.Response.StatusCode >= 500)
            {
                Log.Error("Oh, no, here is 5xx error." + context.Response.StatusCode);
            }
            else Log.Information("Everything was ok, here was no any 4xx or 5xx errors");
        }
    }
}