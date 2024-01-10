using System;

namespace DataTypesAndVariables;

/// <summary>
/// This program demonstrates different data types and variables.
/// </summary>
class DataTypesAndVariables
{
    #region Boxing Method
    /// <summary>
    /// Demonstrates boxing by converting a value type to an object.
    /// </summary>
    static void BoxingDemo()
    {
        Console.WriteLine("Boxing Demo:");

        int intValue = 42;

        // Boxing: Converting int to object
        object boxedValue = intValue;

        Console.WriteLine($"Original int value: {intValue}");
        Console.WriteLine($"Boxed value: {boxedValue}");

        Console.WriteLine();
    }
    #endregion

    #region UnBoxing Method
    /// <summary>
    /// Demonstrates unboxing by converting an object back to a value type.
    /// </summary>
    static void UnboxingDemo()
    {
        Console.WriteLine("Unboxing Demo:");

        object boxedValue = 42;

        // Unboxing: Converting object back to int
        int intValue = (int)boxedValue;

        Console.WriteLine($"Original boxed value: {boxedValue}");
        Console.WriteLine($"Unboxed int value: {intValue}");

        Console.WriteLine();
    }
    #endregion

    /// <summary>
    /// The entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {
        #region Declaration & Initialization
        //Declaration and Initialization of variables.
        int num = 10;
        float rate = 10.20f;
        double amount = 100.50;
        bool istodaySunaday = false;
        char n = 'A';
        string name = "Arti";

        #endregion

        #region Display value

        //Display value of variables
        Console.WriteLine("num = "+num);
        Console.WriteLine("rate = "+rate);
        Console.WriteLine("Amount = "+amount);
        Console.WriteLine("today is Sunday = "+istodaySunaday);
        Console.WriteLine("Character = "+n);
        Console.WriteLine("name = "+name);
        Console.WriteLine();
        #endregion

        #region TypeCasting
        //TypeCasting of variable's datatypes
        int newamount = (int) amount;
        Console.WriteLine("TypeCasted Amount = "+ newamount);
        double newnum = (double) num;
        Console.WriteLine("Typecasted num = " + newnum);
        Console.WriteLine(Convert.ToString("Typecsting with method: "+ istodaySunaday));
        Console.WriteLine(Convert.ToInt32(n));
        int doubleValue = 123;
        decimal decimalValue = Convert.ToDecimal(doubleValue);
        Console.WriteLine($"Original double value: {doubleValue}");
        Console.WriteLine($"Converted decimal value: {decimalValue}");

        Console.WriteLine();
        #endregion

        #region Boxing Demo
        BoxingDemo();
        #endregion

        #region Unboxing Demo
        UnboxingDemo();
        #endregion
    }
}