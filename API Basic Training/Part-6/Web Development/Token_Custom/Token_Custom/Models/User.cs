using System.Collections.Generic;

namespace Token_Custom.Models
{
    /// <summary>
    /// Represents a user entity with properties such as Id, Username, Password, and Role.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Represents the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Represents the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Represents the role of the user.
        /// </summary>
        public string Role { get; set; }

    }


    /// <summary>
    /// Repository class for managing users and providing user-related operations.
    /// </summary>
    public class UserRepository
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