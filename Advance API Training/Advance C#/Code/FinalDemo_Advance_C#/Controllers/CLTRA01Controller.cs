using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using FinalDemo_Advance_C_.Models.DTO;
using System;
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
    [BearerAuthentication] // Performs bearer token authentication
    public class CLTRA01Controller : ApiController
    {
        #region Private Member

        /// <summary>
        /// Instance of the transaction business logic class
        /// </summary>
        private readonly BLTRA01Handler _objBLTRA01Handler;

        /// <summary>
        /// File path to store transaction data
        /// </summary>
        private readonly string _transactionFilePath = @"F:\Arti-368\New folder\Advance API Training\Advance C#\Code\FinalDemo_Advance_C#\App_Data\transactions.json";

        /// <summary>
        /// Private instance of Response class.
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLTRA01Controller"/> class.
        /// </summary>
        public CLTRA01Controller()
        {
            _objBLTRA01Handler = new BLTRA01Handler();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all transactions.
        /// </summary>
        /// <returns>HTTP response containing transaction data.</returns>
        [HttpGet]
        [Route("GetAllTransactions")]
        [Authorize(Roles = ("Ad,De,Ac"))]
        public IHttpActionResult GetAllTransactions()
        {
            _objResponse = new Response();
            _objResponse = _objBLTRA01Handler.Select();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Retrieves a transaction bill.
        /// </summary>
        /// <returns>HTTP response containing transaction bill data.</returns>
        [HttpGet]
        [Route("GetTransactionBill")]
        [Authorize(Roles = ("Ad,De,Ac"))]
        public IHttpActionResult GetTransactionBill()
        {
            _objResponse = new Response();
            _objResponse = _objBLTRA01Handler.GetTransactionBill();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Retrieves transaction-wise bill.
        /// </summary>
        /// <returns>HTTP response containing transaction-wise bill data.</returns>
        [HttpGet]
        [Route("TransactionWiseBill")]
        [Authorize(Roles = ("Ad,De,Ac"))]
        public IHttpActionResult TransactionWiseBill()
        {
            _objResponse = new Response();
            _objResponse = _objBLTRA01Handler.TransactionWiseBill();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Adds a new transaction.
        /// </summary>
        /// <param name="transaction">The transaction to add.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPost]
        [Route("AddTransaction")]
        [Authorize(Roles = ("Ad,De,Ac"))]
        public IHttpActionResult AddTransaction(DtoTRA01 transaction)
        {
            _objBLTRA01Handler.PreSave(transaction);

            Response response = _objBLTRA01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLTRA01Handler.Save();
            }

            return Ok(response);
        }

        /// <summary>
        /// Generates a JSON file for transactions.
        /// </summary>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpGet]
        [Route("GenerateJSONFile")]
        [Authorize(Roles = ("Ad,De,Ac"))]
        public IHttpActionResult GenerateJSONFile()
        {
            try
            {
                _objBLTRA01Handler.GenerateTransactionJsonFile(); // Generates a JSON file for transactions
                return Ok("JSON file generated successfully."); // Returns a success response
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); // Returns an internal server error response with the exception
            }
        }


        /// <summary>
        /// Downloads the transaction JSON file.
        /// </summary>
        /// <returns>HTTP response containing the transaction JSON file.</returns>
        [HttpGet]
        [Route("Download")]
        [Authorize(Roles = ("Ad,De,Ac"))]
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
