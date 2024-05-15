using System.Collections.Generic;
using Versioning_Using_AcceptHeaderParameter.Models;

namespace Versioning_Using_AcceptHeaderParameter.BL
{
    /// <summary>
    /// V1 state handling.
    /// </summary>
    public class BLStateV1
    {
        /// <summary>
        /// list to store StateV1 objects
        /// </summary>
        public List<StateV1> lststateV1 = new List<StateV1>
        {
            new StateV1 { Id = 1, StateName = "Assam"},
            new StateV1 { Id = 2, StateName = "Gujarat"},
            new StateV1 { Id = 3, StateName = "Goa"},
        };

    }
}