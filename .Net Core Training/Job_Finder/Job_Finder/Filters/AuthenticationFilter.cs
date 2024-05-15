using Job_Finder.BusinessLogic;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using NHibernate.Linq.Functions;
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Results;

namespace Job_Finder.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        private BLLogin _objBLLogin = new BLLogin();

        private BLTokenManager _objBLTokenManager = new();

        public static USR01 objUSR01 = new USR01();

        /// <summary>
        /// Defines flag indicating whether token is generated or not
        /// Checks if token is being generating for first time or already generated
        /// </summary>
        private static bool _isTokenGenerated = false;

       

        public void OnAuthorization(AuthorizationFilterContext context)
        {
           if (SkipAuthorization(context)) return;

            string authHeader = context.HttpContext.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic "))
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                try
                {
                    string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderVal.Parameter));

                    string[] userInfo = credentials.Split(':');
                    string username = userInfo[0];
                    string password = userInfo[1];

                    var user = _objBLLogin.ValidateUser(username, password);

                    if (user != null)
                    {
                        objUSR01 = user; // Sets current logged in user

                        var identity = new GenericIdentity(username);
                        identity.AddClaim(new Claim(ClaimTypes.Name, objUSR01.R01F02));
                        identity.AddClaim(new Claim("Id", Convert.ToString(objUSR01.R01F01)));

                        IPrincipal principal = new GenericPrincipal(identity, objUSR01.R01F05.ToString().Split(','));

                        Thread.CurrentPrincipal = principal;

                        context.HttpContext.User = (ClaimsPrincipal)principal;

                        // Checks if token is generated before
                        if (_isTokenGenerated == false)
                        {
                            _objBLTokenManager.GenerateToken(objUSR01);

                            _isTokenGenerated = true;

                            return;
                        }


                        var token = _objBLTokenManager.cache.Get("JWTToken_" + objUSR01.R01F02);

                        if (token != null)
                        {
                            token = _objBLTokenManager.RefreshToken(objUSR01);

                            if (token == null)
                            {
                                context.Result = new ObjectResult("Token is null")
                                {
                                    StatusCode = StatusCodes.Status500InternalServerError
                                };

                            }
                            return;
                        }
                        else
                        {
                            context.Result = new ObjectResult(StatusCodes.Status500InternalServerError);
                            _isTokenGenerated = false;
                        }
                    }
                    else
                    {
                        context.Result = new ObjectResult(StatusCodes.Status406NotAcceptable);
                    }
                }
                catch (FormatException)
                {
                    // Credentials were not formatted correctly.
                    context.HttpContext.Response.StatusCode = 401;
                }
            }
            else
            {
                context.Result = new ObjectResult(StatusCodes.Status400BadRequest);
            }
        }

        public static bool SkipAuthorization(AuthorizationFilterContext context)
        {
            Contract.Assert(context != null);
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                var actionAttributes =
                   descriptor.MethodInfo.GetCustomAttributes(inherit: true);
                if (actionAttributes.FirstOrDefault(a => a.GetType() == typeof(AllowAnonymousAttribute)) != null) return true;
            }
            return false;
        }
    }
}
