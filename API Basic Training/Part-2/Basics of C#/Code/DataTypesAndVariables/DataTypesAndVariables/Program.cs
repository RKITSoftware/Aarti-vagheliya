using System;

namespace DataTypesAnsVariavles;

class DataTypesAndVariables
{
    static void Main(string[] args)
    {
        int num = 10;
        float rate = 10.20f;
        double amount = 100.50;
        bool istodaySunaday = false;
        char n = 'A';
        string name = "Arti";


        Console.WriteLine("num = "+num);
        Console.WriteLine("rate = "+rate);
        Console.WriteLine("Amount = "+amount);
        Console.WriteLine("today is Sunday = "+istodaySunaday);
        Console.WriteLine("Character = "+n);
        Console.WriteLine("name = "+name);

        //TypeCasting

        int newamount = (int) amount;
        Console.WriteLine("TypeCasted Amount = "+ newamount);
        double newnum = (double) num;
        Console.WriteLine("Typecasted num = " + newnum);
        Console.WriteLine(Convert.ToString("Typecsting with method: "+ istodaySunaday));
        Console.WriteLine(Convert.ToInt32(n));
    }
}