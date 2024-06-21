using Job_Finder.Model.POCO;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Caching;
using System.Security.Claims;
using System.Text;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Manages JSON Web Tokens (JWT) for user authentication and authorization.
    /// </summary>
    public class BLTokenManager
    {
        #region Private member

        /// <summary>
        /// Secret key for hashing.
        /// </summary>
        private static readonly string _secretKey = "ERMN05OPLoDvbTTa/QkqLNMI7cPLguaRyHzyg7n5qNBVjQmtBhz4SzYh4NBVCXi3KJHlSXKP+oi2+bXr6CUYTR==";

        #endregion

        #region Public Member

        /// <summary>
        /// In-memory cache instance.
        /// </summary>
        public MemoryCache cache = MemoryCache.Default;

        /// <summary>
        /// Prefix for cache keys used for storing JWT tokens.
        /// </summary>
        public const string CachePrefix = "JWTToken_";

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates a JWT token for the specified user and stores it in the cache.
        /// </summary>
        /// <param name="user">The user for whom the token is generated.</param>
        public string GenerateToken(USR01 user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.R01F02),
                    new Claim(ClaimTypes.Role, user.R01F05.ToString()) // Add roles as claims
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            string cacheKey = CachePrefix + user.R01F02;

            cache.Set(cacheKey, tokenString, new CacheItemPolicy { AbsoluteExpiration = DateTime.UtcNow.AddMinutes(20) });

            return tokenString; 
        }

        /// <summary>
        /// Refreshes the JWT token for the specified user if it exists in the cache.
        /// </summary>
        /// <param name="user">The user for whom the token is refreshed.</param>
        /// <returns>The new JWT token if the refresh is successful; otherwise, null.</returns>
        public string RefreshToken(USR01 user)
        {
            // Check if token exists in cache
            if (cache.Contains(CachePrefix + user.R01F02))
            {
                string token = (string)cache.Get(CachePrefix + user.R01F02);
                var key = Encoding.UTF8.GetBytes(_secretKey);

                var tokenHandler = new JwtSecurityTokenHandler();
                // Retrieve token from cache
                JwtSecurityToken oldToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                // Update expiration time
                var newExpiration = DateTime.UtcNow.AddMinutes(20); // Refresh for another 20 minutes
                var newTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(oldToken.Claims),
                    Expires = newExpiration,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                // Generate new token
                var newToken = tokenHandler.CreateToken(newTokenDescriptor);
                var tokenString = tokenHandler.WriteToken(newToken);
                string cacheKey = CachePrefix + user.R01F02;

                //Update token in cache
                cache.Set(cacheKey, tokenString, new CacheItemPolicy { AbsoluteExpiration = DateTime.UtcNow.AddMinutes(20) });
                Debug.WriteLine(tokenString);
                return tokenString;
            }

            // Token not found in cache
            return "Token not found in cache."; 
        }

        /// <summary>
        /// Gets the principal (user) from the specified JWT token.
        /// </summary>
        /// <param name="token">The JWT token.</param>
        /// <returns>The claims principal extracted from the token; otherwise, null.</returns>
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                if (jwtToken == null)
                    return null;

                byte[] key = Encoding.UTF8.GetBytes(_secretKey);

                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken securityToken;

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Validates the specified JWT token.
        /// </summary>
        /// <param name="token">The JWT token to validate.</param>
        /// <returns>True if the token is valid; otherwise, false.</returns>
        public bool ValidateToken(string token)
        {
            ClaimsPrincipal principal = GetPrincipal(token); // Get the claims principal from the token
            if (principal == null) // Check if the principal is null
                return false; // Return false if the principal is null
            return true; // Return true otherwise
        }

        /// <summary>
        /// Checks if the specified JWT token has expired.
        /// </summary>
        /// <param name="token">The JWT token to check.</param>
        /// <returns>True if the token has expired; otherwise, false.</returns>
        public bool IsTokenExpired(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

            var expiration = jwtToken.ValidTo;

            return expiration < DateTime.UtcNow;
        }

        #endregion
    }
}
