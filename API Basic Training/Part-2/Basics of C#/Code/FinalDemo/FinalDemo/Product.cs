using System;
using System.Collections.Generic;

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

        #region AddStock

        /// <summary>
        /// Adds stock to the product.
        /// </summary>
        /// <param name="quantity">The quantity to add to the stock.</param>
        public void AddStock(int quantity)
        {
            // Basic validation: ensure the added quantity is non-negative
            if (quantity >= 0)
            {
                QuantityInStock += quantity;
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please provide a non-negative quantity.");
            }
        }
        #endregion

        #region Sell

        /// <summary>
        /// Sells a quantity of the product.
        /// </summary>
        /// <param name="quantity">The quantity to sell.</param>
        public void Sell(int quantity)
        {
            // Basic validation: ensure there is enough stock to sell
            if (quantity >= 0 && quantity <= QuantityInStock)
            {
                QuantityInStock -= quantity;
            }
            else
            {
                Console.WriteLine("Invalid quantity to sell. Please provide a valid quantity.");
            }
        }
        #endregion

        #endregion

        #region Validation

        /// <summary>
        /// Validates the product against existing products.
        /// </summary>
        /// <param name="existingProducts">The list of existing products.</param>
        public void Validate(List<Product> existingProducts)
        {
            //Validate Product ID
            if (!ValidationHelper.IsProductIdValid(ProductId, existingProducts))
            {
                throw new ArgumentException("Invalid Product ID. Please provide a positive integer value.");
            }

            //Validate Product Name
            if (!ValidationHelper.IsProductNameValid(ProductName))
            {
                throw new ArgumentException("Invalid Product Name. Please provide a non-empty string.");
            }

            //Validate Price
            if (!ValidationHelper.IsPriceValid(Price))
            {
                throw new ArgumentException("Invalid Price. Please provide a non-negative value.");
            }

            //Validate Quantity Stock value
            if (!ValidationHelper.IsQuantityInStockValid(QuantityInStock))
            {
                throw new ArgumentException("Invalid Quantity in Stock. Please provide a non-negative integer value.");
            }
        }
        #endregion

    }
}
