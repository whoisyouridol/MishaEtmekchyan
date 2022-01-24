using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ManageCarsService.Exceptions;
namespace Task_WebAPI
{
    public class ErrorsAPI : ProblemDetails
    {
        public const string UnhandledError = "UnhandledException";
        private HttpContext _context;
        private Exception _exception;
        public LogLevel LogLevel { get; set; }
        public string Code { get; set; }

        public ErrorsAPI(HttpContext context, Exception exception)
        {
            _context = context;
            _exception = exception;
            Code = "UnhandledErrorCode";
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Instance = context.Request.Path;

            _handleEx((dynamic)exception);
        }

        private void _handleEx(CarNotFoundException ex)
        {
            Code = ex.Message;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = ex.Message;
            LogLevel = LogLevel.Trace;
        }

        private void _handleEx(CouldNotAddCarException ex)
        {
            Code = ex.Message;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
            Title = ex.Message;
            LogLevel = LogLevel.Trace;
        }
    }
}
