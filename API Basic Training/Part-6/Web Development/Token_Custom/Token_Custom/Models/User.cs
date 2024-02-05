using System.Collections.Generic;

namespace Token_Custom.Models
{
    /// <summary>
    /// Represents a user entity with properties such as Id, Username, Password, and Role.
    /// </summary>
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
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

        /// <summary>
        /// Gets a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The user with the specified username, or null if not found.</returns>
        public User GetUserByUsername(string username)
        {
            return users.Find(u => u.Username == username);
        }
    }
}