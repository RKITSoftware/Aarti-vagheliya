using FinalDemo_WebAPI.Models;
using System.Linq;

namespace FinalDemo_WebAPI.UserRepository
{
    /// <summary>
    /// Utility class for validating user credentials and collecting user details.
    /// </summary>
    public class ValidateUser
    {
        #region Public methods

        #region Exist

        /// <summary>
        /// Checks if a user with the given username and password exists.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>True if a matching user is found; otherwise, false.</returns>
        public static bool Exist(string username, string password)
        {
            // Check if any user matches the given username and password.
            return BLUser._users.Any(user => user.UserName.Equals(username) && user.PassWord == password);
        }

        #endregion

        #region CollectUserDetail

        /// <summary>
        /// Retrieves user details for the first user that matches the given username and password.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <param name="password">The password to match.</param>
        /// <returns>The user details if a match is found; otherwise, null.</returns>
        public static User CollectUserDetail(string username, string password)
        {
            // Retrieve the first user that matches the given username and password.
            return BLUser._users.FirstOrDefault(user => user.UserName.Equals(username) && user.PassWord == password);

        }

        #endregion

        #endregion
    }
}