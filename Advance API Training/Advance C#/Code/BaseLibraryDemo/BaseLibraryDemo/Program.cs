using CustomStackLibrary;
using System;

namespace BaseLibraryDemo
{
    /// <summary>
    /// A class to demonstrate the usage of the CustomStack class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            #region Integer Stack Implemetation
            // Create an instance of CustomStack for integers
            CustomStack<int> intStack = new CustomStack<int>();

            // Push some elements onto the stack
            intStack.Push(10);
            intStack.Push(20);
            intStack.Push(30);

            // Peek at the top element
            Console.WriteLine("Peek: " + intStack.Peek());

            // Pop elements until the stack is empty
            Console.WriteLine("Popping elements:");
            while (intStack.Count > 0)
            {
                Console.WriteLine(intStack.Pop());
            }

            #endregion

            #region String Stack Implemetation
            // Create an instance of CustomStack for strings
            CustomStack<string> stringStack = new CustomStack<string>();

            // Push some strings onto the stack
            stringStack.Push("Hello");
            stringStack.Push("RKITians...");
            stringStack.Push("Good Morning..!");

            // Pop elements from the string stack
            Console.WriteLine("Popping strings:");
            while (stringStack.Count > 0)
            {
                Console.WriteLine(stringStack.Pop());
            }

            #endregion
        }
    }
}
    