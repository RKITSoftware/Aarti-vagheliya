using System;


namespace DefineAndCallingMethod
{
    #region class for reference
    /// <summary>
    /// Helper class containing utility methods for greeting users.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Greets the user with a "Good Morning" message.
        /// </summary>
        /// <param name="name">The name of the user to greet.</param>
        public static void GreetUser(string name)
        {
            // Display a greeting message to the user
            Console.WriteLine($"Good Morning {name}...");
        }
    }
    #endregion


    /// <summary>
    /// This program demonstrates the definition and calling of methods.
    /// </summary>
    class Program
    {
        #region Method without return type
        /// <summary>
        /// This method prints a greeting message.
        /// </summary>
        /// <param name="name">The name of the person to greet.</param>
        //Define a method without return type
        static void Greeting(String name)
        {
            Console.WriteLine("Hello {0}. Welcome to the world of RKIT...! ",name);
        }
        #endregion

        #region Method with return type
        /// <summary>
        /// This method calculates the factorial of a given number.
        /// </summary>
        /// <param name="num">The number for which to calculate the factorial.</param>
        /// <returns>The factorial of the input number.</returns>
        //define a method with return type
       public static int Factorial(int num)
        {
            int fact = 1;
            for(int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            //return type statement
            return fact;
        }
        #endregion

        #region DisplayInfo method with one optional parameter
        /// <summary>
        /// Method with one optional parameter.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="age">Age of the person (optional).</param>
        static void DisplayInfo(string name, int age = 21)
        {
            Console.WriteLine($"Name: {name}, Age: {age}");
        }

        #endregion

        #region DisplayInfo method with two optional parameter
        /// <summary>
        /// Method with two optional parameters.
        /// </summary>
        /// <param name="lastName">Last name of the person.</param>
        /// <param name="age">Age of the person (optional).</param>
        /// <param name="city">City of residence (optional).</param>
        static void DisplayInfo(string lastName, int age = 21, string city = "Unknown")
        {
            Console.WriteLine($"Last Name: {lastName}, Age: {age}, City: {city}");
        }
        #endregion

        #region Main method
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            //calling method Greeting
            Console.Write("Enter your name: ");
            String name = Console.ReadLine();
            Greeting(name);

            //Calling method Factorial
            Console.Write("Enter number for find factorial: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("factorial = {0}",Factorial(num));

            // Calling methods with optional parameters
           
            DisplayInfo("Jane", 25);
            DisplayInfo("Doe", 30, "New York");
        }
        #endregion


    }

    
}
