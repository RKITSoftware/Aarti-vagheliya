using System;

namespace Partial_Class
{
    /// <summary>
    /// Partial class representing a user with registration and login functionalities.
    /// </summary>
    public partial class User
    {
        // Partial method implementation for Register
        /// <summary>
        /// Partial method called during user registration.
        /// </summary>
        partial void OnRegister()
        {
            Console.WriteLine("User registration implementation for IRegister interface...");
        }
    }
}
