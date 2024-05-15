using System.Collections.Generic;
using Versioning_Using_QueryStringParameter.Models;

namespace Versioning_Using_QueryStringParameter.BL
{
    /// <summary>
    /// Version 2 Satate Details.
    /// </summary>
    public class BLStateV2
    {
        /// <summary>
        /// list to store StateV2 objects
        /// </summary>
        public List<StateV2> lstStateV2 = new List<StateV2>
        {
            new StateV2 { Id = 1, StateName = "Assam", StateCode = "AS"},
            new StateV2 { Id = 2, StateName = "Gujarat", StateCode = "GJ"},
            new StateV2 { Id = 3, StateName = "Goa" , StateCode = "GA"},
        };
    }
}