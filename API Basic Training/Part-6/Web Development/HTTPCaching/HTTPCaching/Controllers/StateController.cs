using HTTPCaching.Data;
using System.Web.Http;

namespace HTTPCaching.Controllers
{
    /// <summary>
    /// Controller for handling state-related operations.
    /// </summary>
    public class StateController : ApiController
    {
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
            var stateData = StateData.RetriveStateData();

            // Returns an HTTP response with the retrieved state data.
            return Ok(stateData);
        }
    }
}
