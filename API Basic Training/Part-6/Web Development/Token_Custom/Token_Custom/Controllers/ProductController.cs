using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Token_Custom.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/Product/GetProducts")]
        public IHttpActionResult GetProducts()
        {
            // Your logic to fetch products
            var products = new List<string> { "Product1", "Product2", "Product3" };
            return Ok(products);
        }
    }
}
