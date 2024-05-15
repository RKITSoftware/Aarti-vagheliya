
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Versioning_Using_AcceptHeaderParameter.BL;
using Versioning_Using_AcceptHeaderParameter.Models;

namespace Versioning_Using_AcceptHeaderParameter.Controllers
{
    /// <summary>
    /// Controller for managing StateV1 entities with versioning using Accept Header parameter.
    /// </summary>
    public class CLStateV1Controller : ApiController
    {
        /// <summary>
        /// Private instance of BLStateV1 class.
        /// </summary>
        private BLStateV1 _objBLStateV1 = new BLStateV1();


        /// <summary>
        /// Gets all StateV1 objects.
        /// </summary>
        /// <returns>An IEnumerable collection of StateV1 objects.</returns>
        [HttpGet]
        public IEnumerable<StateV1> Get()
        {
            return _objBLStateV1.lststateV1;
        }


        /// <summary>
        /// Gets a specific StateV1 object by its ID.
        /// </summary>
        /// <param name="id">The ID of the StateV1 object to retrieve.</param>
        /// <returns>The StateV1 object with the specified ID.</returns>
        [HttpGet]
        public StateV1 Get(int id)
        {
            return _objBLStateV1.lststateV1.FirstOrDefault(x => x.Id == id);
        }
    }
}
