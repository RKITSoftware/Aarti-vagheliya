using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace FinalDemo
{
    /// <summary>
    /// Represents a products in the inventory.
    /// </summary>
    public class Product
    {
        #region Public Properties 

        // Properties with private setters for encapsulation
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityInStock { get; private set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">The unique identifier for the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <param name="price">The price of the product.</param>
        /// <param name="quantityInStock">The quantity of the product in stock.</param>
        public Product(int productId, string productName, decimal price, int quantityInStock)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            QuantityInStock = quantityInStock;
        }
        #endregion

        #region Encapsulated Interactions

        // Methods for encapsulated interactions

        #region SetProductName
        /// <summary>
        /// Sets the name of the product.
        /// </summary>
        /// <param name="newName">The new name for the product.</param>
        public void SetProductName(string newName)
        {
            // Basic validation: ensure the new name is not empty
            if (!string.IsNullOrWhiteSpace(newName))
            {
                ProductName = newName;
            }
            else
            {
                Console.WriteLine("Invalid product name. Please provide a non-empty name.");
            }
        }
        #endregion

        #region SetPrice 

        /// <summary>
        /// Sets the price of the product.
        /// </summary>
        /// <param name="newPrice">The new price for the product.</param>
        public void SetPrice(decimal newPrice)
        {
            // Basic validation: ensure the new price is non-negative
            if (newPrice >= 0)
            {
                Price = newPrice;
            }
            else
            {
                Console.WriteLine("Invalid price. Please provide a non-negative price.");
            }
        }
        #endregion

        #region SetQuantity
        /// <summary>
        /// sets the new quanity of the product.
        /// </summary>
        /// <param name="newQuantity">new quantity of the product.</param>
        public void SetQuantity(int newQuantity)
        {
            // Basic validation: ensure the new quantity is non-negative
            if (newQuantity >= 0)
            {
                QuantityInStock = newQuantity;
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please provide a non-negative quantity.");
            }
        }
        #endregion

        #endregion



        #region Add Product

        /// <summary>
        /// Adds a new product to the inventory.
        /// </summary>
        /// <param name="inventory">The inventory to which the product will be added.</param>
        public static void AddProduct(Inventory inventory)
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
         public static void UpdateProduct(Inventory inventory)
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
                updatedProduct.SetQuantity(Convert.ToInt32(Console.ReadLine()));

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
       public static void RemoveProduct(Inventory inventory)
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

    }
}
