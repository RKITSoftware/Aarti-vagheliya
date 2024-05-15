using System.Data;

namespace FinalDemo_WebAPI.Models
{
    /// <summary>
    /// Class that represent properties for Response Object.
    /// </summary>
    public class Response
    {
        #region Public Member

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

        #endregion
    }
}