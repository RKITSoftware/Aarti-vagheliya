using System;

namespace Overloading
{
    #region Class MathOperations
    /// <summary>
    /// Class representing mathematical operations.
    /// </summary>
    class MathOperations
    {
        /// <summary>
        /// Method to add two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The sum of the integers.</returns>
        public int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Method to add two doubles.
        /// </summary>
        /// <param name="a">The first double.</param>
        /// <param name="b">The second double.</param>
        /// <returns>The sum of the doubles.</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
    #endregion

    class Program
    {
        #region Main Method
        /// <summary>
        /// Main method to run the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            MathOperations math = new MathOperations();

            // Using overloaded methods to perform addition
            int resultInt = math.Add(5, 3);
            double resultDouble = math.Add(2.5, 3.7);

            Console.WriteLine($"Result (int): {resultInt}");
            Console.WriteLine($"Result (double): {resultDouble}");
        }
        #endregion
    }
}



