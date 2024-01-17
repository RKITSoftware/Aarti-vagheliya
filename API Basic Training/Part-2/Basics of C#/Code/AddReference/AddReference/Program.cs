using System;
using DefineAndCallingMethod;

namespace AddReference
{
    /// <summary>
    /// Entry point for the AddReference project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method representing the starting point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Call the GreetUser method from the Helper class
            Helper.GreetUser("Arti");


        }
    }
}
