using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Token_Custom.BL;
using Token_Custom.Services;

namespace Token_Custom.Filters
{
    /// <summary>
    /// Basic Authentication class for authorize user.
    /// </summary>
    public class JwtAuthenticationFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Authorize user data
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Retrieve the Authorization header from the HTTP request.
            var authorizationHeader = actionContext.Request.Headers.Authorization;

            // Check if the Authorization header is missing.
            if (authorizationHeader == null)
            {
                // If Authorization header is missing, set the response to Unauthorized with a message.
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Login failed");
            }
            else if (authorizationHeader.Scheme != "Basic")
            {
                // Extract the authentication token from the Authorization header parameter.
                string authToken = actionContext.Request.Headers.Authorization.Parameter;

                // Split the authentication token to extract the username and password.
                string[] usernamePassword = authToken.Split(':');

                // Extracts username and password from the decoded token.
                string username = usernamePassword[0];
                string password = usernamePassword[1];

                // Check if the username and password combination exists in the user list.
                var user = BLUser.users.Any(u => u.Username == username && u.Password == password);

                // If user exists with the given credentials.
                if (user)
                {
                    // Generate a new JWT token based on the username.
                    var token = TokenService.GenerateToken(username);

                    // Retrieve the principal from the generated token.
                    var principal = TokenService.GetPrincipal(token);

                    // Check if the principal is null, indicating an invalid token.
                    if (principal == null)
                    {
                        // If principal is null, set the response to Unauthorized with a message.
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid token");
                    }

                    // Set the current principal for the request to the retrieved principal.
                    Thread.CurrentPrincipal = principal;

                    // Set the response to OK with the generated token.
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, token);
                }
            }

            // Call the base implementation of OnActionExecuting to continue with the execution of the action method.
            base.OnActionExecuting(actionContext);
        }
    }

}
    
