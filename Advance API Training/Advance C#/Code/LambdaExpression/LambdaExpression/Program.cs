using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpression
{
    /// <summary>
    /// Contains the entry point and methods to demonstrate lambda expressions and LINQ.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Defining a lambda expression to get the maximum of two integers.
            Func<int, int, int> getBigInteger;
            getBigInteger = (x, y) => { if (x > y) return x; else return y; };
            Console.Write("max number = ");
            Console.WriteLine(getBigInteger(10, 15));

            Console.WriteLine();


            // Finding even numbers from a list using lambda expression.
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);

            Console.WriteLine("Even Numbers:");
            foreach (var num in evenNumbers)
            {
                Console.Write("{0} ", num);
            }

            Console.WriteLine();
            Console.WriteLine();


            // Using lambda expressions with LINQ to project and select properties from a list of dogs.
            List<Dog> dogs = new List<Dog>() 
            {
                new Dog { Name = "Rex", Age = 4 },
                new Dog { Name = "Sean", Age = 0 },
                new Dog { Name = "Stacy", Age = 3 }
            };

            // Selecting names of dogs.
            Console.WriteLine("name of Dogs: ");
            var names = dogs.Select(x => x.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);

            }
            Console.WriteLine();


            // Creating a new list of anonymous types with age and first letter of name.
            var newDogsList = dogs.Select(x => new { Age = x.Age, FirstLetter = x.Name[0] });
            foreach (var item in newDogsList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
