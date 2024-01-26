
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Versioning_Using_AcceptHeaderParameter.Models;

namespace Versioning_Using_AcceptHeaderParameter.Controllers
{
    /// <summary>
    /// Controller for managing StateV2 entities with versioning using Accept Header parameter.
    /// </summary>
    public class StateV2Controller : ApiController
    {
        // Static list to store StateV2 objects
        public static List<StateV2> objStateV2 = new List<StateV2>
        {
            new StateV2 { Id = 1, StateName = "Assam", StateCode = "AS"},
            new StateV2 { Id = 2, StateName = "Gujarat", StateCode = "GJ"},
            new StateV2 { Id = 3, StateName = "Goa" , StateCode = "GA"},
        };


        /// <summary>
        /// Gets all StateV2 objects.
        /// </summary>
        /// <returns>An IEnumerable collection of StateV2 objects.</returns>
        [HttpGet]
        public IEnumerable<StateV2> Get()
        {
            return objStateV2;
        }


        /// <summary>
        /// Gets a specific StateV2 object by its ID.
        /// </summary>
        /// <param name="id">The ID of the StateV2 object to retrieve.</param>
        /// <returns>The StateV2 object with the specified ID.</returns>
        [HttpGet]
        public StateV2 Get(int id)
        {
            return objStateV2.FirstOrDefault(x => x.Id == id);
        }
    }
}
