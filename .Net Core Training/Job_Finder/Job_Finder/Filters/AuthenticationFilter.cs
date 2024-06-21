using Job_Finder.BusinessLogic;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using System.Text;

namespace Job_Finder.Filters
{
    /// <summary>
    /// Filter for authentication and authorization.
    /// </summary>
    public class AuthenticationFilter : IAuthorizationFilter
    {
        #region Private Member

        /// <summary>
        /// Helper class instance for business logic operations.
        /// </summary>
        private BLLogin _objBLLogin = new BLLogin();

        /// <summary>
        /// Token manager class instance for managing JWT tokens.
        /// </summary>
        private BLTokenManager _objBLTokenManager = new();

        /// <summary>
        /// Defines flag indicating whether token is generated or not
        /// Checks if token is being generating for first time or already generated
        /// </summary>
       // private static bool _isTokenGenerated = false;

        #endregion

        #region Public  Member

        /// <summary>
        /// Business logic class instance for user login operations.
        /// </summary>
        public static USR01 objUSR01 = new USR01();

        #endregion

        #region Public Method

        /// <summary>
        /// Performs authorization by validating the user credentials.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Retrieve the endpoint information
            var endpoint = context.HttpContext.GetEndpoint();

            // Check if the endpoint is excluded from authentication
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return; // Skip authentication for this endpoint
            }

            // Retrieve the Authorization header from the HTTP request
            string authHeader = context.HttpContext.Request.Headers["Authorization"];

            // Check if the Authorization header is present and starts with "Basic "
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                // Parse the Authorization header value as an AuthenticationHeaderValue
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                try
                {
                    // Decode the Base64-encoded credentials from the header
                    string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderVal.Parameter));

                    // Split the decoded credentials into username and password
                    string[] userInfo = credentials.Split(':');
                    string username = userInfo[0];
                    string password = userInfo[1];

                    // Validate the user using the provided username and password
                    var user = _objBLLogin.ValidateUser(username, password);

                    if (user != null)
                    {
                        // Generates token
                        var token = _objBLTokenManager.GenerateToken(user);

                        // Attaches principal to token
                        var principal = _objBLTokenManager.GetPrincipal(token);

                        if (principal == null)
                        {
                            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                            return;
                        }

                        //Set the current principal for the request
                        Thread.CurrentPrincipal = principal;

                        // Set the token as the result (if needed)
                        context.Result = new ContentResult
                        {
                            Content = token,
                            ContentType = "text/plain",
                            StatusCode = StatusCodes.Status200OK
                        };
                        return;
                    }
                    else
                    {
                        // User validation failed
                        context.Result = new ContentResult
                        {
                            Content = "Invalid username or password.",
                            ContentType = "text/plain",
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                        return;
                    }
                }
                catch (FormatException)
                {
                    // Credentials were not formatted correctly.
                    context.Result = new ContentResult
                    {
                        Content = "Invalid Authorization header format.",
                        ContentType = "text/plain",
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                    return;
                }
            }
            else
            {
                // No or invalid authorization header
                context.Result = new ContentResult
                {
                    Content = "Authorization header is missing or not in the correct format.",
                    ContentType = "text/plain",
                    StatusCode = StatusCodes.Status400BadRequest
                };
                return;
            }
        }

        /// <summary>
        /// Determines whether authorization should be skipped based on the presence of AllowAnonymous attribute.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        /// <returns>True if authorization should be skipped, otherwise false.</returns>
        public static bool SkipAuthorization(AuthorizationFilterContext context)
        {
            Contract.Assert(context != null);
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                var actionAttributes =
                   descriptor.MethodInfo.GetCustomAttributes(inherit: true);
                if (actionAttributes.FirstOrDefault(a => a.GetType() == typeof(AllowAnonymousAttribute)) != null) return true;
            }
            return false;
        }

        #endregion
    }
}
