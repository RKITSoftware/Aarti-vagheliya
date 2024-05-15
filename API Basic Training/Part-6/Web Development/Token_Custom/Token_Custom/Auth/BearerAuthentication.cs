using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Token_Custom.BL;
using Token_Custom.Models;
using Token_Custom.Services;

namespace Token_Custom.Auth
{
    /// <summary>
    /// BearerAuthentication class 
    /// </summary>
    public class BearerAuthentication : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Authenticates user using user's JWT token
        /// </summary>
        /// <param name="actionContext">Information of executing context</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            string tokenValue = actionContext.Request.Headers.Authorization.Scheme;

            // check jwt token's validity
            var isValid = TokenService.ValidateToken(tokenValue);

            // if jwt is invalid (corrupted-jwt or jwt-expired) then return unauthorized
            if (!isValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Enter valid token");
            }
            else
            {
                // Extract the JWT payload from the token by splitting it at the '.' and taking the second part.
                string jwtEncodedPayload = tokenValue.Split('.')[1];

                // Add padding to the jwtEncodedPayload to ensure it's a multiple of 4.
                // JWT payloads are Base64Url encoded and might require padding.
                jwtEncodedPayload = jwtEncodedPayload + new string('=', (4 - (jwtEncodedPayload.Length % 4)));

                // Decode the Base64Url encoded jwt payload into a byte array.
                byte[] decodedPayloadBytes = Convert.FromBase64String(jwtEncodedPayload);

                // Convert the byte array to a UTF-8 encoded string to get the actual JSON payload.
                string decodedPayload = Encoding.UTF8.GetString(decodedPayloadBytes);

                // Parse the JSON payload into a JObject for easier manipulation.
                JObject json = JObject.Parse(decodedPayload);

                // Find the user in the users list whose username matches the 'unique_name' from the JWT payload.
                User user = BLUser.users.FirstOrDefault(u => u.Username == json["unique_name"].ToString());

                // Create a new GenericIdentity using the found user's username.
                // This identity will be used to represent the user in the application.
                GenericIdentity identity = new GenericIdentity(user.Username);

                // add claims for the identity => a claim has (claim_type, value)
                identity.AddClaim(new Claim("Name", Convert.ToString(user.Username)));

                // create a principal that represent a user => it has an (identity object + roles)
                IPrincipal principal = new GenericPrincipal(identity, user.Role.Split(','));

                // now associate the user/principal with the thread
                Thread.CurrentPrincipal = principal;

                if (HttpContext.Current != null)
                {
                    // HttpContext is responsible for rq and res.
                    HttpContext.Current.User = principal;
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization denied");
                }
            }
        }
    }
}