using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDemo
{
    public class Product
    {
        // Properties with private setters for encapsulation
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityInStock { get; private set; }

        // Constructor
        public Product(int productId, string productName, decimal price, int quantityInStock)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            QuantityInStock = quantityInStock;
        }

        // Methods for encapsulated interactions
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

        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product ID: {ProductId}");
            Console.WriteLine($"Product Name: {ProductName}");
            Console.WriteLine($"Price: ${Price:F2}");
            Console.WriteLine($"Quantity in Stock: {QuantityInStock}");
        }
    }
}
