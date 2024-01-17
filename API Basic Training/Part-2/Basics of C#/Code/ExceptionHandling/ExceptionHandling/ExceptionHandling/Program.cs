using System;

namespace ExceptionHandling
{
    /// <summary>
    /// Demonstrates various aspects of exception handling in C#.
    /// </summary>

    class ExceptionHandlingDemo
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        static void Main()
        {
            try
            {
                // Uncomment and test each method individually

                //DivideByZeroException
                //DivideByZeroExceptionDemo();

                // FormatException
                // FormatExceptionDemo();

                // IndexOutOfRangeException
                // IndexOutOfRangeExceptionDemo();

                // ArgumentNullException
                // ArgumentNullExceptionDemo();

                // CustomException
                // CustomExceptionDemo();

                Console.WriteLine("End of the program (this line will not be reached if an exception occurs).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.GetType().Name} - {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Finally block always executes.");
            }
        }

        /// <summary>
        /// Demonstrates a DivideByZeroException scenario.
        /// </summary>
        static void DivideByZeroExceptionDemo()
        {
            int result = Divide(10, 0);
            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Demonstrates a FormatException scenario.
        /// </summary>
        static void FormatExceptionDemo()
        {
            int number = ParseInt("abc");
            Console.WriteLine($"Parsed number: {number}");
        }

        /// <summary>
        /// Demonstrates an IndexOutOfRangeException scenario.
        /// </summary>
        static void IndexOutOfRangeExceptionDemo()
        {
            int[] numbers = { 1, 2, 3 };
            int value = GetElementAtIndex(numbers, 5);
            Console.WriteLine($"Element at index 5: {value}");
        }

        /// <summary>
        /// Demonstrates an ArgumentNullException scenario.
        /// </summary>
        static void ArgumentNullExceptionDemo()
        {
            string result = ConcatenateStrings(null, "world");
            Console.WriteLine($"Concatenated string: {result}");
        }

        /// <summary>
        /// Demonstrates a CustomException scenario.
        /// </summary>
        static void CustomExceptionDemo()
        {
            try
            {
                ProcessData(-5);
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine($"Custom Exception caught: {ex.Message}");
            }
        }

        /// <summary>
        /// Performs integer division.
        /// </summary>
        static int Divide(int a, int b)
        {
            return a / b;
        }

        /// <summary>
        /// Parses a string into an integer.
        /// </summary>
        static int ParseInt(string value)
        {
            return int.Parse(value);
        }

        /// <summary>
        /// Retrieves an element at a specified index from an array.
        /// </summary>
        static int GetElementAtIndex(int[] array, int index)
        {
            return array[index];
        }

        /// <summary>
        /// Concatenates two strings.
        /// </summary>
        static string ConcatenateStrings(string str1, string str2)
        {
            return str1 + str2;
        }

         /// <summary>
        /// Processes data and throws a custom exception for negative numbers.
        /// </summary>
        static void ProcessData(int number)
        {
            if (number < 0)
            {
                throw new NegativeNumberException("Negative numbers are not allowed.");
            }

            // Process the data...
        }
    }

    /// <summary>
    /// Represents a custom exception for negative numbers.
    /// </summary>
    class NegativeNumberException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeNumberException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public NegativeNumberException(string message) : base(message)
        {
        }
    }
}
