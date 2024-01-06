using System;


namespace DefineAndCallingMethod
{
    internal class Program
    {
        //Define a method without return type
        static void Greeting(String name)
        {
            Console.WriteLine("Hello {0}. Welcome to the world of RKIT...! ",name);
        }

        //define a method with return type
        static int Factorial(int num)
        {
            int fact = 1;
            for(int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            //return type statement
            return fact;
        }
        static void Main(string[] args)
        {
            //calling method Greeting
            Console.Write("Enter your name: ");
            String name = Console.ReadLine();
            Greeting(name);

            //Calling method Factorial
            Console.Write("Enter number for find factorial: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("factorial = {0}",Factorial(num));
        }
    }
}
