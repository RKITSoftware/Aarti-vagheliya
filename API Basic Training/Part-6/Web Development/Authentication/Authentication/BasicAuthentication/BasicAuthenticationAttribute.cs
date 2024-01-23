using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Authentication.BasicAuthentication
{
    /// <summary>
    /// Custom authentication attribute for basic authentication.
    /// </summary>
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Handles authorization based on basic authentication credentials.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Checks if authorization header is present.
            if (actionContext.Request.Headers.Authorization == null) 
           {
                // Responds with unauthorized status if no authorization header is found.
                actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.Unauthorized,"Login Failed.");
           }
           else
           {
                try
                {
                    // Retrieves and decodes the authentication token from the authorization header.
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;
                    //username:password base64 encoded

                    string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                    string[] usernamePassword = decodedAuthToken.Split(':');

                    // Extracts username and password from the decoded token.
                    string username = usernamePassword[0];
                    string password = usernamePassword[1];

                    // Validates user credentials.
                    if (ValidateUser.Login(username, password))
                    {
                        // Sets the current principal for the executing thread.
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    }
                    else
                    {
                        // Responds with unauthorized status for invalid credentials.
                        actionContext.Response = actionContext.Request
                            .CreateErrorResponse(HttpStatusCode.Unauthorized, "Login failed.");
                    }
                }
                catch(Exception)
                {
                    // Responds with internal server error for unexpected exceptions.
                    actionContext.Response = actionContext.Request
                            .CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error...");
                }
                
           }
        }
    }
}