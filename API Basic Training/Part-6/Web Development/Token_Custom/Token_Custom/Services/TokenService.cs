using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace Token_Custom.Services
{
    public  class TokenService
    {
       private readonly string _secretKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";


        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_secretKey);

            byte[] key = Convert.FromBase64String(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public ClaimsPrincipal GetPrincipal(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out var securityToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }


    }

    //#region AuthServices
    ///// <summary>
    ///// Contains methods for token Authentication
    ///// </summary>
    //public static class TokenAuthenticationService
    //{
    //    /// <summary>
    //    /// Validates the provided username and password.
    //    /// </summary>
    //    /// <param name="userName">The username to validate.</param>
    //    /// <param name="password">The password associated with the username.</param>
    //    /// <returns>True if the credentials are valid; otherwise, false.</returns>
    //    public static bool ValidateCredentials(string userName, string password)
    //    {
    //        // Replace this with your actual logic to validate credentials
    //        return userName == "admin" && password == "password";
    //    }

    //    /// <summary>
    //    /// Generates a JWT token for the specified username.
    //    /// </summary>
    //    /// <param name="userName">The username to include in the JWT token.</param>
    //    /// <returns>The generated JWT token as a string.</returns>
    //    public static string GenerateToken(string userName)
    //    {
    //        // Use TokenManager or your token generation logic here
    //        return TokenService.GenerateToken(userName);
    //    }
    //}
    //#endregion
}