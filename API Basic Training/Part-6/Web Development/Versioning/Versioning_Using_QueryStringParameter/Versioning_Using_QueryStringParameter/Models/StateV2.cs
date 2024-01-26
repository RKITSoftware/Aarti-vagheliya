namespace Versioning_Using_QueryStringParameter.Models
{
    /// <summary>
    /// Represents the StateV2 model with additional StateCode property.
    /// </summary>
    public class StateV2
        {
            /// <summary>
            /// Gets or sets the ID of the StateV2 entity.
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the name of the state.
            /// </summary>
            public string StateName { get; set; }

            /// <summary>
            /// Gets or sets the code associated with the state.
            /// </summary>
            public string StateCode { get; set; }
        }
}
