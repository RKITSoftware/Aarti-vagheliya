using FinalDemo_WebAPI.Interface;
using FinalDemo_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinalDemo_WebAPI.DAL
{
    /// <summary>
    /// Business Logic class for managing products and inventory.
    /// Implements the IInventoryManager interface.
    /// </summary>
    public class BLProductV1 : IInventoryManager
    {
        #region preivate member

        // Static variable to maintain a unique identifier for products
        private static int _count = 0;

        // Static DataTable to store stock information
        private static DataTable _stockTable;

        // Static list to store products
        private static List<ProductV1> _products = new List<ProductV1>
        {
            new ProductV1{ ProductId = GenerateId() , ProductName = "Product1", ProductPrice = 125.52m, ProductCount = 5},
            new ProductV1{ ProductId = GenerateId() , ProductName = "Product2", ProductPrice = 852.52m, ProductCount = 2},
            new ProductV1{ ProductId = GenerateId() , ProductName = "Product3", ProductPrice = 1258.52m, ProductCount = 2},
            new ProductV1{ ProductId = GenerateId() , ProductName = "Product4", ProductPrice = 1796.52m, ProductCount = 5},
            new ProductV1{ ProductId = GenerateId() , ProductName = "Product5", ProductPrice = 1965.52m, ProductCount = 7},

        };

        #endregion

        #region Public Methods

        #region GetAllProducts

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>An IEnumerable of ProductV1.</returns>
        public static List<ProductV1> GetAllProducts()
        {
            return _products;
        }

        #endregion

        #region GetProductById

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>A ProductV1 object if found, otherwise null.</returns>
        public static ProductV1 GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.ProductId == productId);
        }

        #endregion

        #region AddProduct

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The ProductV1 object to add.</param>
        /// <returns>The added ProductV1 object.</returns>
        public static ProductV1 AddProduct(ProductV1 product)
        {
            product.ProductId = GenerateId();
            _products.Add(product);
            return product;
        }

        #endregion

        #region UpdateProduct

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="updatedProduct">The updated ProductV1 object.</param>
        /// <returns>The updated ProductV1 object if successful, otherwise null.</returns>
        public static ProductV1 UpdateProduct(int productId, ProductV1 updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == productId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.ProductPrice = updatedProduct.ProductPrice;
                existingProduct.ProductCount = updatedProduct.ProductCount;
            }
            return existingProduct;
        }

        #endregion

        #region DeleteProduct

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>The deleted ProductV1 object if successful, otherwise null.</returns>
        public static ProductV1 DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
            return product;
        }

        #endregion

        #region SellProduct

        /// <summary>
        /// Sells a specified quantity of a product.
        /// </summary>
        /// <param name="productId">The ID of the product to sell.</param>
        /// <param name="quantity">The quantity to sell.</param>
        /// <returns>True if the product is sold successfully, otherwise false.</returns>
        public bool SellProduct(int productId, int quantity)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null && product.ProductCount >= quantity)
            {
                // Update product count after selling
                product.ProductCount -= quantity;
                return true; // Sold successfully
            }

            return false; // Failed to sell
        }

        #endregion

        #region AddStock

        /// <summary>
        /// Adds stock to a specified product.
        /// </summary>
        /// <param name="productId">The ID of the product to add stock to.</param>
        /// <param name="quantity">The quantity to add to the stock.</param>
        /// <returns>True if the stock is managed successfully, otherwise false.</returns>
        public bool AddStock(int productId, int quantity)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                // Update product count
                product.ProductCount += quantity;
                return true; // Stock managed successfully
            }

            return false; // Failed to manage stock
        }

        #endregion

        #region DisplayAllStock

        /// <summary>
        /// Displays stock information for all products.
        /// </summary>
        /// <returns>A DataTable containing stock information.</returns>
        public DataTable DisplayAllStock()
        {
            
           // List<ProductV1> products = GetAllProducts();

            // Convert the list of products to a DataTable for display
            _stockTable = ConvertToDataTable(_products);
            return _stockTable;
        }

        #endregion

        #region DisplayStockByCategory

        /// <summary>
        /// Displays stock information for products in a specific category.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>A DataTable containing stock information for the specified category.</returns>
        public DataTable DisplayStockByCategory(int categoryId)
        { 
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private Methods

        #region GenerateId

        /// <summary>
        /// Generates a unique ID for products.
        /// </summary>
        /// <returns>The generated unique ID.</returns>
        private static int GenerateId()
        {
            return ++_count;
        }

        #endregion

        #region ConvertToDataTable

        /// <summary>
        /// Converts a list of ProductV1 objects to a DataTable.
        /// </summary>
        /// <param name="products">The list of ProductV1 objects to convert.</param>
        /// <returns>A DataTable containing stock information.</returns>
        private static DataTable ConvertToDataTable(List<ProductV1> products)
        {
            DataTable dataTable = new DataTable("StockTable");

            // Define columns
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("ProductName", typeof(string));
            dataTable.Columns.Add("ProductPrice", typeof(decimal));
            dataTable.Columns.Add("ProductCount", typeof(int));

            // Add rows
            foreach (var product in products)
            {
                dataTable.Rows.Add(
                    product.ProductId, 
                    product.ProductName, 
                    product.ProductPrice, 
                    product.ProductCount
                );
            }

            return dataTable;
        }

        #endregion

        #endregion
    }


}