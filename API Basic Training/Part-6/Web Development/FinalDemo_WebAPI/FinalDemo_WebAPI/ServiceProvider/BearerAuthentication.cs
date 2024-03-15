using FinalDemo_WebAPI.DAL;
using FinalDemo_WebAPI.Models;
using FinalDemo_WebAPI.UserRepository;
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

namespace FinalDemo_WebAPI.ServiceProvider
{
    public class BearerAuthentication : AuthorizationFilterAttribute
    {
        #region Private member

        // Instance of BLUser class for user authentication
        private BLUser _objBLUser = new BLUser();

        #endregion

        #region public method

        /// <summary>
        /// Method called when authorization is requested for the action method.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (BasicAuthentication.SkipAuthorization(actionContext)) return;

            string tokenValue = actionContext.Request.Headers.Authorization.Scheme; // Extracting the token value from the authorization header

            var isValid = BLTokenManager.ValidateToken(tokenValue); // Validating the token

            if (!isValid) // If token is not valid
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                                        "Enter valid token"); // Returning unauthorized response
            }
            else // If token is valid
            {
                // get jwt payload
                string jwtEncodedPayload = tokenValue.Split('.')[1]; // Extracting the payload from JWT token

                jwtEncodedPayload = jwtEncodedPayload.Replace('+', '-')
                                                     .Replace('/', '_')
                                                     .Replace("=", ""); // Normalizing the JWT payload

                // pad jwtEncodedPayload if needed
                int padding = jwtEncodedPayload.Length % 4;
                if (padding != 0)
                {
                    jwtEncodedPayload += new string('=', 4 - padding); // Padding the JWT payload if needed
                }

                // decode the jwt payload
                byte[] decodedPayloadBytes = Convert.FromBase64String(jwtEncodedPayload); // Decoding the JWT payload

                string decodedPayload = Encoding.UTF8.GetString(decodedPayloadBytes); // Decoding the payload string

                JObject json = JObject.Parse(decodedPayload); // Parsing the payload as JSON object

                User user = _objBLUser.GetAllUsers().FirstOrDefault(u => u.UserName == json["unique_name"].ToString()); // Getting user details from the payload

                // create an identity => i.e., attach username which is used to identify the user
                GenericIdentity identity = new GenericIdentity(user.UserName); // Creating a generic identity for the user

                // add claims for the identity => a claim has (claim_type, value)
                identity.AddClaim(new Claim("Id", Convert.ToString(user.UserId))); // Adding claims to the identity

                // create a principal that represent a user => it has an (identity object + roles)
                IPrincipal principal = new GenericPrincipal(identity, user.Roles.ToString().Split(',')); // Creating a principal for the user

                // now associate the user/principal with the thread
                Thread.CurrentPrincipal = principal; // Setting the current principal

                if (HttpContext.Current != null)
                {
                    // HttpContext is responsible for rq and res.
                    HttpContext.Current.User = principal; // Setting the user for the current HttpContext
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                                             "Authorization denied"); // Returning unauthorized response if HttpContext is null
                }
            }
        }

        #endregion
    }
}