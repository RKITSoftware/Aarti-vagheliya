using System.Web.Http;

namespace FinalDemo_WebAPI
{
    /// <summary>
    /// Configuration class for setting up Web API routes, services, and filters.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers Web API configurations, routes, and filters.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/> instance.</param>
        public static void Register(HttpConfiguration config)
        {
            
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #region Routing for URI Versioning

            //Define routing for version 1
            config.Routes.MapHttpRoute(
                name: "ProductVersion1",
                routeTemplate: "api/V1/Product/{id}",
                defaults: new { Controller = "CLProductV1", id = RouteParameter.Optional }
            );

            // Define routing for version 2
            config.Routes.MapHttpRoute(
               name: "ProductVersion2",
               routeTemplate: "api/V2/Product/{id}",
               defaults: new { Controller = "CLProductV2", id = RouteParameter.Optional }
           );

            #endregion

            #region Custom header versioning

            // Replace the default IHttpControllerSelector with a custom implementation (CustomControllerSelector)
            // config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelector(config));

            #endregion

            #region Exception Filter 

            // apply exception filter globally
            config.Filters.Add(new CustomException.CustomExceptionFilter());

            #endregion

            #region CORS
            // Enable CORS
            config.EnableCors();

            #endregion
        }
    }
}
