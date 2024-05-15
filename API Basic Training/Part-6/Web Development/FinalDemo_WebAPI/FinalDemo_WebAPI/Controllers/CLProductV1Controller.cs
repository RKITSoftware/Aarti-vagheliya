using FinalDemo_WebAPI.BL;
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

        //Private instance of BLProductV1 class.
        private BLProductV1 _objBLProductV1 = new BLProductV1();

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

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>An IHttpActionResult containing the response with all products.</returns>
        [DisableCors]
        [HttpGet]
        [Route("GetAllProducts")]
        [Authorize(Roles = ("Customer,Supplier,Seller"))]
        public IHttpActionResult GetAllProducts()
        {
            // insert data into the cache 
            _objCache.Insert("ProductsV1", _objBLProductV1.GetAllProducts());
           
            // Return the response
            return Ok(_objCache.Get("ProductsV1"));
        }

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>An IHttpActionResult containing the response with the product if found.</returns>
        [HttpGet]
        [Route("GetProduct/{id}")]
        [Authorize(Roles = ("Customer,Seller"))]
        public IHttpActionResult GetProductById(int id)
        {
            return Ok( _objBLProductV1.GetProductById(id));
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The ProductV1 object to add.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the product addition.</returns>
        [HttpPost]
        [Route("AddProduct")]
        [Authorize(Roles = ("Seller"))]
        public IHttpActionResult AddProduct(ProductV1 product)
        {
            Response response = _objBLProductV1.Validation(product.ProductCount);
            if (!response.isError)
            {
                response = _objBLProductV1.AddProduct(product);
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="updatedProduct">The updated ProductV1 object.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the product update.</returns>
        [HttpPut]
        [Route("UpdateProduct/{id}")]
        [Authorize(Roles = ("Supplier,Seller"))]
        public IHttpActionResult UpdateProduct(int id, ProductV1 updatedProduct)
        {
            Response response = _objBLProductV1.Validation(updatedProduct.ProductCount);
            if (!response.isError)
            {
                response = _objBLProductV1.UpdateProduct(id, updatedProduct);
            }
            return Ok(response);
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the product deletion.</returns>
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        [Authorize(Roles = ("Seller"))]
        public IHttpActionResult DeleteProduct(int id)
        {
            return Ok(_objBLProductV1.DeleteProduct(id));
        }

        /// <summary>
        /// Sells a specified quantity of a product.
        /// </summary>
        /// <param name="productId">The ID of the product to sell.</param>
        /// <param name="quantity">The quantity to sell.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the product sale.</returns>
        [HttpPost]
        [Route("SellProduct/{productId}/{quantity}")]
        [AllowAnonymous]
        //[BasicAuthorizationAttribute(Roles = "Seller")]
        public IHttpActionResult SellProduct(int productId, int quantity)
        {
            Response response = _objBLProductV1.Validation(quantity);
            if (!response.isError)
            {
                response = _objBLProductV1.SellProduct(productId, quantity);
                _objCache.Remove("ProductsV1");
                _objCache.Insert("ProductsV1", _objBLProductV1.GetAllProducts());
            }
            return Ok(response);
        }

        /// <summary>
        /// Adds stock to a product.
        /// </summary>
        /// <param name="productId">The ID of the product to add stock to.</param>
        /// <param name="quantity">The quantity of stock to add.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the stock addition.</returns>
        [HttpPost]
        [Route("AddStock/{productId}/{quantity}")]
        [AllowAnonymous]
        //[BasicAuthorizationAttribute(Roles = "Supplier")]
        public IHttpActionResult AddStock(int productId, int quantity)
        {
            Response response = _objBLProductV1.Validation(quantity);
            if (!response.isError)
            {
                response = _objBLProductV1.AddStock(productId, quantity);
            }
            return Ok(response);
        }

        /// <summary>
        /// Displays all available stock.
        /// </summary>
        /// <returns>An IHttpActionResult containing the response with the list of all available products in stock.</returns>
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
     }
}
