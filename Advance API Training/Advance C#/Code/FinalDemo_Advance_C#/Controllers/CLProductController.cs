using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Represents a controller for managing products.
    /// </summary>
    [RoutePrefix("api/Product")]
    public class CLProductController : ApiController
    {
        #region Private Member 

        // Instance of the product business logic class
        private BLProduct _objBLProduct;

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("DisplayAllProducts")]
        //[BearerAuthentication] // Performs bearer token authentication
        //[Authorize(Roles = ("Admin,DEO,Accountant"))]
        public IHttpActionResult DisplayAllProducts()
        {
            // Instantiates the product business logic class
            _objBLProduct = new BLProduct();

            // Retrieves all products from the database
            dynamic products = _objBLProduct.DisplayProducts();
            if (products != null)
                return Ok(products);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>The list of products.</returns>
        [HttpGet]
        [Route("GetAllProducts")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult GetAllProducts()
        {
            // Instantiates the product business logic class
            _objBLProduct = new BLProduct();

            // Retrieves all products from the database
            List<PRD01> products = _objBLProduct.GetAllProducts();
            if (products != null)
                return Ok(products);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="Product">The product to add.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPost]
        [Route("AddProduct")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult AddProduct(PRD01 Product)
        {
            _objBLProduct = new BLProduct();

            if (_objBLProduct.AddProduct(Product))
                return Ok("Product added successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="Product">The updated product data.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateProduct")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult UpdateProduct(int productId, PRD01 Product)
        {
            _objBLProduct = new BLProduct();

            if (_objBLProduct.UpdateProduct(productId, Product))
                return Ok("Product updated successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteProduct")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult DeleteProduct(int productId)
        {
            _objBLProduct = new BLProduct();
            if (_objBLProduct.DeleteProduct(productId))
                return Ok("product deleted successfully.");
            else
                return NotFound();
        }

       
        #endregion
    }
}
