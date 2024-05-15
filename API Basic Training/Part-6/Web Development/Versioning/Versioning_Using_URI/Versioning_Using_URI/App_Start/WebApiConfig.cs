using System.Web.Http;

namespace Versioning_Using_URI
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

            //Define routing for version 1
            config.Routes.MapHttpRoute(
                name:"stateVersion1",
                routeTemplate:"api/V1/State/{id}",
                defaults : new {Controller = "StateV1", id = RouteParameter.Optional }
            );

            // Define routing for version 2
            config.Routes.MapHttpRoute(
               name: "stateVersion2",
               routeTemplate: "api/V2/State/{id}",
               defaults: new { Controller = "StateV2", id = RouteParameter.Optional }
           );
        }
    }
}
