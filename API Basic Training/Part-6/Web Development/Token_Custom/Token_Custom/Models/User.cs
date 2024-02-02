using System.Collections.Generic;

namespace Token_Custom.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }


    public class UserRepository
    {
        public static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "user1", Password = "password1", Role = "User" },
            new User { Id = 2, Username = "user2", Password = "password2", Role = "Admin" }
        };

        public User GetUserByUsername(string username)
        {
            return users.Find(u => u.Username == username);
        }
    }
}