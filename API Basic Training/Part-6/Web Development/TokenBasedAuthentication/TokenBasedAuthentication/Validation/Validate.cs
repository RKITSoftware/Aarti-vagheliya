using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenBasedAuthentication.Models;
using TokenBasedAuthentication.Data;

namespace TokenBasedAuthentication.TokenProvider
{
    public class Validate
    {
        public User ValidatedUser(string username, string password)
        {
           return UserData.UsersDetail().FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password.Equals(password));
        }
    }
}