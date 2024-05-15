using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using TokenBasedAuthentication.TokenProvider;


[assembly: OwinStartup(typeof(TokenBasedAuthentication.Startup))]

namespace TokenBasedAuthentication
{
    /// <summary>
    /// Startup class for configuring the OWIN middleware.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the OWIN middleware.
        /// </summary>
        /// <param name="app">The OWIN application builder.</param>
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            // Enable Cross-Origin Resource Sharing (CORS)
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Configure OAuth token generation and consumption
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                //http and https
                AllowInsecureHttp = true,   // Allow HTTP for testing purposes, should be false in production 
                TokenEndpointPath = new PathString("/token"), // Token endpoint URL (e.g., https://localhost:44346/token )
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new AuthorizationServerProvider()
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
