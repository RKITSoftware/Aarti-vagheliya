using System;
using System.Linq;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.BL
{
    /// <summary>
    /// Validates user credentials.
    /// </summary>
    public class Validate
    {
        /// <summary>
        /// Private instance of BLUser class.
        /// </summary>
        private BLUser _objBLUser = new BLUser();


        /// <summary>
        /// Validates the user credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>The User object if credentials are valid, otherwise null.</returns>
        public User ValidatedUser(string username, string password)
        {
            // Retrieve user details from data source and check if credentials match
            return _objBLUser.UsersDetail().FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password.Equals(password));
        }
    }
}