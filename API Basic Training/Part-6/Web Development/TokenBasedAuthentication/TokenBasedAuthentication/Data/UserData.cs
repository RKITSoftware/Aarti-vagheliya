using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.Data
{
    public class UserData
    {
        public static List<User> UsersDetail()
        {
            List<User> objUsers = new List<User>()
            {
                new User{ Id = 101, UserName = "Student", Password = "student123", Email ="student@gmail.com", Role = "Student"},
                new User{ Id = 102, UserName = "Teacher", Password = "teacher123", Email ="tacher@gmail.com", Role = "Teacher,Student"},
                new User{ Id = 103, UserName = "Principal", Password = "principal123", Email ="principal@gmail.com", Role = "Principal"},
            };
            return objUsers;
        }
    }
}