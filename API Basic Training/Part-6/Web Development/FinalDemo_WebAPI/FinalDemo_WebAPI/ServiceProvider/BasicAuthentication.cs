using FinalDemo_WebAPI.BL;
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FinalDemo_WebAPI.ServiceProvider
{
    /// <summary>
    /// This class for perform Basic Auhtentication.
    /// </summary>
    public class BasicAuthentication : ActionFilterAttribute
    { 
        #region public method

        /// <summary>
        /// Method executed before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext)) return;

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
                var user = BLUser.lstUsers.Any(u => u.UserName == username && u.PassWord == password);

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

        /// <summary>
        /// To allow anonymous users to access endpoint
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        public static bool SkipAuthorization(HttpActionContext actionContext)
        {
            // Check precondition and if false then terminate application.
            // Use Contract.Assert to ensure that the actionContext is not null.
            Contract.Assert(actionContext != null);

            // Check if the action or controller has the AllowAnonymousAttribute.
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        #endregion

    }
}