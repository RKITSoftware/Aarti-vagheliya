using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Versioning_Using_QueryStringParameter.Custom
{
    /// <summary>
    /// Custom controller selector for API versioning using query string parameter.
    /// </summary>
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
       private HttpConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomControllerSelector"/> class.
        /// </summary>
        /// <param name="config">The HTTP configuration.</param>
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        /// <summary>
        /// Selects the appropriate HTTP controller descriptor based on the API version specified in the query string.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <returns>The selected HTTP controller descriptor.</returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //returns all possible API Controllers
            var controllers = GetControllerMapping();

            //return the information about the route
            var routeData = request.GetRouteData();

            //get the controller name passed
            var controllerName = routeData.Values["controller"].ToString();

            string apiVersion = "1";

            //get querystring from the URI
            var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);
            if (versionQueryString["version"] != null)
            {
                apiVersion = Convert.ToString(versionQueryString["version"]);
            }

            // Appends the API version to the controller name
            if (apiVersion == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }
            
            HttpControllerDescriptor controllerDescriptor;  

            //check the value in controllers dictionary. TryGetValue is an efficient way to check the value existence
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }

    }
}