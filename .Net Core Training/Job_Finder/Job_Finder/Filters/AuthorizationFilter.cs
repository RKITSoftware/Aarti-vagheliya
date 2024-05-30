using Job_Finder.BusinessLogic;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Job_Finder.Filters
{
    /// <summary>
    /// Filter for authorization based on user roles.
    /// </summary>
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        #region Private Member

        /// <summary>
        /// Token manager instance for managing JWT tokens.
        /// </summary>
        private BLTokenManager _objBLTokenManager = new();

        /// <summary>
        /// User handler instance for user-related operations.
        /// </summary>
        private BLUSR01Handler _objBLUSR01Handler = new BLUSR01Handler();

        #endregion

        #region Public Member

        /// <summary>
        /// Gets or sets the roles allowed to access the resource.
        /// </summary>
        public string Roles { get; set; }

        #endregion

        #region Public Method

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationFilter"/> class with specified roles.
        /// </summary>
        /// <param name="roles">The roles allowed to access the resource.</param>
        public AuthorizationFilter( string roles)
        {
            //_objBLTokenManager = new BLTokenManager(cache);
            Roles = roles;
        }

        /// <summary>
        /// Performs authorization based on user roles.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Skip authorization for methods marked with [AllowAnonymous]
            if (AuthenticationFilter.SkipAuthorization(context)) return;

            // Get the Authorization header from the request
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            // Check if the Authorization header is present and starts with "Bearer "
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                // Extract token from Authorization header
                var token = authorizationHeader.Substring("Bearer ".Length);

                // Check if the token is expired
                if (_objBLTokenManager.IsTokenExpired(token))
                {
                    // Return unauthorized response if the token is expired
                    context.Result = new ContentResult
                    {
                        Content = "Token has expired",
                        StatusCode = (int)HttpStatusCode.Unauthorized
                    };
                    return;
                }

                // Validate JWT token
                if (token != null && _objBLTokenManager.ValidateToken(token))
                {
                    // Extract and decode the JWT payload
                    string jwtEncodedPayload = token.Split('.')[1];

                    // Pad jwtEncodedPayload to make it Base64 valid
                    jwtEncodedPayload = jwtEncodedPayload.Replace('-', '+').Replace('_', '/');
                    int padding = 4 - (jwtEncodedPayload.Length % 4);
                    if (padding != 4)
                    {
                        jwtEncodedPayload += new string('=', padding);
                    }

                    // Decode the JWT payload
                    byte[] decodedPayloadBytes = Convert.FromBase64String(jwtEncodedPayload);
                    string decodedPayload = Encoding.UTF8.GetString(decodedPayloadBytes);
                    JObject json = JObject.Parse(decodedPayload);

                    // Retrieve the user from the database based on the unique name in the token
                    USR01 user = _objBLUSR01Handler.GetAllUsers().FirstOrDefault(u => u.R01F02 == json["unique_name"].ToString());

                    // Check if the user exists
                    if (user == null)
                    {
                        // Return unauthorized response if the user is not found
                        context.Result = new ContentResult
                        {
                            Content = "User not found",
                            StatusCode = (int)HttpStatusCode.Unauthorized
                        };
                        return;
                    }

                    // Get the roles for the user
                    string[] userRoles = Roles.Split(',');

                    // Check if the user has the required role
                    if (userRoles.Contains(user.R01F05.ToString()))
                    {
                        // Create an identity for the user
                        GenericIdentity identity = new GenericIdentity(user.R01F02);

                        // Add claims to the identity
                        identity.AddClaim(new Claim("Id", Convert.ToString(user.R01F01)));

                        // Create a principal for the user
                        IPrincipal principal = new GenericPrincipal(identity, user.R01F05.ToString().Split(','));

                        // Associate the principal with the current thread
                        Thread.CurrentPrincipal = principal;

                        // Set the principal for the current HTTP context
                        context.HttpContext.User = (ClaimsPrincipal)principal;
                    }
                }
                else
                {
                    // Return unauthorized response if the token validation fails
                    context.Result = new ContentResult
                    {
                        Content = "Authorization denied",
                        StatusCode = (int)HttpStatusCode.Unauthorized
                    };
                    return;
                }
            }
            else
            {
                // Return bad request response if the Authorization header is missing or not in the correct format
                context.Result = new ContentResult
                {
                    Content = "Authorization header is missing or not in the correct format",
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
        }


        #endregion
    }
}
