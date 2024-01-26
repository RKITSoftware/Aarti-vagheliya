namespace Versioning_Using_QueryStringParameter.Models
{

    /// <summary>
    /// Represents the StateV1 model for version 1 of the State entity.
    /// </summary>
    public class StateV1
    {
        /// <summary>
        /// Gets or sets the ID of the StateV1 entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the state.
        /// </summary>
        public string StateName { get; set; }
    }
}