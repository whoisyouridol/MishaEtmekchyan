using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;
using PersonManagement.Models;
using PersonManagement.Services.Models;

namespace PersonManagement.Middlewares
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
           // await LogRequest(context.Request);

            await _next(context);
        }

        public async Task LogRequest(HttpRequest request) 
        {
            var requestModel = new RequestModel
            {
                Ip = request.HttpContext.Connection.RemoteIpAddress.ToString(),
                Scheme = request.Scheme,
                Host = request.Host.ToString(),
                Method = request.Method,
                Path = request.Path,
                QueryString = request.QueryString.ToString(),
                IsSecured = request.IsHttps,
                RequestBody = await ReadRequestBody(request)
            };


            // გასატანია კლასში ToString მეთოდის გადაფარვაში 
            var stringToLog = $"{Environment.NewLine}Logged from MiddleWare{Environment.NewLine}" +
                $"Ip = {requestModel.Ip}{Environment.NewLine}" +
                $"Address = {requestModel.Scheme}://{requestModel.Host}{Environment.NewLine}" +
                $"RequestMethod = {requestModel.Method}{Environment.NewLine}" +
                $"RequestPath = {requestModel.Path}{Environment.NewLine}" +
                $"RequestQueryString = {requestModel.QueryString}{Environment.NewLine}" +
                $"RequestTime = {requestModel.RequestTime}{Environment.NewLine}" +
                $"IsSecured = {requestModel.IsSecured}{Environment.NewLine}" +
                $"RequestBody = {requestModel.RequestBody}{Environment.NewLine}";

            System.IO.File.AppendAllText(@"C:\Users\admin\Desktop\DI\Request.txt", stringToLog);
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            var buffer = new byte[request.ContentLength ?? 0];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Position = 0;

            return bodyAsText;
        }
    }
}
