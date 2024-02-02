using FinalDemo_WebAPI.ServiceProvider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(FinalDemo_WebAPI.DAL.Startup1))]

namespace FinalDemo_WebAPI.DAL
{
    /// <summary>
    /// Configuration class for OWIN startup.
    /// </summary>
    public class Startup1
    {
        /// <summary>
        /// Configures the OWIN pipeline for the application.
        /// </summary>
        /// <param name="app">The OWIN application builder.</param>
        public void Configuration(IAppBuilder app)
        {
           
            // Enable Cross-Origin Resource Sharing (CORS)
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Configure OAuth token generation and consumption
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                // AllowInsecureHttp is set to true for testing purposes; it should be false in production
                AllowInsecureHttp = true,   // Allow HTTP for testing purposes, should be false in production 
                TokenEndpointPath = new PathString("/token"), // Token endpoint URL (e.g., https://localhost:44333/token )
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(15),
                Provider = new TokenAuthorizationServerProvider()
            };

            // Configure the OWIN middleware to handle OAuth authorization server functionality.
            app.UseOAuthAuthorizationServer(options);

            // Configure the OWIN middleware to handle OAuth bearer token authentication.
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            // Configure Web API
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
