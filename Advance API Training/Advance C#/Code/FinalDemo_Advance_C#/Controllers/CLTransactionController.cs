using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Controller for managing transactions.
    /// </summary>
    [RoutePrefix("api/transactions")]
    public class CLTransactionController : ApiController
    {
        // Instance of the transaction business logic class
        private readonly BLTransaction _objBLTransaction = new BLTransaction();

        /// <summary>
        /// Retrieves all transactions.
        /// </summary>
        /// <returns>The list of transactions.</returns>
        [HttpGet]
        [Route("GetAllTransactions")]
        [BearerAuthentication]
        [Authorize(Roles = ("Admin"))]
        public IHttpActionResult GetAllTransactions()
        {
            List<TRA01> transactions = _objBLTransaction.GetAllTransactions(); // Retrieves all transactions from the database
            if (transactions != null) // Checks if transactions exist
            {
                return Ok(transactions); // Returns the list of transactions
            }
            else
            {
                return InternalServerError(); // Returns an internal server error response
            }
        }

        /// <summary>
        /// Inserts a new transaction.
        /// </summary>
        /// <param name="transaction">The transaction to be inserted.</param>
        /// <returns>A response indicating the success of the operation.</returns>
        [HttpPost]
        [Route("InsertTransaction")]
        [BearerAuthentication]
        [Authorize(Roles = ("Seller,Admin,Supplier"))]
        public IHttpActionResult InsertTransaction(TRA01 transaction)
        {
            bool success = _objBLTransaction.InsertTransaction(transaction); // Inserts the transaction into the database
            if (success) // Checks if the transaction was inserted successfully
            {
                return Ok("Transaction inserted successfully."); // Returns a success response
            }
            else
            {
                return InternalServerError(); // Returns an internal server error response
            }
        }

        /// <summary>
        /// Generates a JSON file for transactions.
        /// </summary>
        /// <returns>A response indicating the success of the operation.</returns>
        [HttpGet]
        [Route("GenerateJSONFile")]
        public IHttpActionResult GenerateJSONFile()
        {
            try
            {
                _objBLTransaction.GenerateTransactionJsonFile(); // Generates a JSON file for transactions
                return Ok("JSON file generated successfully."); // Returns a success response
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Returns an internal server error response with the exception
            }
        }
    }
}
