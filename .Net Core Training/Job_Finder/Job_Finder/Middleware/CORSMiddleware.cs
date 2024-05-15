using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Job_Finder.Middleware
{
    public class CORSMiddleware
    {
        private readonly RequestDelegate _next;

        public CORSMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*"); // Allow requests from any origin

            // Optionally, you can specify allowed headers and methods
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CORSMiddlewareExtensions
    {
        public static IApplicationBuilder UseCORSMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CORSMiddleware>();
        }
    }
}
