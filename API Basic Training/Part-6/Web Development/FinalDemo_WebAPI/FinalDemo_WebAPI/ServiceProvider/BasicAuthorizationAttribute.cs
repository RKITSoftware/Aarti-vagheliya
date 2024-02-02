using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FinalDemo_WebAPI.ServiceProvider
{
    /// <summary>
    /// Custom authorization attribute for basic authorization in Web API.
    /// </summary>
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Handles unauthorized requests by setting the response to forbidden for unauthenticated users.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            // Checks if the user is authenticated.
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // Proceeds with the base unauthorized request handling.
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                // Sets the response to forbidden for unauthenticated users.
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }
    }
}