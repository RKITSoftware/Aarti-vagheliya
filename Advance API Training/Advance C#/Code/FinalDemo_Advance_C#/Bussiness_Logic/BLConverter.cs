using FinalDemo_Advance_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    public class BLConverter
    {
        public static string UserRoleToString(UserRole role)
        {
            return role.ToString();
        }

        public static UserRole StringToUserRole(string roleString)
        {
            if (Enum.TryParse(roleString, out UserRole role))
            {
                return role;
            }
            else
            {
                // Handle invalid or unknown role strings
                throw new ArgumentException("Invalid or unknown role string.");
            }
        }
    }
}