using System;

namespace Debugging_Demo
{
    /// <summary>
    /// Demonstrate debugging in visual studio
    /// </summary>
    class Program
    {
       
        /// <summary>
        /// This method calculates the factorial of a given number.
        /// </summary>
        /// <param name="num">The number for which to calculate the factorial.</param>
        /// <returns>The factorial of the input number.</returns>
        public static int Factorial(int num)
        {
            int fact = 1;
            for (int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            //return type statement
            return fact;
        }

        /// <summary>
        /// main method of the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Debugging is enabled");
#else
            Console.WriteLine("This is a Release build");
#endif


            //Calling method Factorial
            Console.Write("Enter number for find factorial: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("factorial = {0}", Factorial(num));

            Console.WriteLine("------------------------------------------");

            // Create a Person object
            Person person = new Person
            {
                Name = "John Doe",
                Age = 30,
                HomeAddress = new Address { Street = "123 Main St", City = "New York" }
            };

            // Add details to the DataTable
            person.AddDetail("Occupation", "Software Developer");
            person.AddDetail("City", "New York");

            // Breakpoint here to inspect the person object and its DataTable
            Console.WriteLine("Debugging Demo - Set a breakpoint on this line.");
        }
    }
}
