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
    [RoutePrefix("api/transactions")]
    public class CLTransactionController : ApiController
    {
        private readonly BLTransaction _objBLTransaction = new BLTransaction();

        [HttpGet]
        [Route("GetAllTransactions")]
        public IHttpActionResult GetAllTransactions()
        {
            List<TRA01> transactions = _objBLTransaction.GetAllTransactions();
            if (transactions != null)
            {
                return Ok(transactions);
            }
            else
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("InsertTransaction")]
        public IHttpActionResult InsertTransaction(TRA01 transaction)
        {
            bool success = _objBLTransaction.InsertTransaction(transaction);
            if (success)
            {
                return Ok("Transaction inserted successfully.");
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
