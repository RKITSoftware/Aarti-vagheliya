using CalculatorLibrary; // Import the CalculatorLibrary namespace
using System;

namespace CalculatorClient
{
    /// <summary>
    /// Represents a program to demonstrate the usage of the Calculator class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Create an instance of the Calculator class of CalculatorLibrary
            Calculator objCalculator = new Calculator();

            // Methods present in Calculator class from CalculatorLibrary
            Console.WriteLine("Addition :{0} ",objCalculator.Add(5, 5));
            Console.WriteLine("Subtraction :{0} ", objCalculator.Subtract(5, 5));
            Console.WriteLine("Division :{0} ", objCalculator.Divide(5, 5));

            //Method Present in Extension class
            Console.WriteLine("Multiplication : {0}",objCalculator.Multiply(5,5));
        }
    }
}
