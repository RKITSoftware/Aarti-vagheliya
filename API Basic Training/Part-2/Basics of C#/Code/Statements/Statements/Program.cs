using System;
using System.Diagnostics;

namespace Statements;

/// <summary>
/// Class demonstrating various C# statements including selection, iterative, and jump statements.
/// </summary>
class Statements
{
    #region Measure ForLoop Time

    /// <summary>
    /// Measures the execution time for a for loop.
    /// </summary>
    static void MeasureForLoopTime()
    {
        Console.WriteLine("For Loop Time Measurement:");

        // Set the number of iterations
        int iterations = 1000000;

        // Start the stopwatch
        Stopwatch stopwatch = Stopwatch.StartNew();

        // For loop
        for (int i = 0; i < iterations; i++)
        {
            // Some operation inside the loop
            int result = i * 2;
        }

        // Stop the stopwatch
        stopwatch.Stop();

        Console.WriteLine($"For loop execution time: {stopwatch.ElapsedMilliseconds} milliseconds");
        Console.WriteLine();
    }
    #endregion

    #region Measure Foreach Loop Time
    /// <summary>
    /// Measures the execution time for a foreach loop.
    /// </summary>
    static void MeasureForeachLoopTime()
    {
        Console.WriteLine("Foreach Loop Time Measurement:");

        // Set the number of iterations
        int iterations = 1000000;

        // Create a collection for the foreach loop
        int[] numbers = new int[iterations];

        // Start the stopwatch
        Stopwatch stopwatch = Stopwatch.StartNew();

        // Foreach loop
        foreach (var number in numbers)
        {
            // Some operation inside the loop
            int result = number * 2;
        }

        // Stop the stopwatch
        stopwatch.Stop();

        Console.WriteLine($"Foreach loop execution time: {stopwatch.ElapsedMilliseconds} milliseconds");
        Console.WriteLine();
    }
    #endregion

    static void Main(string[] args)
    {
        #region Selection Statement
        //Selection Statements

        #region IF statement
        //if Statement
        Console.WriteLine("if-Statement");
        int n = 50;
        if (n > 0)
        {
            Console.WriteLine("Number is positive");
        }
        #endregion

        #region else-if else 
        //else-if else statements
        int number = -5;
        if (number > 0)
        {
            Console.WriteLine("Number is positive");
        }
        else if (number == 0)
        {
            Console.WriteLine("Number is zero");
        }
        else
        {
            Console.WriteLine("Number is negative");
        }
        #endregion

        #region switch-case
        //switch - case
        int a = 5;
        switch (a)
        {
            case 0:
                Console.WriteLine("Sunday");
                break;
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
             case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            default:
                Console.WriteLine("Invalid number");
                break;
        }
        #endregion

        #endregion

        #region Iterative Statement
        //Iterative Statements
        #region For loop
        //for loop
        for (int i =0; i<5; i++) {
            Console.WriteLine(i);

        }
        #endregion

        #region do-while loop
        //do... while loop
        int j = 3;
        do
        {
            Console.WriteLine("In do-while... "+j);

        }while (j < 1);
        #endregion

        #region while loop
        //while loop
        int k = 3;
        while (k < 5)
        {
            Console.WriteLine(k);
            k++;
        }
        #endregion

        #region Foreach loop
        //foreach loop
        Console.WriteLine("Foreach loop..");
        int[] numbers = { 1, 2, 3, 4, 5 };

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
        #endregion

        #endregion

        #region Jump Statement
        //Jump Statements

        #region Break
        //break statement
        Console.WriteLine("break statement...");
        for (int i = 0; i < 10; i++)
        {
            if (i == 5)
                break;
            Console.WriteLine(i);
        }
        #endregion

        #region Continue statement
        //continue statement
        Console.WriteLine("continue Statement...");
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
                continue;
            Console.WriteLine(i);
        }
        #endregion

        //return statement
        //goto statement

        #region For Loop Time Measurement
        MeasureForLoopTime();
        #endregion

        #region Foreach Loop Time Measurement
        MeasureForeachLoopTime();
        #endregion
        #endregion
    }
}
