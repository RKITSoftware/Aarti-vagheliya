using HTTPCaching.BL;
using HTTPCaching.Caching;
using System.Web.Http;

namespace HTTPCaching.Controllers
{
    /// <summary>
    /// Controller for handling state-related operations.
    /// </summary>
    public class CLStateController : ApiController
    {
        #region Private Member

        /// <summary>
        /// Private instance of BLStateData
        /// </summary>
        private BLStateData _objBLStateData = new BLStateData();

        #endregion

        #region Public Method

        /// <summary>
        /// Fetches state data and applies caching using the CacheFilter attribute.
        /// </summary>
        /// <returns>HTTP response with state data.</returns>
        [HttpGet]
        [Route("api/State/FetchStateData")]
        [CacheFilter(Duration = 100)]
       public IHttpActionResult FetchStateData()
        {
            // Retrieves state data from the data source.
            var stateData = _objBLStateData.RetriveStateData();

            // Returns an HTTP response with the retrieved state data.
            return Ok(stateData);
        }
        #endregion
    }
}
