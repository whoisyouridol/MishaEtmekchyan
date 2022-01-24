using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebAPI.Middlewares
{
    public class HandleCarExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        public HandleCarExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
               await _next.Invoke(context);
            }
            catch(Exception e)
            {
                await _handleExceptionAsync(context, e);
            }
        }

        private async Task _handleExceptionAsync(HttpContext context, Exception e)
        {
            var error = new ErrorsAPI(context, e);
            var result = JsonConvert.SerializeObject(error);

            _prepareResponse(context, error);

            await context.Response.WriteAsync(result);
        }
        private void _prepareResponse(HttpContext context, ErrorsAPI error)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status.Value;
        }
    }
}
