
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Versioning_Using_URI.BL;
using Versioning_Using_URI.Models;

namespace Versioning_Using_URI.Controllers
{
    /// <summary>
    /// Controller for managing StateV2 entities with versioning using URI.
    /// </summary>
    public class CLStateV2Controller : ApiController
    {
        #region Private Member

        /// <summary>
        /// Instance of BLStateV2 class.
        /// </summary>
        private BLStateV2 _objBLStateV2 = new BLStateV2();

        #endregion

        #region Public Method

        /// <summary>
        /// Gets all StateV2 objects.
        /// </summary>
        /// <returns>An IEnumerable collection of StateV2 objects.</returns>
        [HttpGet]
        public IEnumerable<StateV2> Get()
        {
            return _objBLStateV2.lstStateV2;
        }

        /// <summary>
        /// Gets a specific StateV2 object by its ID.
        /// </summary>
        /// <param name="id">The ID of the StateV2 object to retrieve.</param>
        /// <returns>The StateV2 object with the specified ID.</returns>
        [HttpGet]
        public StateV2 Get(int id)
        {
            return _objBLStateV2.lstStateV2.FirstOrDefault(x => x.Id == id);       
        }

        #endregion
    }
}
