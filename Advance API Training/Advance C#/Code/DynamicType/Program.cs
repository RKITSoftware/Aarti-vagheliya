using System;
using System.Dynamic;

namespace DynamicType
{
    /// <summary>
    /// Demonstrates the usage of dynamic types in C#.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method of the program class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Creating a dynamic variable
            dynamic dynamicVariable;

            // Assigning different types of values to the dynamic variable

            dynamicVariable = 10;
            Console.WriteLine($"Dynamic variable value: {dynamicVariable}\n \"Type of this variable => {dynamicVariable.GetType()}\" ");
            Console.WriteLine();

            dynamicVariable = "Hello, dynamic!";
            Console.WriteLine($"Dynamic variable value: {dynamicVariable} \n \"Type of this variable => {dynamicVariable.GetType()}\" ");
            Console.WriteLine();

            dynamicVariable = new { Name = "John", Age = 30 };
            Console.WriteLine($"Dynamic variable value: Name: {dynamicVariable.Name}, Age: {dynamicVariable.Age} ");
            Console.WriteLine();

            // Accessing members dynamically
            dynamic dynamicObject = new ExpandoObject();
            dynamicObject.Name = "Alice";
            dynamicObject.Age = 25;
            Console.WriteLine($"Name: {dynamicObject.Name}, Age: {dynamicObject.Age}");
            Console.WriteLine();

            // Calling methods dynamically
            dynamic calculator = new Calculator();
            Console.WriteLine($"Addition result: {calculator.Add(5, 3)}");
            Console.WriteLine();

            // Using dynamic in a loop
            foreach (dynamic item in new dynamic[] { 1, "two", 3.0 })
            {
                Console.WriteLine($"Dynamic item: {item}");
            }
        }

       
        /// <summary>
        /// Sample class for dynamic method invocation
        /// </summary>
        public class Calculator
        {
            public int Add(int a, int b) => a + b;
        }
    }
}

