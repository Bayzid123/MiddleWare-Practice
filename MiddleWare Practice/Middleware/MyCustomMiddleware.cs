using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWare_Practice.Middleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers.Add("Middleware", "Middleware Header");
            await next(context);
        }
    }
}
