using System;
namespace Statements;

/// <summary>
/// Class demonstrating various C# statements including selection, iterative, and jump statements.
/// </summary>
class Statements
{
    static void Main(string[] args)
    {
        //Selection Statements

        //if Statement
        Console.WriteLine("if-Statement");
        int n = 50;
        if (n > 0)
        {
            Console.WriteLine("Number is positive");
        }

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

        //Iterative Statements
        //for loop
        for(int i =0; i<5; i++) {
            Console.WriteLine(i);

        }

        //do... while loop
        int j = 3;
        do
        {
            Console.WriteLine("In do-while... "+j);

        }while (j < 1);

        //while loop
        int k = 3;
        while (k < 5)
        {
            Console.WriteLine(k);
            k++;
        }

        //foreach loop
        Console.WriteLine("Foreach loop..");
        int[] numbers = { 1, 2, 3, 4, 5 };

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }


        //Jump Statements
        //break statement
        Console.WriteLine("break statement...");
        for (int i = 0; i < 10; i++)
        {
            if (i == 5)
                break;
            Console.WriteLine(i);
        }

        //continue statement
        Console.WriteLine("continue Statement...");
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
                continue;
            Console.WriteLine(i);
        }

        //return statement
        //goto statement

    }
}
