using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;


namespace TokenBasedAuthentication.TokenProvider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            Validate objValidate = new Validate();
           var user = objValidate.ValidatedUser(context.UserName, context.Password);

            if(user == null)
            {
                context.SetError("invalid_grant", "UserName or Password is incorrect!");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));   
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email)); 

            foreach(var role in user.Role.Split(',')) 
            { 
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Trim()));
            }
            context.Validated(identity);
        }
    }
}