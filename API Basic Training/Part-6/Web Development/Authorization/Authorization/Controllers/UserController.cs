﻿using Authorization.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Authorization.Controllers
{
    /// <summary>
    /// Controller responsible for managing user-related operations.
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// Retrieves a list of user details for demonstration purposes.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        public static List<User> UsersDeatil()
        {
            List<User> oobjUsers = new List<User>()
            { 
                new User{ Id = 101, UserName = "Student", Password = "student123", Email ="student@gmail.com", Role = "Student"},
                new User{ Id = 102, UserName = "Teacher", Password = "teacher123", Email ="tacher@gmail.com", Role = "Teacher"},
                new User{ Id = 103, UserName = "Principal", Password = "principal123", Email ="principal@gmail.com", Role = "Principal"},
            };
            return oobjUsers;
        }
    }
}
