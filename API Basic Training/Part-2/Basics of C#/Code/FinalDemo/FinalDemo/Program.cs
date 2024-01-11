﻿
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
                        AddProduct(inventory);
                        break;
                    case "2":
                        UpdateProduct(inventory);
                        break;
                    case "3":
                        RemoveProduct(inventory);
                        break;
                    case "4":
                        AddCategory(inventory);
                        break;
                    case "5":
                        UpdateCategory(inventory);
                        break;
                    case "6":
                        RemoveCategory(inventory);
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

        
        #region Add Product

        /// <summary>
        /// Adds a new product to the inventory.
        /// </summary>
        /// <param name="inventory">The inventory to which the product will be added.</param>
        static void AddProduct(Inventory inventory)
        {
            try
            {
                // Get product details from the user
                Console.Write("Enter Product ID: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter Price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Quantity in Stock: ");
                int quantityInStock = Convert.ToInt32(Console.ReadLine());

                // Validate the input
                if (productId <= 0 || price < 0 || quantityInStock < 0)
                {
                    throw new ArgumentException("Invalid input. Please provide valid values for Product ID, Price, and Quantity in Stock.");
                }

                // Create a new product and add it to the inventory
                Product newProduct = new Product(productId, productName, price, quantityInStock);
                inventory.AddProduct(newProduct);

                //Console.WriteLine("Product added to inventory.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        #endregion

        #region Update Product

        /// <summary>
        /// Updates an existing product in the inventory.
        /// </summary>
        /// <param name="inventory">The inventory containing the product to be updated.</param>
        static void UpdateProduct(Inventory inventory)
        {
            try
            {
                // Get updated product details from the user
                Console.Write("Enter Product ID to update: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                Product updatedProduct = new Product(productId, "", 0, 0); // Dummy values, will be updated

                Console.Write("Enter new Product Name: ");
                updatedProduct.SetProductName(Console.ReadLine());

                Console.Write("Enter new Price: ");
                updatedProduct.SetPrice(Convert.ToDecimal(Console.ReadLine()));

                Console.Write("Enter new Quantity in Stock: ");
                updatedProduct.AddStock(Convert.ToInt32(Console.ReadLine()));

                // Update the product in the inventory
                inventory.UpdateProduct(updatedProduct);

                //Console.WriteLine("Product updated successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        #endregion

        #region Remove Product

        /// <summary>
        /// Removes a product from the inventory.
        /// </summary>
        /// <param name="inventory">The inventory to remove the product from.</param
        static void RemoveProduct(Inventory inventory)
        {
            try
            {
                // Get product ID to remove
                Console.Write("Enter Product ID to remove: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                // Remove the product from the inventory
                inventory.RemoveProduct(productId);

                //Console.WriteLine("Product removed from inventory.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        #endregion

        #region Add Category

        /// <summary>
        /// Adds a new category to the inventory.
        /// </summary>
        /// <param name="inventory">The inventory to add the category to.</param>
        static void AddCategory(Inventory inventory)
        {
            try
            {
                // Get category details from the user
                Console.Write("Enter Category ID: ");
                int categoryId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Category Name: ");
                string categoryName = Console.ReadLine();

                // Validate the input
                if (categoryId <= 0)
                {
                    throw new ArgumentException("Invalid Category ID. Please provide a positive integer value.");
                }

                // Create a new category and add it to the inventory
                Category newCategory = new Category(categoryId, categoryName);
                inventory.AddCategory(newCategory);

                //Console.WriteLine("Category added to inventory.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        #endregion

        #region Update Category

        /// <summary>
        /// Updates an existing category in the inventory.
        /// </summary>
        /// <param name="inventory">The inventory containing the category to be updated.</param>
        static void UpdateCategory(Inventory inventory)
        {
            try
            {
                // Get updated category details from the user
                Console.Write("Enter Category ID to update: ");
                int categoryId = Convert.ToInt32(Console.ReadLine());

                Category updatedCategory = new Category(categoryId, ""); // Dummy value, will be updated

                Console.Write("Enter new Category Name: ");
                updatedCategory.SetCategoryName(Console.ReadLine());

                // Update the category in the inventory
                inventory.UpdateCategory(updatedCategory);

                //Console.WriteLine("Category updated successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
        #endregion

        #region Remove Category

        /// <summary>
        /// Removes a category from the inventory.
        /// </summary>
        /// <param name="inventory">The inventory to remove the category from.</param>
        static void RemoveCategory(Inventory inventory)
        {
            try
            {
                // Get category ID to remove
                Console.Write("Enter Category ID to remove: ");
                int categoryId = Convert.ToInt32(Console.ReadLine());

                // Remove the category from the inventory
                inventory.RemoveCategory(categoryId);

                //Console.WriteLine("Category removed from inventory.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid input. The provided value is too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        #endregion

        // Log user actions with timestamp
        static void LogAction(string action)
        {
            Console.WriteLine($"{DateTime.Now} - {action}");
        }
    }
}
