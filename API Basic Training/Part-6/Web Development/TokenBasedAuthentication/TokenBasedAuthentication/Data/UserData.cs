using System.Collections.Generic;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.Data
{
    /// <summary>
    /// Represents a class for managing user data.
    /// </summary>
    public class UserData
    {
        #region list of UsersDetail
        /// <summary>
        /// Retrieves a list of user details.
        /// </summary>
        /// <returns>List of user details.</returns>
        public static List<User> UsersDetail()
        {
            // Sample user data
            List<User> objUsers = new List<User>()
            {
                new User{ Id = 101, UserName = "Student", Password = "student123", Email ="student@gmail.com", Role = "Student"},
                new User{ Id = 102, UserName = "Teacher", Password = "teacher123", Email ="tacher@gmail.com", Role = "Teacher"},
                new User{ Id = 103, UserName = "Principal", Password = "principal123", Email ="principal@gmail.com", Role = "Principal"},
            };
            return objUsers;
        }
        #endregion
    }
}