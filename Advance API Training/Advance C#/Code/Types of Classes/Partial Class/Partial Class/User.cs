using System;

namespace Partial_Class
{
    // Define interfaces
    /// <summary>
    /// Interface for user registration functionality.
    /// </summary>
    public interface IRegister
    {
        void Register(string userName);
    }


    /// <summary>
    /// Interface for user login functionality.
    /// </summary>
    public interface ILogin
    {
        void Login(string userName);
    }


    // Define partial class User
    /// <summary>
    /// Partial class representing a user with registration and login functionalities.
    /// </summary>
    public partial class User : IRegister, ILogin
    {
        // Partial method declaration for Register
        /// <summary>
        /// Partial method called during user registration.
        /// </summary>
        partial void OnRegister();

        // Partial method declaration for Login
        /// <summary>
        /// Partial method called during user login.
        /// </summary>
        partial void OnLogin();


        /// <summary>
        /// Register method implementation from IRegister interface.
        /// </summary>
        /// <param name="username">Username to register.</param>
        public void Register(string username)
        {
            Console.WriteLine($"Registering user with username: {username}");
            // Call the partial method
            OnRegister();
        }

        /// <summary>
        /// Login method implementation from ILogin interface.
        /// </summary>
        /// <param name="username">Username to login.</param>
        public void Login(string username)
        {
            Console.WriteLine($"Logging in user with username: {username}");
            // Call the partial method
            OnLogin();
        }
    }
}
