using System;

class ExceptionHandlingDemo
{
    static void Main()
    {
        try
        {
            // Uncomment and test each method individually

            // DivideByZeroException
            // DivideByZeroExceptionDemo();

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

    // DivideByZeroException
    static void DivideByZeroExceptionDemo()
    {
        int result = Divide(10, 0);
        Console.WriteLine($"Result: {result}");
    }

    // FormatException
    static void FormatExceptionDemo()
    {
        int number = ParseInt("abc");
        Console.WriteLine($"Parsed number: {number}");
    }

    // IndexOutOfRangeException
    static void IndexOutOfRangeExceptionDemo()
    {
        int[] numbers = { 1, 2, 3 };
        int value = GetElementAtIndex(numbers, 5);
        Console.WriteLine($"Element at index 5: {value}");
    }

    // ArgumentNullException
    static void ArgumentNullExceptionDemo()
    {
        string result = ConcatenateStrings(null, "world");
        Console.WriteLine($"Concatenated string: {result}");
    }

    // CustomException
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

    static int Divide(int a, int b)
    {
        return a / b;
    }

    static int ParseInt(string value)
    {
        return int.Parse(value);
    }

    static int GetElementAtIndex(int[] array, int index)
    {
        return array[index];
    }

    static string ConcatenateStrings(string str1, string str2)
    {
        return str1 + str2;
    }

    static void ProcessData(int number)
    {
        if (number < 0)
        {
            throw new NegativeNumberException("Negative numbers are not allowed.");
        }

        // Process the data...
    }
}

// Custom Exception
class NegativeNumberException : Exception
{
    public NegativeNumberException(string message) : base(message)
    {
    }
}
