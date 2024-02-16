using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    [RoutePrefix("api/Product")]
    public class CLProductController : ApiController
    {
        private BLProduct _objBLProduct;

        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            _objBLProduct = new BLProduct();
            List<PRD01> products = _objBLProduct.GetAllProducts();
            if (products != null)
                return Ok(products);
            else
                return InternalServerError();
        }

        [HttpPost]
        [Route("AddProduct")]
        public IHttpActionResult AddProduct(PRD01 Product)
        {
            _objBLProduct = new BLProduct();

            if (_objBLProduct.AddProduct(Product))
                return Ok("Product added successfully.");
            else
                return InternalServerError();
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IHttpActionResult UpdateProduct(int productId, PRD01 Product)
        {
            _objBLProduct = new BLProduct();

            if (_objBLProduct.UpdateProduct(productId, Product))
                return Ok("Product updated successfully.");
            else
                return InternalServerError();
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public IHttpActionResult DeleteProduct(int productId)
        {
            _objBLProduct = new BLProduct();
            if (_objBLProduct.DeleteProduct(productId))
                return Ok("product deleted successfully.");
            else
                return NotFound();
        }

        [HttpPatch]
        [Route("Changebrand")]
        public IHttpActionResult UpdateProductBrand(int productId, [FromBody] string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                return BadRequest("Brand cannot be empty");
            }
            _objBLProduct = new BLProduct();
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
