using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using FinalDemo_Advance_C_.Models.DTO;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Represents a controller for managing products.
    /// </summary>
    [RoutePrefix("api/Product")]
    [BearerAuthentication] // Performs bearer token authentication
    public class CLPRD01Controller : ApiController
    {
        #region Private Member 

        /// <summary>
        /// Instance of the product business logic class
        /// </summary>
        private BLPRD01Handler _objBLPRD01Handler;

        /// <summary>
        /// Private Instance of Response class.
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLPRD01Controller"/> class.
        /// </summary>
        public CLPRD01Controller()
        {
            _objBLPRD01Handler = new BLPRD01Handler();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Displays all products.
        /// </summary>
        /// <returns>HTTP response containing products.</returns>
        [HttpGet]
        [Route("DisplayAllProducts")]
        //[BearerAuthentication] // Performs bearer token authentication
        //[Authorize(Roles = ("Admin,DEO,Accountant"))]
        public IHttpActionResult DisplayAllProducts()
        {
            _objResponse = new Response();
            _objResponse = _objBLPRD01Handler.Displayproducts();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>HTTP response containing products.</returns>
        [HttpGet]
        [Route("GetAllProducts")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult GetAllProducts()
        {
            _objResponse = new Response();
            _objResponse = _objBLPRD01Handler.Select();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="Product">Product DTO.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPost]
        [Route("AddProduct")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult AddProduct(DtoPRD01 Product)
        {
            _objBLPRD01Handler.objOperation = Enums.enmOperationType.I;

            _objBLPRD01Handler.PreSave(Product);

            Response response = _objBLPRD01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLPRD01Handler.Save();
            }

            return Ok(response);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="Product">Updated product DTO.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateProduct")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult UpdateProduct(DtoPRD01 Product)
        {
            _objBLPRD01Handler.objOperation = Enums.enmOperationType.U;

            _objBLPRD01Handler.PreSave(Product);

            Response response = _objBLPRD01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLPRD01Handler.Save();
            }

            return Ok(response);
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <param name="productId">Product ID.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteProduct")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult DeleteProduct(int productId)
        {
           _objResponse = _objBLPRD01Handler.Delete(productId);

            return Ok(_objResponse);
        }

       
        #endregion
    }
}
