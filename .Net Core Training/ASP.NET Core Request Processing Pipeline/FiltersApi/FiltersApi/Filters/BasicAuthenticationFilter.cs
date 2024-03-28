using FiltersApi.BusinessLogic;
using FiltersApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;


namespace FiltersApi.Filters
{
    /// <summary>
    /// Basic authentication filter for validating user credentials.
    /// </summary>
    public class BasicAuthenticationFilter :Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Private instace of BLUser class
        /// </summary>
        private BLUser _objBLUser = new BLUser();

        /// <summary>
        /// Performs basic authentication.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        public void OnAuthorization (AuthorizationFilterContext context)
        {
            // Extract the Authorization header from the request
            string authHeader = context.HttpContext.Request.Headers["Authorization"];

            // Check if the Authorization header exists and starts with "Basic "
            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // Validate the scheme and parameter of the Authorization header
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) &&
                    authHeaderVal.Parameter != null)
                {
                    try
                    {
                        // Decode the base64-encoded credentials
                        string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderVal.Parameter));

                        // Split the decoded credentials into username and password
                        string[] userInfo = credentials.Split(':');
                        string username = userInfo[0];
                        string password = userInfo[1];

                        // Check if the user exists and the credentials are correct
                        if (CheckExists(username, password))
                        {
                            // Retrieve user details from the business logic layer
                            var user = UserDetails(username, password);

                            // Create a ClaimsIdentity containing user information
                            var identity = new GenericIdentity(username);
                            identity.AddClaim(new Claim(ClaimTypes.Name, user.R01F02));
                            identity.AddClaim(new Claim("Id", Convert.ToString(user.R01F01)));

                            // Create a ClaimsPrincipal containing the identity and roles
                            IPrincipal principal = new GenericPrincipal(identity, user.R01F04.ToString().Split(','));

                            Thread.CurrentPrincipal = principal;

                            // Assign the ClaimsPrincipal to the HttpContext User property
                            context.HttpContext.User = (ClaimsPrincipal)principal;
                            return;
                        }
                        else
                        {
                            // User not found or invalid credentials
                            context.Result = new UnauthorizedResult();
                        }
                    }
                    catch (FormatException)
                    {
                        // Credentials were not formatted correctly.
                        context.HttpContext.Response.StatusCode = 401;
                    }
                }
            }
            else
            {
                // Authorization header is missing or invalid
                context.Result = new UnauthorizedResult();
            }
        }

        /// <summary>
        /// Checks if the user exists.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <param name="passWord">The password.</param>
        /// <returns>True if the user exists; otherwise, false.</returns>
        private bool CheckExists(string userName, string passWord)
        {
            var user = _objBLUser.GetUsers().FirstOrDefault(u => u.R01F02 == userName && u.R01F03 == passWord);
            if (user != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Retrieves user details.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <param name="passWord">The password.</param>
        /// <returns>The user details.</returns>
        private USR01 UserDetails(string userName, string passWord)
        {
            return _objBLUser.GetUsers().FirstOrDefault(u => u.R01F02 == userName && u.R01F03 == passWord);
        }
        
    }
}
