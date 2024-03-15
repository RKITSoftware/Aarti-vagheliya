using FinalDemo_WebAPI.DAL;
using FinalDemo_WebAPI.Interface;
using FinalDemo_WebAPI.Models;
using FinalDemo_WebAPI.ServiceProvider;
using System.Collections.Generic;
using System.Data;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalDemo_WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing products with version 2.
    /// </summary>
    [EnableCorsAttribute(origins: "https://localhost:44331", headers: "*", methods: "DeleteProduct,UpdateProduct,AddProduct")]
    [BearerAuthentication] // Performs bearer token authentication
    [RoutePrefix("api/CLProductV2")]
    public class CLProductV2Controller : ApiController
    {
        #region Private member

        // Interface object of IinventoryManager
        private readonly IInventoryManager _inventoryManagement = new BLProductV2();

        // Cache class 's object
        private Cache _objCache;
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for initialize Cache class's object
        /// </summary>
        public CLProductV2Controller()
        {
            _objCache = System.Web.HttpRuntime.Cache;
        }

        #endregion

        #region Public Methods

        #region GetAllProducts

        /// <summary>
        /// Gets all products.
        /// </summary>
        [DisableCors]
        [HttpGet]
        [Route("GetAllProducts")]
        [Authorize(Roles = ("Customer,Supplier,Seller"))]
        public IHttpActionResult GetAllProducts()
        {
            List<ProductV2> products;

            if (_objCache["ProductsV2"] != null)
            {
                // retrive Product list from the cache
                products = (List<ProductV2>)_objCache.Get("ProductsV2");
            }
            else
            {
                products = BLProductV2.GetAllProducts();

                // Add Product list to the cache
                _objCache.Insert("ProductsV2", products);
            }

           return Ok(products);
           
        }

        #endregion

        #region GetProductById

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        [HttpGet]
        [DisableCors]
        [Route("GetProduct/{productId}")]
        [Authorize(Roles = ("Customer,Seller"))]
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
        [Authorize(Roles = ("Supplier,Seller"))]
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
        [Authorize(Roles = ("Supplier,Seller"))]
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
        [Authorize(Roles = ("Seller"))]
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
        [Authorize(Roles = ("Seller"))]
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
        [Authorize(Roles = ("Seller"))]
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
        [AllowAnonymous]
        //[Authorize(Roles = ("Customer,Supplier,Seller"))]
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
        [Authorize(Roles = ("Customer,Supplier,Seller"))]
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

