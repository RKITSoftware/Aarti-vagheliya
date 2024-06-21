using System;
using System.Collections.Generic;
using System.Linq;

namespace ListDemo
{

    /// <summary>
    /// The main class of the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {


            // Create a list of Flower objects
            List<Flower> flowers = new List<Flower>
            {
                new Flower { Id = 1, Name = "Rose", Color = "Red", Price = 10 },
                new Flower { Id = 2, Name = "Tulip", Color = "Yellow", Price = 8 },
                new Flower { Id = 3, Name = "Lily", Color = "White", Price = 12 },
                new Flower { Id = 4, Name = "Sunflower", Color = "Yellow", Price = 7 }
            };


            // Perform different LINQ queries on the list of Flower objects
            QueryFlowers(flowers);
        }


        /// <summary>
        /// Performs various LINQ queries on a list of flowers.
        /// </summary>
        /// <param name="flowers">The list of flowers.</param>
        static void QueryFlowers(List<Flower> flowers)
        {
           

            // Query 1: Select all flowers
            var allFlowers = from flower in flowers
                             select flower;
            Console.WriteLine("All Flowers:");
            foreach (var flower in allFlowers)
            {
                Console.WriteLine($"ID: {flower.Id}, Name: {flower.Name}, Color: {flower.Color}, Price: {flower.Price}");
            }
            Console.WriteLine();



            // Query 2: Select flowers with price less than 10
            var cheapFlowers = from flower in flowers
                               where flower.Price < 10
                               select flower;
            Console.WriteLine("Cheap Flowers (Price < $10):");
            foreach (var flower in cheapFlowers)
            {
                Console.WriteLine($"ID: {flower.Id}, Name: {flower.Name}, Color: {flower.Color}, Price: {flower.Price}");
            }
            Console.WriteLine();



            // Query 3: Select flowers with yellow color
            var yellowFlowers = from flower in flowers
                                where flower.Color == "Yellow"
                                select flower;
            Console.WriteLine("Yellow Flowers:");
            foreach (var flower in yellowFlowers)
            {
                Console.WriteLine($"ID: {flower.Id}, Name: {flower.Name}, Color: {flower.Color}, Price: {flower.Price}");
            }
            Console.WriteLine();



            // Query 4: Select the most expensive flower
            var mostExpensiveFlower = flowers.OrderByDescending(flower => flower.Price).FirstOrDefault();
            Console.WriteLine("Most Expensive Flower:");
            Console.WriteLine($"ID: {mostExpensiveFlower.Id}, Name: {mostExpensiveFlower.Name}, Color: {mostExpensiveFlower.Color}, Price: {mostExpensiveFlower.Price}");
            Console.WriteLine();


            // Query 5: Count the number of flowers
            var flowerCount = flowers.Count();
            Console.WriteLine($"Total Number of Flowers: {flowerCount}");
            Console.WriteLine();



            // Query 6: Check if any flower is of color 'Purple'
            var hasPurpleFlower = flowers.Any(flower => flower.Color == "Purple");
            Console.WriteLine($"Does the list contain a purple flower? {(hasPurpleFlower ? "Yes" : "No")}");
            Console.WriteLine();



            // Query 7: Find the average price of all flowers
            var averagePrice = flowers.Average(flower => flower.Price);
            Console.WriteLine($"Average Price of Flowers: ${averagePrice}");
            Console.WriteLine();
  


            // Query 8: Select flower names only
            var flowerNames = flowers.Select(flower => flower.Name);
            Console.WriteLine("Flower Names Only:");
            foreach (var name in flowerNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

        }
    }
}
