using System;


namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Single-dimensional Array
            string[] cars = { "Volvo", "BMW", "Ford", "KIA" };
            Console.WriteLine(cars[0]);
            Console.WriteLine(cars[1]);
            Console.WriteLine(cars[2]);
            Console.WriteLine(cars[3]);

            //Multi-dimensional Array
            int[,] num = { { 1, 2, 3 }, { 4, 5, 6 } };
        }
    }
}
