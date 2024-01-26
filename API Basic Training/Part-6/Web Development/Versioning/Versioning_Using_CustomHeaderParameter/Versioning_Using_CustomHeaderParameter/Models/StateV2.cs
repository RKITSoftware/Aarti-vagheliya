

namespace Versioning_Using_CustomHeaderParameter.Models
{
    /// <summary>
    /// Represents the StateV2 entity with additional properties for versioning.
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