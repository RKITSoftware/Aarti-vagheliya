using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Token_Custom.Filters;
using Token_Custom.Models;
using Token_Custom.Services;

namespace Token_Custom.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/auth")]
    //[RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login()
        {
            // Authenticate user (demo purposes)
            // In a real scenario, you would validate user credentials here

            // For demo purposes, let's create a simple token
            TokenService tokenService = new TokenService();
            var token = tokenService.GenerateToken("username"); // Pass your user identity here

            return Ok(new { Token = token });
        }


        //private readonly TokenService _tokenService;

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("login")]
        //public HttpResponseMessage Get()
        //{
        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}

        //[Route("Login")]
        //[AllowAnonymous]
        //[HttpPost]
        //public HttpResponseMessage Login(User user)
        //{
        //    try
        //    {
        //        // Check if the provided credentials are valid
        //        if (TokenAuthenticationService.ValidateCredentials(user.Username, user.Password))
        //        {
        //            // Generate a JWT token using the authentication service
        //            string token = TokenAuthenticationService.GenerateToken(user.Username);

        //            // Return an OK response with the JWT token
        //            return Request.CreateErrorResponse(HttpStatusCode.OK, token);
        //        }
        //        else
        //        {
        //            // Return an Unauthorized response with an error message
        //            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid credentials");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle any exceptions that might occur during token generation or validation
        //        // Log.Error($"An error occurred during authentication: {ex}");
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error occurred");
        //    }
        //}
    }
}
