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
        // Instance of the product business logic class
        private BLProduct _objBLProduct;

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>The list of products.</returns>
        [HttpGet]
        [Route("GetAllProducts")]
        [BearerAuthentication]
        [Authorize(Roles = ("Customer,Seller,Admin,Supplier"))]
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
        [BearerAuthentication]
        [Authorize(Roles = ("Seller,Admin"))]
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
        [BearerAuthentication]
        [Authorize(Roles = ("Seller,Admin"))]
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
        [BearerAuthentication]
        [Authorize(Roles = ("Seller,Admin"))]
        public IHttpActionResult DeleteProduct(int productId)
        {
            _objBLProduct = new BLProduct();
            if (_objBLProduct.DeleteProduct(productId))
                return Ok("product deleted successfully.");
            else
                return NotFound();
        }

        /// <summary>
        /// Changes the brand of a product.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="brand">The new brand of the product.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPatch]
        [Route("Changebrand")]
        [BearerAuthentication]
        [Authorize(Roles = ("Seller,Admin"))]
        public IHttpActionResult UpdateProductBrand(int productId, [FromBody] string brand)
        {
            // Checks if the brand is empty or null
            if (string.IsNullOrWhiteSpace(brand))
            {
                return BadRequest("Brand cannot be empty");
            }
            _objBLProduct = new BLProduct();

            // Attempts to update the product brand
            bool success = _objBLProduct.UpdateProductBrand(productId, brand);
            if (success)
            {
                return Ok("Product brand updated successfully.");
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
