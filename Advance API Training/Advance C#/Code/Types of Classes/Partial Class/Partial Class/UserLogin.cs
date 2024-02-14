using System;

namespace Partial_Class
{
    /// <summary>
    /// Partial class representing a user with registration and login functionalities.
    /// </summary>
    public partial class User 
    {
        // Partial method implementation for Login
        /// <summary>
        /// Partial method called during user login.
        /// </summary>
        partial void OnLogin()
        {
            Console.WriteLine("User login implementation for ILogin interface...");
        }
    }
}
