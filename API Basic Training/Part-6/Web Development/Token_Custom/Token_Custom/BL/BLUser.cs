using System.Collections.Generic;
using Token_Custom.Models;

namespace Token_Custom.BL
{
    /// <summary>
    /// BLUser class manages User details.
    /// </summary>
    public class BLUser
    {
        /// <summary>
        /// List of predefined users.
        /// </summary>
        public static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "user1", Password = "password1", Role = "User" },
            new User { Id = 2, Username = "user2", Password = "password2", Role = "Admin" }
        };
    }
}