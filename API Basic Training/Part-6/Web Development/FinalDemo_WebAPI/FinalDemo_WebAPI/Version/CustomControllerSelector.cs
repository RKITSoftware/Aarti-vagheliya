using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace FinalDemo_WebAPI.Version
{
    /// <summary>
    /// Custom HTTP controller selector that determines the appropriate controller based on the API version specified in a custom header.
    /// </summary>
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        #region Private Member

        //Private object of HttpConfiguration.
        private HttpConfiguration _config;


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomControllerSelector"/> class.
        /// </summary>
        /// <param name="config">The HTTP configuration.</param>
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Selects the appropriate HTTP controller descriptor based on the API version specified in the custom header.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <returns>The selected HTTP controller descriptor.</returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // local declaration for controllerDescriptor
            HttpControllerDescriptor controllerDescriptor;

            //returns all possible API Controllers
            var controllers = GetControllerMapping();

            //return the information about the route
            var routeData = request.GetRouteData();

            //get the controller name passed
            string controllerName = routeData.Values["controller"].ToString();
            string apiVersion = "1";



            //Custom Header Name to be check
            string customHeaderForVersion = "X-Product-Version";

            // Checks if the custom header is present in the request
            if (request.Headers.Contains(customHeaderForVersion))
            {
                // Retrieves the API version from the custom header
                apiVersion = request.Headers.GetValues(customHeaderForVersion).FirstOrDefault();

                // Checks if the API version contains multiple versions separated by commas, selects the first one
                if (!string.IsNullOrEmpty(apiVersion) && apiVersion.Contains(","))
                {
                    apiVersion = apiVersion.Split(',')[0];
                }
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

            //check the value in controllers dictionary. TryGetValue is an efficient way to check the value existence
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }
            return null;
        }

        #endregion
    }
}