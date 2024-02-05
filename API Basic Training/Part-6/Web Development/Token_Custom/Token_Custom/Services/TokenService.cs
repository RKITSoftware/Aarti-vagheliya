using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Token_Custom.Models;

namespace Token_Custom.Services
{
    /// <summary>
    /// Service for handling JWT token generation and validation.
    /// </summary>
    public static class TokenService
    {
        // Secret key used for token generation and validation
        private static readonly string _secretKey = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";


        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="userName">Username of the user.</param>
        /// <returns>Generated JWT token as a string.</returns>
        public static string GenerateToken(string userName)
        {
          
            byte[] key = Encoding.UTF8.GetBytes(_secretKey);

            // Retrieve user details based on the username
            var user = UserRepository.users.FirstOrDefault(u => u.Username == userName);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);

            // Token descriptor with user claims, expiration time, and signing credentials
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Consider making this configurable
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = handler.CreateJwtSecurityToken(tokenDescriptor);

            // Set Key ID (kid) in the token header
            jwtSecurityToken.Header.Add("kid", "RKIT");

            return handler.WriteToken(jwtSecurityToken);
        }




        /// <summary>
        /// Retrieves a ClaimsPrincipal from the provided JWT token.
        /// </summary>
        /// <param name="token">JWT token as a string.</param>
        /// <returns>ClaimsPrincipal if successful, null otherwise.</returns>
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                var jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                // Retrieve Key ID (kid) from the token header
                string keyId = jwtToken.Header?.Kid;

                if (jwtToken == null)
                {
                    return null;
                }

                // Use a different key for validation
                byte[] key = Encoding.UTF8.GetBytes(_secretKey);

                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, parameters, out securityToken);

                return principal;
            }
            catch (SecurityTokenExpiredException)
            {
                // Handle token expiration (returning null in this case)
                Console.WriteLine("Token has expired.");
                return null;
            }
            catch (Exception ex)
            {
                // Handle other token validation exceptions
                Console.WriteLine($"Token validation error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Validates token 
        /// </summary>
        /// <param name="token">JWT token</param>
        /// <returns>True if token is valid otherwise false</returns>
        public static bool ValidateToken(string token)
        {
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return false;
            return true;
        }


    }
}
    