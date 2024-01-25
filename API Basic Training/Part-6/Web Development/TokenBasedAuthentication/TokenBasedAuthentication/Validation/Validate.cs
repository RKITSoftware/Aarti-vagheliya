using System;
using System.Linq;
using TokenBasedAuthentication.Models;
using TokenBasedAuthentication.Data;

namespace TokenBasedAuthentication.TokenProvider
{
    /// <summary>
    /// Validates user credentials.
    /// </summary>
    public class Validate
    {
        /// <summary>
        /// Validates the user credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The User object if credentials are valid, otherwise null.</returns>
        public User ValidatedUser(string username, string password)
        {
            // Retrieve user details from data source and check if credentials match
            return UserData.UsersDetail().FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password.Equals(password));
        }
    }
}