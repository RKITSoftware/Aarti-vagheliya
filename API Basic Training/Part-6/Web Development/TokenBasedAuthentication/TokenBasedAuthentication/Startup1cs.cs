using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using TokenBasedAuthentication.TokenProvider;
using static System.Net.WebRequestMethods;

[assembly: OwinStartup(typeof(TokenBasedAuthentication.Startup1cs))]

namespace TokenBasedAuthentication
{
    public class Startup1cs
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                //http and https
                AllowInsecureHttp = true,   
                TokenEndpointPath = new PathString("/token"), // https://localhost:44346/token
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new AuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
