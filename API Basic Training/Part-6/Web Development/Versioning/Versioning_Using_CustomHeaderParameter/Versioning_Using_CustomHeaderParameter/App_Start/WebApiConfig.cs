
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Versioning_Using_CustomHeaderParameter.Custom;

namespace Versioning_Using_CustomHeaderParameter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Replace the default IHttpControllerSelector with a custom implementation (CustomControllerSelector)
            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));
        }
    }
}
