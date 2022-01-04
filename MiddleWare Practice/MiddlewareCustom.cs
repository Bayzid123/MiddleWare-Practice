using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MiddleWare_Practice
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareCustom
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public MiddlewareCustom(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("MiddlewareCustom");
            _logger.LogInformation("This is my Information");
            _logger.LogError("This is an error");
            _logger.LogWarning("This is a warning");
            _logger.BeginScope("This is a beingscope");
            _logger.LogDebug("This is a debug process");

        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Executed");
            await _next.Invoke(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareCustomExtensions
    {
        public static IApplicationBuilder UseMiddlewareCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareCustom>();
        }
    }
}
