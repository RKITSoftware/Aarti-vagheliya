using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using FinalDemo_Advance_C_.Models.DTO;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Represents a controller for managing categories.
    /// </summary>
    [RoutePrefix("api/CLCategory")]
    [BearerAuthentication] // Performs bearer token authentication
    public class CLCAT01Controller : ApiController
    {
        #region Private member

        /// <summary>
        /// Private instance of BLCAT01Handler class.
        /// </summary>
        private BLCAT01Handler _objBLCAT01Handler;

        /// <summary>
        /// Private instance of Response.
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLCAT01Controller"/> class.
        /// </summary>
        public CLCAT01Controller()
        {
            _objBLCAT01Handler = new BLCAT01Handler();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>HTTP response containing categories.</returns>
        [HttpGet]
        [Route("GetAllCategories")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult GetAllCategories()
        {
            _objResponse = new Response();
            _objResponse = _objBLCAT01Handler.Select();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="Category">Category DTO.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPost]
        [Route("AddCategory")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult AddCategory(DtoCAT01 Category)
        {
            _objBLCAT01Handler.objOperation = Enums.enmOperationType.I;

            _objBLCAT01Handler.PreSave(Category);

            Response response = _objBLCAT01Handler.Validation();
            if(!response.isError)
            {
               response =  _objBLCAT01Handler.Save();
            }

            return Ok(response);
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="Category">Category DTO.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateCategory")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult UpdateCategory(DtoCAT01 Category)
        {
            _objBLCAT01Handler.objOperation = Enums.enmOperationType.U;

            _objBLCAT01Handler.PreSave(Category);

            Response response = _objBLCAT01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLCAT01Handler.Save();
            }

            return Ok(response);
        }

        /// <summary>
        /// Deletes a category.
        /// </summary>
        /// <param name="categoryId">Category ID.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteCategory")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult DeleteCategory(int categoryId)
        {
           _objResponse = _objBLCAT01Handler.Delete(categoryId);

            return Ok(_objResponse);
        }

        #endregion
    }
}
