using Authorization.Models;
using System.Collections.Generic;

namespace Authorization.BL
{
    /// <summary>
    /// BLUser Class manages User Details.
    /// </summary>
    public class BLUser
    {
        //Private List of user to store User Details.
        private List<User> _lstUsers = new List<User>()
        {
             new User{ Id = 101, UserName = "Student", Password = "student123", Email ="student@gmail.com", Role = "Student"},
             new User{ Id = 102, UserName = "Teacher", Password = "teacher123", Email ="tacher@gmail.com", Role = "Teacher"},
             new User{ Id = 103, UserName = "Principal", Password = "principal123", Email ="principal@gmail.com", Role = "Principal"},
        };

        /// <summary>
        /// Retrieves a list of user details for demonstration purposes.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        public List<User> UsersDetail()
        { 
            return _lstUsers;
        }
    }
}