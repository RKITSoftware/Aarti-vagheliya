using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;



namespace TokenBasedAuthentication.TokenProvider
{
    /// <summary>
    /// Custom OAuth Authorization Server Provider.
    /// </summary>
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        #region ValidateClientAuthentication

        /// <summary>
        /// Validates the client authentication.
        /// </summary>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Validates the client and allows the request to proceed.
            context.Validated();
        }

        #endregion

        #region GrantResourceOwnerCredentials

        /// <summary>
        /// Grants the resource owner credentials.
        /// </summary>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Validates user credentials
            Validate objValidate = new Validate();
           var user = objValidate.ValidatedUser(context.UserName, context.Password);

            if(user == null)
            {
                // Set error response if credentials are invalid
                context.SetError("invalid_grant", "UserName or Password is incorrect!");
                return;
            }

            // Create claims identity for the authenticated user
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));   
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            // Add role claims
            foreach (var role in user.Role.Split(',')) 
            { 
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Trim()));
            }

            // Validate and establish the user's identity
            context.Validated(identity);
        }

        #endregion
    }
}