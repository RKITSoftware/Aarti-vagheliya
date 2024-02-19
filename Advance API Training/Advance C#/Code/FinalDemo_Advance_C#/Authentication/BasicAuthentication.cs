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
    public class BasicAuthentication : ActionFilterAttribute
    {
        private BLUser _objBLUser = new BLUser();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;

            if(authHeader == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized,
                                        "invalid headers");
            }
            else if(authHeader.Scheme == "Basic")
            {
                string authToken = authHeader.Parameter;
                byte[] authBytes = Convert.FromBase64String(authToken);
                authToken = Encoding.UTF8.GetString(authBytes);
                string[] usernamePassword = authToken.Split(':');

                //Extracts username and password from the decoded token.
                string username = usernamePassword[0];
                string password = usernamePassword[1];

                var user = _objBLUser.GetAllUsers().Any(u => u.R01F02 == username && u.R01F03 == password);

                if(user != null)
                {
                    var token = BLTokenManager.GenerateToken(username);

                    var principal = BLTokenManager.GetPrincipal(token);

                    if(principal == null)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                                                 "Invalid token");
                    }

                    Thread.CurrentPrincipal = principal;

                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, token);
                }

                base.OnActionExecuting(actionContext);
            }
        }
    }
}