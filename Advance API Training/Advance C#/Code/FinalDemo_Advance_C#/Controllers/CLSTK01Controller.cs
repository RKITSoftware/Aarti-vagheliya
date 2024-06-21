using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Represents a controller for managing stock.
    /// </summary>
    [RoutePrefix("api/CLStock")]
    public class CLSTK01Controller : ApiController
    {
        #region Private member

        /// <summary>
        /// Instance of the stock business logic class
        /// </summary>
        private BLSTK01Handler _objBLSTK01Handler;
        
        /// <summary>
        /// Instance of Respone.
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLSTK01Controller"/> class.
        /// </summary>
        public CLSTK01Controller()
        {
            _objBLSTK01Handler = new BLSTK01Handler();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all stock entries.
        /// </summary>
        /// <returns>HTTP response containing stock entries.</returns>
        [HttpGet]
        [Route("GetAllStockEntries")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult GetAllStockEntries()
        {
            _objResponse = new Response();
            _objResponse = _objBLSTK01Handler.Select();
            return Ok(_objResponse);
        }

        #endregion
    }
}
