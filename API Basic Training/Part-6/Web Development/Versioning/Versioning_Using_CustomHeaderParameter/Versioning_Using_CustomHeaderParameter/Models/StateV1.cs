

namespace Versioning_Using_CustomHeaderParameter.Models
{
    /// <summary>
    /// Represents the StateV1 entity with basic properties.
    /// </summary>
    public class StateV1
    {
        /// <summary>
        /// Gets or sets the unique identifier of the StateV1 entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the state in the StateV1 entity.
        /// </summary>
        public string StateName { get; set; }
    }
}