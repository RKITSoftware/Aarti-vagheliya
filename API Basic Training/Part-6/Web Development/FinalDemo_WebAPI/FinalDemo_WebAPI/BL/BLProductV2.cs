using FinalDemo_WebAPI.Interface;
using FinalDemo_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Caching;

namespace FinalDemo_WebAPI.BL
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

        // Static DataTable to store stock information
        private static DataTable _stockTable;

        // Private instance of Response class.
        private Response _objResponse;

        //Private instance of BLHelper class.
        private BLHelper _objBLHelper = new BLHelper();

        // Static list to store products
        private static List<ProductV2> _lstProducts = new List<ProductV2>();

        #endregion

        #region Constructor

        // Static constructor to initialize the list
        static BLProductV2()
        {
            _lstProducts.Add(new ProductV2
            {
                Id = BLHelper.GenerateId(_lstProducts),
                ProductName = "ProductV2_1",
                ProductPrice = 25.52m,
                ProductCount = 10,
                ExpiryDate = DateTime.Now.AddMonths(6),
                ManufacturingDate = DateTime.Now.AddMonths(-2),
                CategoryId = 1
            });
            _lstProducts.Add(new ProductV2
            {
                Id = BLHelper.GenerateId(_lstProducts),
                ProductName = "ProductV2_2",
                ProductPrice = 25.52m,
                ProductCount = 11,
                ExpiryDate = DateTime.Now.AddMonths(4),
                ManufacturingDate = DateTime.Now.AddMonths(-1),
                CategoryId = 2
            });
            _lstProducts.Add(new ProductV2
            {
                Id = BLHelper.GenerateId(_lstProducts),
                ProductName = "ProductV2_3",
                ProductPrice = 25.52m,
                ProductCount = 12,
                ExpiryDate = DateTime.Now.AddMonths(8),
                ManufacturingDate = DateTime.Now.AddMonths(-3),
                CategoryId = 3
            });
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A Response object containing product information.</returns>
        public List<ProductV2> GetAllProducts()
        {
            return _lstProducts;
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>A Response object containing the product information if found, otherwise an error message.</returns>
        public Response GetProductById(int productId)
        {
            _objResponse = new Response();

            ProductV2 product = _lstProducts.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ObjectToDataTable(product);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Product not found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The ProductV2 object to add.</param>
        /// <returns>A Response object containing the added product information if successful, otherwise an error message.</returns>
        public Response AddProduct(ProductV2 product)
        {
            _objResponse = new Response();
            _lstProducts.Add(product);
            UpdateCache();
            _objResponse.Message = "Ok";
            _objResponse.response = _objBLHelper.ObjectToDataTable(product);
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="updatedProduct">The updated ProductV2 object.</param>
        /// <returns>A Response object containing the updated product information if successful, otherwise an error message.</returns>
        public Response UpdateProduct(int productId, ProductV2 updatedProduct)
        {
            _objResponse = new Response();
            ProductV2 existingProduct = _lstProducts.FirstOrDefault(p => p.Id == productId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.ProductPrice = updatedProduct.ProductPrice;
                existingProduct.ProductCount = updatedProduct.ProductCount;
                existingProduct.ExpiryDate = updatedProduct.ExpiryDate;
                existingProduct.ManufacturingDate = updatedProduct.ManufacturingDate;
                existingProduct.CategoryId = updatedProduct.CategoryId;
                UpdateCache();
                _objResponse.Message = "Product updated successfully.";
                _objResponse.response = _objBLHelper.ObjectToDataTable(existingProduct);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Product not found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>A Response object containing the deleted product information if successful, otherwise an error message.</returns>
        public Response DeleteProduct(int productId)
        {
            _objResponse = new Response();

            int index = _lstProducts.FindIndex(c => c.Id == productId);
            if (index != -1)
            {
                ProductV2 product = _lstProducts[index];
                _lstProducts.RemoveAt(index);
                UpdateCache();
                _objResponse.Message = "Product deleted successfully.";
                _objResponse.response = _objBLHelper.ObjectToDataTable(product);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Product not found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Sells a specified quantity of a product.
        /// </summary>
        /// <param name="productId">The ID of the product to sell.</param>
        /// <param name="quantity">The quantity to sell.</param>
        /// <returns>A Response object indicating whether the product was sold successfully or not.</returns>
        public Response SellProduct(int productId, int quantity)
        {
            _objResponse = new Response();
            ProductV2 product = _lstProducts.FirstOrDefault(p => p.Id == productId);

            if (product != null && product.ProductCount >= quantity)
            {
                // Update product count after selling
                product.ProductCount -= quantity;
                UpdateCache();
                _objResponse.Message = "Product sold successfully.";
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Failed to sell the product.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Adds stock to a specified product.
        /// </summary>
        /// <param name="productId">The ID of the product to add stock to.</param>
        /// <param name="quantity">The quantity to add to the stock.</param>
        /// <returns>A Response object indicating whether the stock was managed successfully or not.</returns>
        public Response AddStock(int productId, int quantity)
        {
            _objResponse = new Response();

            ProductV2 product = _lstProducts.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                // Update product count
                product.ProductCount += quantity;
                UpdateCache();
                _objResponse.Message = "Product Added in Inventory successfully."; // Stock managed successfully
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Failed to add the product.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Displays information about all products in stock.
        /// </summary>
        /// <returns>A Response object containing stock information for all products.</returns>
        public Response DisplayAllStock()
        {
            _objResponse = new Response();
            // Convert the list of products to a DataTable for display
            _stockTable = ConvertToDataTable(_lstProducts, BLCategory.lstCategories);
            _objResponse.Message = "Ok";
            _objResponse.response = _stockTable;
            return _objResponse;
        }

        /// <summary>
        /// Displays information about products in stock for a specified category.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>A Response object containing stock information for the specified category.</returns>
        public Response DisplayStockByCategory(int categoryId)
        {
            _objResponse = new Response();
            // Filter products by category
            var productsByCategory = _lstProducts.Where(p => p.CategoryId == categoryId).ToList();

            // Convert the filtered list to a DataTable for display
            _stockTable = ConvertToDataTable(productsByCategory, BLCategory.lstCategories);
            _objResponse.Message = "Ok";
            _objResponse.response = _stockTable;
            return _objResponse;
        }

        /// <summary>
        /// Validate product quantity.
        /// </summary>
        /// <param name="quantity">value of quantity.</param>
        /// <returns>A Response object indicating whether the validation was successful or not.</returns>
        public Response Validation(int quantity)
        {
            _objResponse = new Response();
            // Validate product quantity.
            if (quantity > 0)
            {
                _objResponse.Message = "Validation successful.";
            }
            else
            {
                _objResponse.Message = "Validation failed. Quantity must be greater than 0.";
                _objResponse.isError = true; // Indicate validation failed
            }
            return _objResponse;
        }

        /// <summary>
        /// Set value of Expiry and Manufacturing date.
        /// </summary>
        /// <param name="objProductV2">object of product.</param>
        public void PreSave(ProductV2 objProductV2)
        {
            //Set value of Expiry and Manufacturing date.
            objProductV2.Id = BLHelper.GenerateId(_lstProducts);
            objProductV2.ExpiryDate = DateTime.Now.AddMonths(6);
            objProductV2.ManufacturingDate = DateTime.Now;
        }

        /// <summary>
        /// Validate data before add/update to/from the list.
        /// </summary>
        /// <param name="objProductV2">object of ProductV2 to be validated.</param>
        /// <returns>True if the ProductV2 object is valid; otherwise, false.</returns>
        public Response Validation(ProductV2 objProductV2)
        {
            _objResponse = new Response();

            // Validate data before add/update to/from the list.
            if (!string.IsNullOrEmpty(objProductV2.ProductName) &&
                objProductV2.ProductPrice > 0 &&
                objProductV2.ProductCount >= 0 &&
                objProductV2.ExpiryDate > objProductV2.ManufacturingDate)
                _objResponse.Message = "Validation successful.";
            else
            {
                _objResponse.Message = "Validation failed.";
                _objResponse.isError = true; // Indicate validation failed
            }
            return _objResponse;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Updates the cache with the latest product data and resets the data modification flag.
        /// </summary>
        private void UpdateCache()
        {
            // Update the cache with the latest product data
            _objCache["ProductsV2"] = _lstProducts;

            // Reset the data modification flag
            _objCache["DataModified"] = false;
        }

        /// <summary>
        /// Converts a list of ProductV2 objects to a DataTable.
        /// </summary>
        /// <param name="products">The list of ProductV2 objects to convert.</param>
        /// <param name="categories">The list of Category objects to associate with products.</param>
        /// <returns>A DataTable containing stock information.</returns>
        private DataTable ConvertToDataTable(List<ProductV2> products, List<Category> categories)
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
                var category = categories.FirstOrDefault(c => c.Id == product.CategoryId);
                string categoryName = category != null ? category.CategoryName : "N/A";

                dataTable.Rows.Add(
                    product.Id,
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

    }
}
