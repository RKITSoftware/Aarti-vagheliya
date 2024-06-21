using System.Data;

namespace FinalDemo_Advance_C_.Models
{
    /// <summary>
    /// Represents the response structure for operations, indicating success or failure, along with a message and optional data table.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Indicates whether the operation resulted in an error.
        /// </summary>
        public bool isError { get; set; } = false;

        /// <summary>
        /// Provides a descriptive message about the operation's outcome.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Contains the response data in the form of a DataTable, if applicable.
        /// </summary>
        public DataTable response { get; set; }
    }
}