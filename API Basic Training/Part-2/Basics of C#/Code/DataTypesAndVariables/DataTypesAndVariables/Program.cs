using System;

namespace DataTypesAndVariables;

/// <summary>
/// This program demonstrates different data types and variables.
/// </summary>
class DataTypesAndVariables
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {
        //Declaration and Initialization of variables.
        int num = 10;
        float rate = 10.20f;
        double amount = 100.50;
        bool istodaySunaday = false;
        char n = 'A';
        string name = "Arti";

        //Display value of variables
        Console.WriteLine("num = "+num);
        Console.WriteLine("rate = "+rate);
        Console.WriteLine("Amount = "+amount);
        Console.WriteLine("today is Sunday = "+istodaySunaday);
        Console.WriteLine("Character = "+n);
        Console.WriteLine("name = "+name);
        Console.WriteLine();

        #region TypeCasting
        //TypeCasting of variable's datatypes
        int newamount = (int) amount;
        Console.WriteLine("TypeCasted Amount = "+ newamount);
        double newnum = (double) num;
        Console.WriteLine("Typecasted num = " + newnum);
        Console.WriteLine(Convert.ToString("Typecsting with method: "+ istodaySunaday));
        Console.WriteLine(Convert.ToInt32(n));
        #endregion
    }
}