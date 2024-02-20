using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Represents a controller for managing salers (sellers).
    /// </summary>
    [RoutePrefix("api/salers")]
    public class CLSalerController : ApiController
    {
        // Instance of the saler business logic class
        private readonly BLSaler _objBLSaler = new BLSaler();

        /// <summary>
        /// Retrieves all salers.
        /// </summary>
        /// <returns>The list of salers.</returns>
        [HttpGet]
        [Route("GetAllSalers")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult GetAllSalers()
        {
            List<SLR01> salers = _objBLSaler.GetAllSalers();
            if (salers != null)
                return Ok(salers);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Adds a new saler.
        /// </summary>
        /// <param name="saler">The saler to add.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPost]
        [Route("AddSaler")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult AddSaler(SLR01 saler)
        {
            if (_objBLSaler.AddSaler(saler)) // Attempts to add the saler
                return Ok("Saler added successfully."); // Returns success message
            else
                return InternalServerError(); // Returns an internal server error response
        }

        /// <summary>
        /// Updates an existing saler.
        /// </summary>
        /// <param name="salerId">The ID of the saler to update.</param>
        /// <param name="saler">The updated saler data.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateSaler")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult UpdateSaler(int salerId, SLR01 saler)
        {
            if (_objBLSaler.UpdateSaler(salerId, saler))
                return Ok("Saler updated successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Deletes a saler.
        /// </summary>
        /// <param name="salerId">The ID of the saler to delete.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteSaler")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult DeleteSaler(int salerId)
        {
            if (_objBLSaler.DeleteSaler(salerId)) // Attempts to delete the saler
                return Ok("Saler deleted successfully."); // Returns success message
            else
                return InternalServerError(); // Returns an internal server error response
        }
    }
}
