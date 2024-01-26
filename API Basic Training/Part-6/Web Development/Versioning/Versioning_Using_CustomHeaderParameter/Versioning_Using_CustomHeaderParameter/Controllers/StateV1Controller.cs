
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Versioning_Using_CustomHeaderParameter.Models;

namespace Versioning_Using_CustomHeaderParameter.Controllers
{
    /// <summary>
    /// Controller for managing StateV1 entities with versioning using custom header parameter.
    /// </summary>
    public class StateV1Controller : ApiController
    {
        // Static list to store StateV1 objects
        public static List<StateV1> objstateV1 = new List<StateV1>
        {
            new StateV1 { Id = 1, StateName = "Assam"},
            new StateV1 { Id = 2, StateName = "Gujarat"},
            new StateV1 { Id = 3, StateName = "Goa"},
        };


        /// <summary>
        /// Gets all StateV1 objects.
        /// </summary>
        /// <returns>An IEnumerable collection of StateV1 objects.</returns>
        [HttpGet]
        public IEnumerable<StateV1> Get()
        {
            return objstateV1;
        }


        /// <summary>
        /// Gets a specific StateV1 object by its ID.
        /// </summary>
        /// <param name="id">The ID of the StateV1 object to retrieve.</param>
        /// <returns>The StateV1 object with the specified ID.</returns>
        [HttpGet]
        public StateV1 Get(int id)
        {
            return objstateV1.FirstOrDefault(x => x.Id == id);
        }
    }
}
