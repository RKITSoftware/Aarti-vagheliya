using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Token_Custom.Models;
using Token_Custom.Services;

namespace Token_Custom.Filters
{
    /// <summary>
    /// Basic Authentication class for authorize user.
    /// </summary>
    public class JwtAuthenticationFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Authorize user data
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var authorizationHeader = actionContext.Request.Headers.Authorization;
            if (authorizationHeader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Login failed");
            }
            else if (authorizationHeader.Scheme != "Basic")
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;

                string[] usernamePassword = authToken.Split(':');

                //Extracts username and password from the decoded token.
                string username = usernamePassword[0];
                string password = usernamePassword[1];

                var user = UserRepository.users.Any(u => u.Username == username && u.Password == password);
                if (user )
                {
                    var token = TokenService.GenerateToken(username);
                    var principal = TokenService.GetPrincipal(token);

                    if (principal == null)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid token");
                    }

                    //Set the current principal for the request

                    Thread.CurrentPrincipal = principal;
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, token);
                }
            }
            base.OnActionExecuting(actionContext);
        }
    }

}
    
