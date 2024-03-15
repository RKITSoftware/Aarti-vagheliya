using FinalDemo_WebAPI.Interface;
using FinalDemo_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Caching;

namespace FinalDemo_WebAPI.DAL
{
    /// <summary>
    /// Business Logic class for managing products and inventory (version 2).
    /// Implements the IInventoryManager interface.
    /// </summary>
    public class BLProductV2 : IInventoryManager
    {
        #region Private member

        //cache class object 
        private static Cache _objCache = System.Web.HttpRuntime.Cache;

        // Static variable to maintain a unique identifier for products
        private static int _productId = 0;

        // Static DataTable to store stock information
        private static DataTable _stockTable;

        // Static list to store products
        private static List<ProductV2> _products = new List<ProductV2>
        {
            new ProductV2
            {
                ProductId = GenerateId(), ProductName = "ProductV2_1", ProductPrice = 25.52m, ProductCount = 10, ExpiryDate = DateTime.Now.AddMonths(6), ManufacturingDate = DateTime.Now.AddMonths(-2), CategoryId = 1 /* Category = { CategoryName = "category1"} */
            },
             new ProductV2
            {
                ProductId = GenerateId(), ProductName = "ProductV2_2", ProductPrice = 25.52m, ProductCount = 11, ExpiryDate = DateTime.Now.AddMonths(4), ManufacturingDate = DateTime.Now.AddMonths(-1), CategoryId = 2 
            },
              new ProductV2
            {
                ProductId = GenerateId(), ProductName = "ProductV2_3", ProductPrice = 25.52m, ProductCount = 12, ExpiryDate = DateTime.Now.AddMonths(8), ManufacturingDate = DateTime.Now.AddMonths(-3), CategoryId = 3 
            },

        };

        #endregion

        #region Public methods

        #region GetAllProducts

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>An List of ProductV2.</returns>
        public static List<ProductV2> GetAllProducts()
        {
            return _products;
        }

        #endregion

        #region GetProductById

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>A ProductV2 object if found, otherwise null.</returns>
        public static ProductV2 GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.ProductId == productId);
        }

        #endregion

        #region AddProduct

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The ProductV2 object to add.</param>
        /// <returns>The added ProductV2 object.</returns>
        public static ProductV2 AddProduct(ProductV2 product)
        {
            product.ProductId = GenerateId();
            _products.Add(product);
            UpdateCache();
            return product;
        }

        #endregion

        #region UpdateProduct

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="updatedProduct">The updated ProductV2 object.</param>
        /// <returns>The updated ProductV2 object if successful, otherwise null.</returns>
        public static ProductV2 UpdateProduct(int productId, ProductV2 updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == productId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.ProductPrice = updatedProduct.ProductPrice;
                existingProduct.ProductCount = updatedProduct.ProductCount;
                existingProduct.ExpiryDate = updatedProduct.ExpiryDate;
                existingProduct.ManufacturingDate = updatedProduct.ManufacturingDate;
                existingProduct.CategoryId = updatedProduct.CategoryId;
                UpdateCache();
                return existingProduct;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region DeleteProduct

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>The deleted ProductV2 object if successful, otherwise null.</returns>
        public static ProductV2 DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
                UpdateCache();
                return product;
            }
            else
            {
                return null;
            }
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
                UpdateCache();
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
                UpdateCache();
                return true; // Stock managed successfully
            }

            return false; // Failed to manage stock
        }

        #endregion

        #region DisplayAllStock

        /// <summary>
        /// Displays information about all products in stock.
        /// </summary>
        /// <returns>A DataTable containing stock information for all products.</returns>
        public DataTable DisplayAllStock()
        {
            // Convert the list of products to a DataTable for display
            _stockTable = ConvertToDataTable(_products, BLCategory._categories);
            return _stockTable;
        }

        #endregion

        #region DisplayStockByCategory

        /// <summary>
        /// Displays information about products in stock for a specified category.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>A DataTable containing stock information for the specified category.</returns>
        public DataTable DisplayStockByCategory(int categoryId)
        {
            // Filter products by category
            var productsByCategory = _products.Where(p => p.CategoryId == categoryId).ToList();

            // Convert the filtered list to a DataTable for display
            _stockTable = ConvertToDataTable(productsByCategory, BLCategory._categories);
            return _stockTable;
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
            return ++_productId;
        }

        #endregion

        #region UpdateCache

        /// <summary>
        /// Updates the cache with the latest product data and resets the data modification flag.
        /// </summary>
        private static void UpdateCache()
        {
            // Update the cache with the latest product data
            _objCache["ProductsV2"] = _products;

            // Reset the data modification flag
            _objCache["DataModified"] = false;
        }

        #endregion

        #region ConvertToDataTable

        /// <summary>
        /// Converts a list of ProductV2 objects to a DataTable.
        /// </summary>
        /// <param name="products">The list of ProductV2 objects to convert.</param>
        /// <param name="categories">The list of Category objects to associate with products.</param>
        /// <returns>A DataTable containing stock information.</returns>
        private static DataTable ConvertToDataTable(List<ProductV2> products, List<Category> categories)
        {
            DataTable dataTable = new DataTable("StockTable");

            // Define columns
            dataTable.Columns.Add("ProductId", typeof(int));
            dataTable.Columns.Add("ProductName", typeof(string));
            dataTable.Columns.Add("ProductPrice", typeof(decimal));
            dataTable.Columns.Add("ProductCount", typeof(int));
            dataTable.Columns.Add("ManufacturingDate", typeof(DateTime));
            dataTable.Columns.Add("ExpiryDate", typeof(DateTime));
            dataTable.Columns.Add("CategoryName", typeof(string));

            // Add rows
            foreach (var product in products)
            {

                // Find the corresponding category for the product
                var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
                string categoryName = category != null ? category.CategoryName : "N/A";

                dataTable.Rows.Add(
                    product.ProductId, 
                    product.ProductName, 
                    product.ProductPrice, 
                    product.ProductCount, 
                    product.ManufacturingDate, 
                    product.ExpiryDate,
                    categoryName
               );
            }

            return dataTable;
        }

        #endregion

        #endregion
    }
}
