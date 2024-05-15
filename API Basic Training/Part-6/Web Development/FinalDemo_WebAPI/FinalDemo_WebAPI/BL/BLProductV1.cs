using FinalDemo_WebAPI.Interface;
using FinalDemo_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinalDemo_WebAPI.BL
{
    /// <summary>
    /// Business Logic class for managing products and inventory.
    /// Implements the IInventoryManager interface.
    /// </summary>
    public class BLProductV1 : IInventoryManager
    {
        #region Private member

        // Static DataTable to store stock information
        private static DataTable _stockTable;

        // Private instance of Response class.
        private Response _objResponse;

        //Private instance of BLHelper class.
        private BLHelper _objBLHelper = new BLHelper();

        // Static list to store products
        private static List<ProductV1> _lstProducts = new List<ProductV1>();

        #endregion

        #region Constructor

        // Static constructor to initialize the list
        static BLProductV1()
        {
            _lstProducts.Add( new ProductV1 { Id = BLHelper.GenerateId(_lstProducts), ProductName = "Product1", ProductPrice = 125.52m, ProductCount = 5 });
            _lstProducts.Add( new ProductV1 { Id = BLHelper.GenerateId(_lstProducts), ProductName = "Product2", ProductPrice = 852.52m, ProductCount = 2 });
            _lstProducts.Add( new ProductV1 { Id = BLHelper.GenerateId(_lstProducts), ProductName = "Product3", ProductPrice = 1258.52m, ProductCount = 2 });
            _lstProducts.Add( new ProductV1 { Id = BLHelper.GenerateId(_lstProducts), ProductName = "Product4", ProductPrice = 1796.52m, ProductCount = 5 });
            _lstProducts.Add( new ProductV1 { Id = BLHelper.GenerateId(_lstProducts), ProductName = "Product5", ProductPrice = 1965.52m, ProductCount = 7 });
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A Response object containing the list of products if available, otherwise an error message.</returns>
        public Response GetAllProducts()
        {
            _objResponse = new Response();

            if (_lstProducts.Count > 0)
            {
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ToDataTable(_lstProducts);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>A Response object containing the product if found, otherwise an error message.</returns>
        public Response GetProductById(int productId)
        {
            _objResponse = new Response();

            ProductV1 productv1 = _lstProducts.FirstOrDefault(p => p.Id == productId);
            if (productv1 != null)
            {
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ObjectToDataTable(productv1);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>A Response object containing the added product if successful, otherwise an error message.</returns>
        public Response AddProduct(ProductV1 product)
        {
            _objResponse = new Response();
            product.Id = BLHelper.GenerateId(_lstProducts);
            _lstProducts.Add(product);
            _objResponse.Message = "Ok";
            _objResponse.response = _objBLHelper.ObjectToDataTable(product);
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="updatedProduct">The updated product information.</param>
        /// <returns>A Response object containing the updated product if successful, otherwise an error message.</returns>
        public Response UpdateProduct(int productId, ProductV1 updatedProduct)
        {
            _objResponse = new Response();
            ProductV1 existingProduct = _lstProducts.FirstOrDefault(p => p.Id == productId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.ProductPrice = updatedProduct.ProductPrice;
                existingProduct.ProductCount = updatedProduct.ProductCount;
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
        /// <returns>A Response object containing the deleted product if successful, otherwise an error message.</returns>
        public Response DeleteProduct(int productId)
        {
            _objResponse = new Response();

            int index = _lstProducts.FindIndex(c => c.Id == productId);
            if (index != -1)
            {
                ProductV1 product = _lstProducts[index];
                _lstProducts.RemoveAt(index);
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
        /// <returns>A Response object indicating the success or failure of the operation.</returns>
        public Response SellProduct(int productId, int quantity)
        {
            _objResponse = new Response();
            ProductV1 product = _lstProducts.FirstOrDefault(p => p.Id == productId);

            if (product != null && product.ProductCount >= quantity)
            {
                // Update product count after selling
                product.ProductCount -= quantity;
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
        /// Adds stock to a product.
        /// </summary>
        /// <param name="productId">The ID of the product to add stock to.</param>
        /// <param name="quantity">The quantity of stock to add.</param>
        /// <returns>A Response object indicating the success or failure of the operation.</returns>
        public Response AddStock(int productId, int quantity)
        {
            _objResponse = new Response();

            ProductV1 product = _lstProducts.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                // Update product count
                product.ProductCount += quantity;
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
        /// Displays all stock.
        /// </summary>
        /// <returns>A Response object containing the stock information.</returns>
        public Response DisplayAllStock()
        {
            _objResponse = new Response();
            // Convert the list of products to a DataTable for display
            _stockTable = _objBLHelper.ToDataTable(_lstProducts);
            _objResponse.Message = "Ok";
            _objResponse.response = _stockTable;
            return _objResponse;
        }

        /// <summary>
        /// Displays stock by category.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>A Response object containing the stock information filtered by category.</returns>
        public Response DisplayStockByCategory(int categoryId)
        { 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates a quantity value.
        /// </summary>
        /// <param name="quantity">The quantity to validate.</param>
        /// <returns>A Response object indicating the success or failure of the validation.</returns>
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

        #endregion

       
    }


}