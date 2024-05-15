using FinalDemo_WebAPI.BL;
using FinalDemo_WebAPI.Interface;
using FinalDemo_WebAPI.Models;
using FinalDemo_WebAPI.ServiceProvider;
using System.Collections.Generic;
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

        // Cache class's object
        private Cache _objCache;

        //Private instance of BLProductV2 class.
        private BLProductV2 _objProductV2 = new BLProductV2();

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
             List<ProductV2> products;

             if (_objCache["ProductsV2"] != null)
             {
                 // retrive Product list from the cache
                 products = (List<ProductV2>)_objCache.Get("ProductsV2");
             }
             else
             {
                 products = _objProductV2.GetAllProducts();

                 // Add Product list to the cache
                 _objCache.Insert("ProductsV2", products);
             }

            return Ok(products);

          

        }


        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>An IHttpActionResult containing the response with the product if found.</returns>
        [HttpGet]
        [DisableCors]
        [Route("GetProduct/{productId}")]
        [Authorize(Roles = ("Customer,Seller"))]
        public IHttpActionResult GetProductById(int productId)
        {
            return Ok( _objProductV2.GetProductById(productId));  
        }


        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The ProductV2 object to add.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the product addition.</returns>
        [HttpPost]
        [Route("AddProduct")]
        [Authorize(Roles = ("Supplier,Seller"))]
        public IHttpActionResult AddProduct(ProductV2 product)
        {
            _objProductV2.PreSave(product);

            Response response = _objProductV2.Validation(product);
            if (!response.isError)
            {
                response = _objProductV2.AddProduct(product);
            }
            return Ok(response);
        }


        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="updatedProduct">The updated ProductV2 object.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the product update.</returns>
        [HttpPut]
        [Route("UpdateProduct/{productId}")]
        [Authorize(Roles = ("Supplier,Seller"))]
        public IHttpActionResult UpdateProduct(int productId, ProductV2 updatedProduct)
        {
            Response response = _objProductV2.Validation(updatedProduct);
            if (!response.isError)
            {
               response = _objProductV2.UpdateProduct(productId, updatedProduct);
            }
            return Ok(response);
        }


        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the product deletion.</returns>
        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        [Authorize(Roles = ("Seller"))]
        public IHttpActionResult DeleteProduct(int productId)
        {
           return Ok( _objProductV2.DeleteProduct(productId));
        }


        /// <summary>
        /// Sells a specified quantity of a product.
        /// </summary>
        /// <param name="productId">The ID of the product to sell.</param>
        /// <param name="quantity">The quantity to sell.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the product sale.</returns>
        [HttpPost]
        [Route("SellProduct/{productId}/{quantity}")]
        [Authorize(Roles = ("Seller"))]
        public IHttpActionResult SellProduct(int productId, int quantity)
        {
            Response response = _objProductV2.Validation(quantity);
            if (!response.isError)
            {
                response = _inventoryManagement.SellProduct(productId, quantity);
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
        [Authorize(Roles = ("Seller"))]
        public IHttpActionResult AddStock(int productId, int quantity)
        {
            Response response = _objProductV2.Validation(quantity);
            if (!response.isError)
            {
                response= _inventoryManagement.AddStock(productId, quantity);
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
        //[Authorize(Roles = ("Customer,Supplier,Seller"))]
        public IHttpActionResult DisplayAllStock()
        {
            return Ok( _inventoryManagement.DisplayAllStock());
        }


        /// <summary>
        /// Displays stock filtered by category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter by.</param>
        /// <returns>An IHttpActionResult containing the response with the list of products in stock filtered by category.</returns>
        [HttpGet]
        [Route("DisplayStockByCategory/{categoryId}")]
        [Authorize(Roles = ("Customer,Supplier,Seller"))]
        public IHttpActionResult DisplayStockByCategory(int categoryId)
        {
            // Display information about products in stock filtered by category using _inventoryManagement
            return Ok( _inventoryManagement.DisplayStockByCategory(categoryId));
        }


        #endregion
    }
}

