﻿using FinalDemo_WebAPI.UserRepository;
using System;
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
    /// <summary>
    /// Custom authorization filter for basic authentication in Web API.
    /// </summary>
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Overrides the default authorization logic to perform basic authentication.
        /// </summary>
        /// <param name="actionContext">The context for the action.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null) 
            {
                // Responds with unauthorized status if no authorization header is found.
                actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed.");
            }
            else
            {
                try
                {
                    // Retrieves and decodes the authentication token from the authorization header.
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;
                    //username:password base64 encoded

                    string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                    string[] usernamePassword = decodedAuthToken.Split(':');

                    // Extracts username and password from the decoded token.
                    string username = usernamePassword[0];
                    string password = usernamePassword[1];

                    // Validates user credentials.
                    if (ValidateUser.Exist(username, password))
                    {
                        // Collects user details for creating identity claims.
                        var UserDetails = ValidateUser.CollectUserDetail(username, password);

                        // Creates a new identity and adds claims.
                        var identity = new GenericIdentity(username);
                        identity.AddClaim(new Claim(ClaimTypes.Name, UserDetails.UserName));
                        identity.AddClaim(new Claim(ClaimTypes.Email, UserDetails.Email));
                        identity.AddClaim(new Claim("ID", Convert.ToString(UserDetails.UserId)));

                        // Creates a principal with the provided identity and role claims.
                        IPrincipal principal = new GenericPrincipal(identity, UserDetails.Roles.Split(','));

                        // Sets the current principal for the executing thread.
                        Thread.CurrentPrincipal = principal;

                        // Sets the current user for the HTTP context.
                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }
                        else
                        {
                            // Responds with unauthorized status if HTTP context is not available.
                            actionContext.Response = actionContext.Request
                           .CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization denied.");
                        }
                    }
                    else
                    {
                        // Responds with unauthorized status for invalid credentials.
                        actionContext.Response = actionContext.Request
                            .CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Credentials.");
                    }
                }
                catch (Exception)
                {
                    // Responds with internal server error for unexpected exceptions.
                    actionContext.Response = actionContext.Request
                            .CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error...");
                }
            }
        }
    }
}