using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Token_Custom.Services;

namespace Token_Custom.Filters
{
    public class JwtAuthenticationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authorizationHeader = actionContext.Request.Headers.Authorization;

            if (authorizationHeader == null || authorizationHeader.Scheme != "Bearer")
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                return;
            }

            var token = authorizationHeader.Parameter;

            TokenService tokenService = new TokenService();
            ClaimsPrincipal principal = tokenService.GetPrincipal(token);

            if (principal == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                return;
            }

            actionContext.RequestContext.Principal = principal;

            base.OnAuthorization(actionContext);
        }
    }

}