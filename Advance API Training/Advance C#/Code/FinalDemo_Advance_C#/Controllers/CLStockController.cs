using FinalDemo_Advance_C_.Authentication;
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
    /// <summary>
    /// Represents a controller for managing stock.
    /// </summary>
    [RoutePrefix("api/CLStock")]
    public class CLStockController : ApiController
    {
        #region Private member

        // Instance of the stock business logic class
        private BLStock _objBLStock;

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all stock entries.
        /// </summary>
        /// <returns>The list of stock entries.</returns>
        [HttpGet]
        [Route("GetAllStockEntries")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult GetAllStockEntries()
        {
            // Instantiates the stock business logic class
            _objBLStock = new BLStock();

            // Retrieves all stock entries from the database
            List<STK01> stockEntries = _objBLStock.GetAllStockEntries();
            if (stockEntries != null)
                // Returns the list of stock entries
                return Ok(stockEntries);
            else
                // Returns an internal server error response
                return InternalServerError();
        }

        /// <summary>
        /// Adds a new stock entry.
        /// </summary>
        /// <param name="stockEntry">The stock entry to add.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPost]
        [Route("AddStockEntry")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult AddStockEntry(STK01 stockEntry)
        {
            _objBLStock = new BLStock();

            // Attempts to add the stock entry
            if (_objBLStock.AddStockEntry(stockEntry))
                return Ok("Stock entry added successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Updates an existing stock entry.
        /// </summary>
        /// <param name="stockId">The ID of the stock entry to update.</param>
        /// <param name="stockEntry">The updated stock entry data.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateStockEntry")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult UpdateStockEntry(int stockId, int quantity)
        {
            // Instantiates the stock business logic class
            _objBLStock = new BLStock();

            // Attempts to update the stock entry
            if (_objBLStock.UpdateStockEntry(stockId, quantity))
                return Ok("Stock entry updated successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Deletes a stock entry.
        /// </summary>
        /// <param name="stockId">The ID of the stock entry to delete.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteStockEntry")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult DeleteStockEntry(int stockId)
        {
            _objBLStock = new BLStock();
            if (_objBLStock.DeleteStockEntry(stockId))
                return Ok("Stock entry deleted successfully.");
            else
                // Returns a not found response
                return NotFound();
        }

        #endregion
    }
}
