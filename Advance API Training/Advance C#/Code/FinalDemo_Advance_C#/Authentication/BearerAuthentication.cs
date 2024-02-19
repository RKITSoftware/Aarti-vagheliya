using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
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

namespace FinalDemo_Advance_C_.Authentication
{
    public class BearerAuthentication : AuthorizationFilterAttribute
    {
        private BLUser _objBLUser = new BLUser();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string tokenValue = actionContext.Request.Headers.Authorization.Scheme;

            var isValid = BLTokenManager.ValidateToken(tokenValue);

            if (!isValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                                        "Enter valid token");
            }
            else
            {
                // get jwt payload
                string jwtEncodedPayload = tokenValue.Split('.')[1];

                jwtEncodedPayload = jwtEncodedPayload.Replace('+', '-')
                                                     .Replace('/', '_')
                                                     .Replace("=", "");

                
                // pad jwtEncodedPayload if needed
                int padding = jwtEncodedPayload.Length % 4;
                if (padding != 0)
                {
                    jwtEncodedPayload += new string('=', 4 - padding);
                }

                // decode the jwt payload
                byte[] decodedPayloadBytes = Convert.FromBase64String(jwtEncodedPayload);

                string decodedPayload = Encoding.UTF8.GetString(decodedPayloadBytes);

                JObject json = JObject.Parse(decodedPayload);

                USR01 user = _objBLUser.GetAllUsers().FirstOrDefault(u => u.R01F02 == json["unique_name"].ToString());


                // create an identity => i.e., attach username which is used to identify the user
                GenericIdentity identity = new GenericIdentity(user.R01F02);

                // add claims for the identity => a claim has (claim_type, value)
                identity.AddClaim(new Claim("Id", Convert.ToString(user.R01F01)));

                // create a principal that represent a user => it has an (identity object + roles)
                IPrincipal principal = new GenericPrincipal(identity, user.R01F05.ToString().Split(','));

                // now associate the user/principal with the thread
                Thread.CurrentPrincipal = principal;

                if (HttpContext.Current != null)
                {
                    // HttpContext is responsible for rq and res.
                    HttpContext.Current.User = principal;
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                                             "Authorization denied");
                }
            }
        }
    }
}