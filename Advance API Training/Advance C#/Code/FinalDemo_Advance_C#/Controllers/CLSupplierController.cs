using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Represents a controller for managing suppliers.
    /// </summary>
    [RoutePrefix("api/suppliers")]
    public class CLSupplierController : ApiController
    {
        #region Private Member

        // Instance of the supplier business logic class
        private readonly BLSupplier _objBLSupplier = new BLSupplier();

        private readonly BLTransaction _objBLTransaction = new BLTransaction();

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves all suppliers.
        /// </summary>
        /// <returns>The list of suppliers.</returns>
        [HttpGet]
        [Route("GetAllSuppliers")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult GetAllSuppliers()
        {
            List<SUP01> suppliers = _objBLSupplier.GetAllSuppliers();
            if (suppliers != null)
                return Ok(suppliers);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Adds a new supplier.
        /// </summary>
        /// <param name="supplier">The supplier to add.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPost]
        [Route("AddSupplier")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult AddSupplier(SUP01 supplier)
        {
            if (_objBLSupplier.AddSupplier(supplier))
                return Ok("Supplier added successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Updates an existing supplier.
        /// </summary>
        /// <param name="supplierId">The ID of the supplier to update.</param>
        /// <param name="supplier">The updated supplier data.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateSupplier")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult UpdateSupplier(int supplierId, SUP01 supplier)
        {
            if (_objBLSupplier.UpdateSupplier(supplierId, supplier))
                return Ok("Supplier updated successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Deletes a supplier.
        /// </summary>
        /// <param name="supplierId">The ID of the supplier to delete.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteSupplier")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult DeleteSupplier(int supplierId)
        {
            if (_objBLSupplier.DeleteSupplier(supplierId))
                return Ok("Supplier deleted successfully.");
            else
                return InternalServerError();
        }

        //[HttpGet]
        //[Route("GenerateTransactionsFile")]
        //[BearerAuthentication]
        //[Authorize(Roles = ("Supplier"))]
        //public IHttpActionResult GenerateTransactionsFile()
        //{
        //    try
        //    {
        //        // Pass the user role to the GenerateTransactionJsonFile method
        //        _objBLTransaction.GenerateTransactionJsonFile("supplier");
        //        return Ok("Supplier transactions JSON file generated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //        return InternalServerError(ex);
        //    }
        //}

        #endregion
    }
}

