using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Middleware_Filter_Integration.BusinessLogic;
using Middleware_Filter_Integration.Model.POCO;
using ServiceStack.OrmLite;
using System.Data;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Middleware_Filter_Integration.Filter
{
    /// <summary>
    /// Authorization filter for basic authentication.
    /// </summary>
    public class AuthorizationFilter : IAuthorizationFilter
    {
        #region Private Members

        /// <summary>
        /// Database connection factory.
        /// </summary>
        private BLConnection _dbConnection;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilter"/> class.
        /// </summary>
        /// <param name="connection">The database connection factory.</param>
        public AuthorizationFilter(BLConnection connection)
        {
            _dbConnection = connection;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method that is called on authorization.
        /// </summary>
        /// <param name="context">Authorization filter context.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
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
                            USR01 user = UserDetails(username, password);

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
                    catch 
                    {
                        // Credentials were not formatted correctly.
                        context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    }
                }
            }
            else
            {
                // Authorization header is missing or invalid
                context.Result = new UnauthorizedResult();
            }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Checks if the user exists with the given username and password.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <param name="passWord">The password.</param>
        /// <returns>True if the user exists, otherwise false.</returns>
        private bool CheckExists(string userName, string passWord)
        {
            using (IDbConnection db = _dbConnection.OpenConnection())
            {
                USR01 exists = db.Single<USR01>(u => u.R01F02 == userName && u.R01F03 == passWord);
                if (exists != null)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Retrieves the user details for the given username and password.
        /// </summary>
        /// <param name="userName">The username.</param>
        /// <param name="passWord">The password.</param>
        /// <returns>The user details.</returns>
        private USR01 UserDetails(string userName, string passWord)
        {
            using(IDbConnection db = _dbConnection.OpenConnection())
            {
                USR01 user = db.Single<USR01>(u => u.R01F02 == userName && u.R01F03 == passWord);
                return user;
            }
        }

        #endregion
    }
}
