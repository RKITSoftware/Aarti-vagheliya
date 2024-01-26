

namespace Versioning_Using_AcceptHeaderParameter.Models
{
    /// <summary>
    /// Represents the StateV2 entity with a unique identifier, state name, and state code.
    /// </summary>
    public class StateV2
    {
        /// <summary>
        /// Gets or sets the unique identifier of the StateV2 entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the state in the StateV2 entity.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets the state code in the StateV2 entity.
        /// </summary>
        public string StateCode { get; set; }
    }
}