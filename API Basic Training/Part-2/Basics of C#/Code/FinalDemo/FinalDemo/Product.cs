using System;

namespace FinalDemo
{
    /// <summary>
    /// This class manage properties for Products
    /// </summary>
    public class ProductModel
    {
        #region Public Properties 

        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public int ProductId { get;  set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get;  set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get;  set; }

        /// <summary>
        /// Gets or sets the quantity of the product in stock.
        /// </summary>
        public int QuantityInStock { get;  set; }

        #endregion
    }

    /// <summary>
    /// Represents a product in the inventory.
    /// </summary>
    public class Product
    {
        #region  public Methods

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
                ProductModel newProduct = new ProductModel
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    QuantityInStock = quantityInStock
                };

                // Add the product to the inventory
                inventory.AddProduct(newProduct);
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
                ProductModel updatedProduct = new ProductModel
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    QuantityInStock = quantityInStock
                };

                // Update the product in the inventory
                inventory.UpdateProduct(updatedProduct);
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
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        #endregion

        #endregion

    }
}
