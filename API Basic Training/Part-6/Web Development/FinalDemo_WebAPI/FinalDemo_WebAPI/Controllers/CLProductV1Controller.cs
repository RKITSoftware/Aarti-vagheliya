using FinalDemo_WebAPI.DAL;
using FinalDemo_WebAPI.Interface;
using FinalDemo_WebAPI.Models;
using FinalDemo_WebAPI.ServiceProvider;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalDemo_WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing products with version 1.
    /// </summary>

    [EnableCorsAttribute(origins: "*", headers: "*", methods: "*")]
    [BearerAuthentication] // Performs bearer token authentication
    [RoutePrefix("api/CLProductV1")]
     public class CLProductV1Controller : ApiController
     {
        #region Private Member

        // object of the inventory interface
        private readonly IInventoryManager _inventoryManagement = new BLProductV1();

        // declare object of Cache class
        private Cache _objCache;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor initialize the object of the cache
        /// </summary>
        public CLProductV1Controller()
        {
            _objCache = new Cache();
        }

        #endregion

        #region Public methods

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
            // insert data into the cache 
            _objCache.Insert("ProductsV1", BLProductV1.GetAllProducts());
           
            // Return the response
            return Ok(_objCache.Get("ProductsV1"));
        }

        #endregion

        #region GetProductById

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        [HttpGet]
        [Route("GetProduct/{id}")]
        [Authorize(Roles = ("Customer,Seller"))]
        public IHttpActionResult GetProductById(int id)
        {
            // Retrieve a product by ID from BLProductV1 and return as IHttpActionResult
            var product = BLProductV1.GetProductById(id);
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
        [Authorize(Roles = ("Seller"))]
        public IHttpActionResult AddProduct(ProductV1 product)
        {
            // Add a new product using BLProductV1 and return the added product details
            var addedProduct = BLProductV1.AddProduct(product);
            return Created(Request.RequestUri + "/" + addedProduct.ProductId, addedProduct);
        }

        #endregion

        #region UpdateProduct

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        [HttpPut]
        [Route("UpdateProduct/{id}")]
        [Authorize(Roles = ("Supplier,Seller"))]
        public IHttpActionResult UpdateProduct(int id, ProductV1 updatedProduct)
        {
            // Update an existing product using BLProductV1 and return the updated product details
            var product = BLProductV1.UpdateProduct(id, updatedProduct);
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
        [Route("DeleteProduct/{id}")]
        [Authorize(Roles = ("Seller"))]
        public IHttpActionResult DeleteProduct(int id)
        {
            // Delete a product by ID using BLProductV1 and return the deleted product details
            var product = BLProductV1.DeleteProduct(id);
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
        [AllowAnonymous]
        //[BasicAuthorizationAttribute(Roles = "Seller")]
        public IHttpActionResult SellProduct(int productId, int quantity)
        {
            // Sell a product by reducing its quantity using _inventoryManagement
            bool result = _inventoryManagement.SellProduct(productId, quantity);
            if (result)
            {
                _objCache.Remove("ProductsV1");
                _objCache.Insert("ProductsV1",BLProductV1.GetAllProducts());

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
        [AllowAnonymous]
        //[BasicAuthorizationAttribute(Roles = "Supplier")]
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
        /// Retrieves and caches all products in stock, then returns them.
        /// </summary>
        /// <returns>An IHttpActionResult representing the HTTP response with the list of products in stock.</returns>
        [HttpGet]
        [Route("DisplayAllStock")]
        [AllowAnonymous]
        //[BasicAuthorizationAttribute(Roles = "Customer,Supplier,Seller")]
        public IHttpActionResult DisplayAllStock()
        { 
            // Insert the list of products into cache
            _objCache.Insert("Products", _inventoryManagement.DisplayAllStock());

            // Return the list of products retrieved from cache
            return Ok(_objCache.Get("Products"));
        }

        #endregion

        #endregion
     }
}
