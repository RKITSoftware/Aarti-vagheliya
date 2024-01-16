using System;


namespace StaticClass
{
    /// <summary>
    /// Static class representing information about a college.
    /// </summary>
    static class MyCollege
    {
        public static string collegeName;
        public static string city;

        /// <summary>
        /// Static constructor initializes static properties.
        /// </summary>
        static MyCollege()
        {
            collegeName = "Darshan";
            city = "Rajkot";
        }

       

        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The sum of the two integers.</returns>
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }

    /// <summary>
    /// Main program class containing the entry point.
    /// </summary>

    public class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Displaying college information and calling static method.
            Console.WriteLine($"College = {MyCollege.collegeName}");
            Console.WriteLine($"City = {MyCollege.city}");
            Console.WriteLine($"Calling Static method: {MyCollege.Add(5, 6)}");
        }
    }
}
