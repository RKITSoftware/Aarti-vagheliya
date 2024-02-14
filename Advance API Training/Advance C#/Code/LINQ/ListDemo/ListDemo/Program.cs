using System;
using System.Collections.Generic;
using System.Linq;

namespace ListDemo
{
    /// <summary>
    /// Represents a flower.
    /// </summary>
    class Flower
    {
        #region Properties

        /// <summary>
        /// Gets or sets the ID of the flower.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the flower.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the color of the flower.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the price of the flower.
        /// </summary>
        public int Price { get; set; }

        #endregion
    }

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
            #region list of Flower objects

            // Create a list of Flower objects
            List<Flower> flowers = new List<Flower>
            {
                new Flower { Id = 1, Name = "Rose", Color = "Red", Price = 10 },
                new Flower { Id = 2, Name = "Tulip", Color = "Yellow", Price = 8 },
                new Flower { Id = 3, Name = "Lily", Color = "White", Price = 12 },
                new Flower { Id = 4, Name = "Sunflower", Color = "Yellow", Price = 7 }
            };

            #endregion

            // Perform different LINQ queries on the list of Flower objects
            QueryFlowers(flowers);
        }


        /// <summary>
        /// Performs various LINQ queries on a list of flowers.
        /// </summary>
        /// <param name="flowers">The list of flowers.</param>
        static void QueryFlowers(List<Flower> flowers)
        {
            #region Select all flowers

            // Query 1: Select all flowers
            var allFlowers = from flower in flowers
                             select flower;
            Console.WriteLine("All Flowers:");
            foreach (var flower in allFlowers)
            {
                Console.WriteLine($"ID: {flower.Id}, Name: {flower.Name}, Color: {flower.Color}, Price: {flower.Price}");
            }
            Console.WriteLine();

            #endregion

            #region Select flowers with price less than 10

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

            #endregion

            #region Select flowers with yellow color

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

            #endregion

            #region Select the most expensive flower

            // Query 4: Select the most expensive flower
            var mostExpensiveFlower = flowers.OrderByDescending(flower => flower.Price).First();
            Console.WriteLine("Most Expensive Flower:");
            Console.WriteLine($"ID: {mostExpensiveFlower.Id}, Name: {mostExpensiveFlower.Name}, Color: {mostExpensiveFlower.Color}, Price: {mostExpensiveFlower.Price}");

            #endregion
        }
    }
}
