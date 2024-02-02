using FinalDemo_WebAPI.Caching;
using FinalDemo_WebAPI.DAL;
using FinalDemo_WebAPI.Interface;
using FinalDemo_WebAPI.Models;
using FinalDemo_WebAPI.ServiceProvider;
using System.Data;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalDemo_WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing products with version 1.
    /// </summary>
 
    [BasicAuthenticationAttribute]
    [EnableCorsAttribute(origins: "*", headers: "*", methods: "DeleteProduct,UpdateProduct,AddProduct")]
    [RoutePrefix("api/CLProductV1")]
    [CacheFilter(Duration = 100)]
    public class CLProductV1Controller : ApiController
    {
        #region Private Member
        private readonly IInventoryManager _inventoryManagement = new BLProductV1();
        #endregion

        #region Public methods

        #region GetAllProducts

        /// <summary>
        /// Gets all products.
        /// </summary>
        [HttpGet]
        [DisableCors]
        [Route("GetAllProducts")]
        [BasicAuthorizationAttribute(Roles= "Customer,Supplier,Seller")]
        public IHttpActionResult GetAllProducts()
        {
            // Retrieve all products from BLProductV1 and return as IHttpActionResult
            return Ok(BLProductV1.GetAllProducts());    
        }

        #endregion

        #region GetProductById

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        [HttpGet]
        [Route("GetProduct/{id}")]
        [BasicAuthorizationAttribute(Roles = "Customer,Seller")]
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
        [BasicAuthorizationAttribute(Roles = "Seller")]
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
        [BasicAuthorizationAttribute(Roles = "Seller,Supplier")]
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
        [BasicAuthorizationAttribute(Roles = "Seller")]
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
        /// Displays information about all products in stock.
        /// </summary>
        [HttpGet]
        [Route("DisplayAllStock")]
        [AllowAnonymous]
        //[BasicAuthorizationAttribute(Roles = "Customer,Supplier,Seller")]
        public IHttpActionResult DisplayAllStock()
        {
            // Display information about all products in stock using _inventoryManagement
            DataTable stockData = _inventoryManagement.DisplayAllStock();
            // Convert DataTable to JSON or any other format suitable for your response
            return Ok(stockData);
        }

        #endregion

        #endregion
    }
}
