using System;

namespace Partial_Class
{
    /// <summary>
    /// This class represents the main entry point of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method serves as the entry point for the program.
        /// </summary>
        /// <param name="args">Array of command-line arguments.</param>
        static void Main(string[] args)
        {
            // Create an instance of User
            User objUser = new User();

            // Take input for registration
            Console.WriteLine("Enter username for registration:");
            string username = Console.ReadLine();

            // Register the user
            objUser.Register(username);

            Console.WriteLine();

            // Take input for login
            Console.WriteLine("Enter username for login:");
            string loginUsername = Console.ReadLine();

            // Login the user
            objUser.Login(loginUsername);

            Console.ReadLine();

        }
    }
}
