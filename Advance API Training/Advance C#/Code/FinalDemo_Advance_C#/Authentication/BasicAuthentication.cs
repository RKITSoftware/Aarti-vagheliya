using FinalDemo_Advance_C_.Bussiness_Logic;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FinalDemo_Advance_C_.Authentication
{
    /// <summary>
    /// Class implementing basic authentication for API endpoints.
    /// </summary>
    public class BasicAuthentication : ActionFilterAttribute
    {
        // Instance of BLUser class for user authentication
        private BLUser _objBLUser = new BLUser();

        /// <summary>
        /// Method executed before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Getting the authorization header from the request
            var authHeader = actionContext.Request.Headers.Authorization;

            // If authorization header is null
            if (authHeader == null)
            {
                // Returning unauthorized response
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                                        "invalid headers");
            }
            // If authorization scheme is Basic
            else if (authHeader.Scheme == "Basic")
            {
                string authToken = authHeader.Parameter; // Getting the authorization token
                byte[] authBytes = Convert.FromBase64String(authToken); // Converting the token from base64 to bytes
                authToken = Encoding.UTF8.GetString(authBytes); // Decoding the token to get username and password
                string[] usernamePassword = authToken.Split(':'); // Splitting username and password

                // Extracting username and password from the decoded token
                string username = usernamePassword[0];
                string password = usernamePassword[1];

                // Checking if the user exists and credentials match
                var user = _objBLUser.GetAllUsers().Any(u => u.R01F02 == username && u.R01F03 == password);

                if (user) // If user exists and credentials match
                {
                    var token = BLTokenManager.GenerateToken(username); // Generating JWT token for the user

                    var principal = BLTokenManager.GetPrincipal(token); // Getting claims principal from token

                    if (principal == null) // If principal is null
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                                                 "Invalid token"); // Returning unauthorized response
                    }

                    Thread.CurrentPrincipal = principal; // Setting current principal

                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, token); // Returning OK response with token
                }

                base.OnActionExecuting(actionContext); // Calling base implementation
            }
        }
    }
}