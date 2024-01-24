
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Exception
{
    
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the Web API configuration, services, and routes.
        /// </summary>
        /// <param name="config">The HttpConfiguration instance to be configured.</param>
        public static void Register(HttpConfiguration config)
        {
            // apply exception filter globally
            // config.Filters.Add(new CustomException.CustomExceptionFilter());

            config.Services.Replace(typeof(IExceptionHandler), new CustomException.CustomExceptionHandler());

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
