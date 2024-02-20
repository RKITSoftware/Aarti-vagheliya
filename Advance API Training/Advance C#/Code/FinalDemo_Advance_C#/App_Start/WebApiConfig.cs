using FinalDemo_Advance_C_.Bussiness_Logic;
using System.Web.Http;

namespace FinalDemo_Advance_C_
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

            //for enum configuration for serialization
            BLUser.Configure();

        }
    }
}
