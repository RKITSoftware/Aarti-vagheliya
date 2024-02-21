using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing JWT token operations.
    /// </summary>
    public class BLTokenManager
    {
        #region Private member

        /// <summary>
        /// Secret key for hashing.
        /// </summary>
        private static readonly string _secretKey = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates a JWT token.
        /// </summary>
        /// <param name="userName">The user name for whom the token is generated.</param>
        /// <returns>The generated JWT token.</returns>
        public static string GenerateToken(string userName)
        {
            byte[] key = Convert.FromBase64String(_secretKey); // Convert the secret key from Base64 string to byte array

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key); // Create a symmetric security key using the key

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor // Create a security token descriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, userName) // Set the subject of the token to the user name
                }),
                Expires = DateTime.UtcNow.AddMinutes(30), // Set the expiration time of the token
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature) // Set the signing credentials for the token
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler(); // Create a JWT security token handler

            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor); // Create a JWT token using the descriptor

            return handler.WriteToken(token); // Return the written token as a string
        }

        /// <summary>
        /// Retrieves the principal from a JWT token.
        /// </summary>
        /// <param name="token">The JWT token.</param>
        /// <returns>The claims principal extracted from the token.</returns>
        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler(); // Create a JWT security token handler

                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token); // Read the JWT token

                if (jwtToken == null) // Check if the JWT token is null
                    return null;

                byte[] key = Convert.FromBase64String(_secretKey); // Convert the secret key from Base64 string to byte array

                TokenValidationParameters parameters = new TokenValidationParameters() // Set token validation parameters
                {
                    RequireExpirationTime = true, // Set to require expiration time
                    ValidateIssuer = false, // Disable issuer validation
                    ValidateAudience = false, // Disable audience validation
                    IssuerSigningKey = new SymmetricSecurityKey(key) // Set the issuer signing key
                };

                SecurityToken securityToken; // Variable to hold the security token

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken); // Validate the token and get the claims principal

                return principal; // Return the claims principal
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in Get Principal : {ex.Message}");
            }
        }

       
        /// <summary>
            /// Validates a JWT token.
            /// </summary>
            /// <param name="token">The JWT token to validate.</param>
            /// <returns>True if the token is valid, otherwise false.</returns>
        public static bool ValidateToken(string token)
        {
            ClaimsPrincipal principal = GetPrincipal(token); // Get the claims principal from the token
            if (principal == null) // Check if the principal is null
                return false; // Return false if the principal is null
            return true; // Return true otherwise
        }

        #endregion
    }
}