﻿using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Controller for managing transactions.
    /// </summary>
    [RoutePrefix("api/transactions")]
    public class CLTransactionController : ApiController
    {
        #region Private Member

        // Instance of the transaction business logic class
        private readonly BLTransaction _objBLTransaction = new BLTransaction();

        // File path to store transaction data
        private readonly string _transactionFilePath = @"F:\Arti-368\New folder\Advance API Training\Advance C#\Code\FinalDemo_Advance_C#\App_Data\transactions.json";

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all transactions.
        /// </summary>
        /// <returns>The list of transactions.</returns>
        [HttpGet]
        [Route("GetAllTransactions")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO,Accountant"))]
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
        /// Retrieves transaction bill details from the database.
        /// </summary>
        /// <returns>The transaction bill details.</returns>
        [HttpGet]
        [Route("GetTransactionBill")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO,Accountant"))]
        public IHttpActionResult GetTransactionBill()
        {
            dynamic transactions = _objBLTransaction.GetTransactionBill(); // Retrieves all transactions from the database
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
        /// Retrieves transaction-wise bill details from the database.
        /// </summary>
        /// <returns>The transaction-wise bill details.</returns>
        [HttpGet]
        [Route("TransactionWiseBill")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO,Accountant"))]
        public IHttpActionResult TransactionWiseBill()
        {
            dynamic transactions = _objBLTransaction.TransactionWiseBill(); // Retrieves all transactions from the database
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
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO,Accountant"))]
        public IHttpActionResult InsertTransaction(TRA01 transaction)
        {
            bool success = _objBLTransaction.AddTransaction(transaction); // Inserts the transaction into the database
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
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO,Accountant"))]
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

        ///// <summary>
        ///// Generates a JSON file for transactions based on the specified bill type.
        ///// </summary>
        ///// <param name="billtype">The type of bill (e.g., purchase, sale).</param>
        ///// <returns>A response indicating the success of the operation.</returns>
        //[HttpGet]
        //[Route("GenerateTransactionsFile")]
        //[BearerAuthentication] // Performs bearer token authentication
        //[Authorize(Roles = ("Admin,DEO,Accountant"))]
        //public IHttpActionResult GenerateTransactionsFile(string billtype)
        //{
        //    try
        //    {
        //        // Pass the user role to the GenerateTransactionJsonFile method
        //        _objBLTransaction.GenerateTransactionJsonFile(billtype);
        //        return Ok($"{billtype} transactions JSON file generated successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //        return InternalServerError(ex);
        //    }
        //}

        /// <summary>
        /// Downloads the transaction JSON file.
        /// </summary>
        /// <returns>A response containing the transaction JSON file.</returns>
        [HttpGet]
        [Route("Download")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO,Accountant"))]
        public IHttpActionResult DownloadTransactionJsonFile()
        {

            if (!File.Exists(_transactionFilePath))
                return NotFound();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(_transactionFilePath, FileMode.Open));
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = Path.GetFileName(_transactionFilePath)
            };

            return ResponseMessage(response);
        }

        #endregion
    }
}