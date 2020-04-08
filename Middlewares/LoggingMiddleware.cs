using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Services;

namespace WebApplication2.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IDbService service)
        {
            httpContext.Request.EnableBuffering();

            if (httpContext.Request != null)
            {
                string path = httpContext.Request.Path; //"weatherforecast/cos"
                string queryString = httpContext.Request.QueryString.ToString();
                string method = httpContext.Request.Method.ToString();
                string bodyStr = "";

                using (StreamReader reader
                 = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                }

                
                string reqLogpath = Directory.GetCurrentDirectory() + "\\RequestLogs\\requestsLog.txt";
                using (var writer = new StreamWriter(reqLogpath, true, Encoding.UTF8))
                {
                    await writer.WriteLineAsync(method + " " + path + " " + bodyStr + " " + queryString);
                }
            }
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);

            await _next(httpContext);
        }


    }
}
