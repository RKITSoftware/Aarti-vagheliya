namespace Middleware_Filter_Integration.Model
{
    /// <summary>
    /// Represents the response of an operation, containing status, message, and response data.
    /// </summary>
    public class Response
    {
        #region Public Properties

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
        public dynamic response { get; set; }

        #endregion
    }
}
