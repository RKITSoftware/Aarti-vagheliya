using FinalDemo_WebAPI.DAL;
using FinalDemo_WebAPI.Caching;
using FinalDemo_WebAPI.Models;
using System.Web.Http;
using System.Web.Http.Cors;
using FinalDemo_WebAPI.Interface;
using System.Data;

namespace FinalDemo_WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing products with version 2.
    /// </summary>
    [EnableCorsAttribute(origins: "https://localhost:44333", headers: "*", methods: "DeleteProduct,UpdateProduct,AddProduct")]
    [RoutePrefix("api/CLProductV2")]
    [CacheFilter(Duration = 300)]
    public class CLProductV2Controller : ApiController
    {
        #region Private member
        private readonly IInventoryManager _inventoryManagement = new BLProductV2();
        #endregion

        #region Public Methods

        #region GetAllProducts

        /// <summary>
        /// Gets all products.
        /// </summary>
        [HttpGet]
        [DisableCors]
        [Route("GetAllProducts")]
        [Authorize(Roles = "Customer,Supplier,Seller")]
        public IHttpActionResult GetAllProducts()
        {
            // Retrieve all products from BLProductV2 and return as IHttpActionResult
            return Ok(BLProductV2.GetAllProducts());
        }

        #endregion

        #region GetProductById

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        [HttpGet]
        [DisableCors]
        [Route("GetProduct/{productId}")]
        [Authorize(Roles = "Customer,Seller")]
        public IHttpActionResult GetProductById(int productId)
        {
            // Retrieve a product by ID from BLProductV2 and return as IHttpActionResult
            var product = BLProductV2.GetProductById(productId);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region AddProduct

        /// <summary>
        /// Adds a new product.
        /// </summary>
        [HttpPost]
        [Route("AddProduct")]
        [Authorize(Roles = "Seller,Supplier")]
        public IHttpActionResult AddProduct(ProductV2 product)
        {
            // Add a new product using BLProductV2 and return the added product details
            var addedProduct = BLProductV2.AddProduct(product);
            return Created(Request.RequestUri + "/" + addedProduct.ProductId, addedProduct);
        }

        #endregion

        #region UpdateProduct

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        [HttpPut]
        [Route("UpdateProduct/{productId}")]
        [Authorize(Roles = "Supplier,Seller")]
        public IHttpActionResult UpdateProduct(int productId, ProductV2 updatedProduct)
        {
            // Update an existing product using BLProductV2 and return the updated product details
            var product = BLProductV2.UpdateProduct(productId, updatedProduct);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region DeleteProduct

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        [Authorize(Roles = "Seller")]
        public IHttpActionResult DeleteProduct(int productId)
        {
            // Delete a product by ID using BLProductV2 and return the deleted product details
            var product = BLProductV2.DeleteProduct(productId);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region SellProduct

        /// <summary>
        /// Sells a product by reducing its quantity.
        /// </summary>
        [HttpPost]
        [Route("SellProduct/{productId}/{quantity}")]
        [Authorize(Roles = "Seller")]
        public IHttpActionResult SellProduct(int productId, int quantity)
        {
            // Sell a product by reducing its quantity using _inventoryManagement
            bool result = _inventoryManagement.SellProduct(productId, quantity);
            if (result)
            {
                return Ok("Product sold successfully.");
            }
            else
            {
                return BadRequest("Failed to sell the product.");
            }
        }

        #endregion

        #region AddStock

        /// <summary>
        /// Adds stock to a product in the inventory.
        /// </summary>
        [HttpPost]
        [Route("AddStock/{productId}/{quantity}")]
        [Authorize(Roles = "Seller")]
        public IHttpActionResult AddStock(int productId, int quantity)
        {
            // Add stock to a product in the inventory using _inventoryManagement
            bool result = _inventoryManagement.AddStock(productId, quantity);
            if (result)
            {
                return Ok("Product Added in Inventory successfully.");
            }
            else
            {
                return BadRequest("Failed to add the product.");
            }
        }

        #endregion

        #region DisplayAllStock

        /// <summary>
        /// Displays information about all products in stock.
        /// </summary>
        [HttpGet]
        [Route("DisplayAllStock")]
        [Authorize(Roles = "Customer,Supplier,Seller")]
        public IHttpActionResult DisplayAllStock()
        {
            // Display information about all products in stock using _inventoryManagement
            DataTable stockData = _inventoryManagement.DisplayAllStock();
            // Convert DataTable to JSON or any other format suitable for your response
            return Ok(stockData);
        }

        #endregion

        #region DisplayStockByCategory

        /// <summary>
        /// Displays information about products in stock filtered by category.
        /// </summary>
        [HttpGet]
        [Route("DisplayStockByCategory/{categoryId}")]
        [Authorize(Roles = "Customer,Supplier,Seller")]
        public IHttpActionResult DisplayStockByCategory(int categoryId)
        {
            // Display information about products in stock filtered by category using _inventoryManagement
            DataTable stockData = _inventoryManagement.DisplayStockByCategory(categoryId);

            return Ok(stockData);
        }

        #endregion

        #endregion
    }
}

