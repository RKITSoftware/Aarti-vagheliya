using Job_Finder.BusinessLogic;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Job_Finder.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private BLTokenManager _objBLTokenManager = new();

        private BLUSR01Handler _objBLUSR01Handler = new BLUSR01Handler();

        public string Roles { get; set; }

        public AuthorizationFilter( string roles)
        {
            //_objBLTokenManager = new BLTokenManager(cache);
            Roles = roles;
        } 

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (AuthenticationFilter.SkipAuthorization(context)) return;

            // Retrives token from cache
            string token = _objBLTokenManager.cache.Get("JWTToken_" + AuthenticationFilter.objUSR01.R01F02).ToString();

            // Validates token
            if (token != null && !_objBLTokenManager.IsTokenExpired(token) && _objBLTokenManager.ValidateToken(token))
            {
                // get jwt payload
                string jwtEncodedPayload = token.Split('.')[1];

                // pad jwtEncodedPayload
                jwtEncodedPayload = jwtEncodedPayload.Replace('+', '-')
                                                     .Replace('/', '_')
                                                     .Replace("=", "");

                int padding = jwtEncodedPayload.Length % 4;

                if (padding != 0)
                {
                    jwtEncodedPayload += new string('=', 4 - padding);
                }

                // decode the jwt payload
                byte[] decodedPayloadBytes = Convert.FromBase64String(jwtEncodedPayload);

                string decodedPayload = Encoding.UTF8.GetString(decodedPayloadBytes);

                JObject json = JObject.Parse(decodedPayload);

                USR01 user = _objBLUSR01Handler.GetAllUsers().FirstOrDefault(u => u.R01F02 == json["unique_name"].ToString());

                string[] userRoles = Roles.ToString().Split(',');

                if (!userRoles.Contains(user.R01F05.ToString()))
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                }
                else if (user != null)
                {
                    // create an identity => i.e., attach username which is used to identify the user
                    GenericIdentity identity = new GenericIdentity(user.R01F02);

                    // add claims for the identity => a claim has (claim_type, value)

                    identity.AddClaim(new Claim("Id", Convert.ToString(user.R01F01)));

                    string[] roles = user.R01F05.ToString().Split(',');

                    // create a principal that represent a user => it has an (identity object + roles)
                    IPrincipal principal = new GenericPrincipal(identity, roles);

                    // now associate the user/principal with the thread
                    Thread.CurrentPrincipal = principal;


                    context.HttpContext.User = (ClaimsPrincipal)principal;

                    return;
                }
            }
            else
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
