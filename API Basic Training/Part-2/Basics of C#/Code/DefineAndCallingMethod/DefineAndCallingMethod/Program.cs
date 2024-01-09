using System;


namespace DefineAndCallingMethod
{
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
        static int Factorial(int num)
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
        }
        #endregion
    }
}
