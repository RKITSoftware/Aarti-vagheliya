using System;

namespace FinalDemo
{
    /// <summary>
    /// Represents a product in the inventory.
    /// </summary>
    public class Product
    {
        #region Public Properties 

        // Properties with private setters for encapsulation

        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public int ProductId { get; private set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; private set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets or sets the quantity of the product in stock.
        /// </summary>
        public int QuantityInStock { get; private set; }

        #endregion

        #region  public Methods

        #region Encapsulated Interactions

        // Methods for encapsulated interactions

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

        /// <summary>
        /// Sets the price of the product.
        /// </summary>
        /// <param name="newPrice">The new price for the product.</param>
        public void SetPrice(decimal newPrice)
        {
            // Basic validation: ensure the new price is non-negative
            if (newPrice > 0)
            {
                Price = newPrice;
            }
            else
            {
                Console.WriteLine("Invalid price. Please provide a non-negative price.");
            }
        }

        /// <summary>
        /// Sets the new quantity of the product.
        /// </summary>
        /// <param name="newQuantity">The new quantity of the product.</param>
        public void SetQuantity(int newQuantity)
        {
            // Basic validation: ensure the new quantity is non-negative
            if (newQuantity > 0)
            {
                QuantityInStock = newQuantity;
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please provide a non-negative quantity.");
            }
        }

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

                // Create a new product
                Product newProduct = new Product
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    QuantityInStock = quantityInStock
                };

                // Add the product to the inventory
                inventory.AddProduct(newProduct);
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

                Console.Write("Enter new Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter new Price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter new Quantity in Stock: ");
                int quantityInStock = Convert.ToInt32(Console.ReadLine());

                // Create a new product
                Product updatedProduct = new Product
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    QuantityInStock = quantityInStock
                };

                // Update the product in the inventory
                inventory.UpdateProduct(updatedProduct);
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
        /// <param name="inventory">The inventory to remove the product from.</param>
        public static void RemoveProduct(Inventory inventory)
        {
            try
            {
                // Get product ID to remove
                Console.Write("Enter Product ID to remove: ");
                int productId = Convert.ToInt32(Console.ReadLine());

                // Remove the product from the inventory
                inventory.RemoveProduct(productId);
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

        #endregion

    }
}
