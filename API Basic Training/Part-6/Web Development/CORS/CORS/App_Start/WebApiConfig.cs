using System.Web.Http;

namespace CORS
{
    /// <summary>
    /// Configuration class for setting up Web API in the application.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Configures Web API settings and routes.
        /// </summary>
        /// <param name="config">The HTTP configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Define a default route for Web API controllers
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable Cross-Origin Resource Sharing (CORS)
            // This allows client applications from different origins to make requests to the API.
            // By default, allows all origins, all headers, and all methods.
            // Adjust parameters based on specific requirements.


            //EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();
        }
    }
}
