
using System;


namespace FinalDemo
{
    /// <summary>
    /// The main program class for the Inventory Tracker application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            //Product product = new Product();
            //Category category = new Category();
            Inventory inventory = new Inventory();

            while (true)
            {
                #region Choice list
                Console.WriteLine($"===== Inventory Tracker - {DateTime.Now} =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Remove Product");
                Console.WriteLine("4. Add Category");
                Console.WriteLine("5. Update Category");
                Console.WriteLine("6. Remove Category");
                Console.WriteLine("7. Display Products");
                Console.WriteLine("8. Display Categories");
                Console.WriteLine("0. Exit");
                #endregion

                Console.Write("Enter your choice (0-8): ");
                string choice = Console.ReadLine();

                // Log user action with timestamp
                LogAction($"User selected option: {choice}");

                #region Menu Driven loop
                switch (choice)
                {
                    case "1":
                       Product.AddProduct(inventory);
                        break;
                    case "2":
                        Product.UpdateProduct(inventory);
                        break;
                    case "3":
                        Product.RemoveProduct(inventory);
                        break;
                    case "4":
                        Category.AddCategory(inventory);
                        break;
                    case "5":
                        Category.UpdateCategory(inventory);
                        break;
                    case "6":
                        Category.RemoveCategory(inventory);
                        break;
                    case "7":
                        inventory.DisplayProducts();
                        break;
                    case "8":
                        inventory.DisplayCategories();
                        break;
                    case "0":
                        Console.WriteLine("Exiting program. Goodbye!");
                        LogAction("User exited the program");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
                #endregion

                Console.WriteLine(); // Add a line break for better readability
            }
        }

        #region LogAction

        /// <summary>
        /// Logs user actions with a timestamp.
        /// </summary>
        /// <param name="action">The action to log.</param>
        static void LogAction(string action)
        {
            Console.WriteLine($"{DateTime.Now} - {action}");
        }
        #endregion
    }
}

