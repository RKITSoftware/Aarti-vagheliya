using System.Data;

namespace CRUD_Operation.Models
{
    /// <summary>
    /// Represents result view model
    /// </summary>
    public class RES01
    {
        /// <summary>
        /// Flag indicating presence of errors
        /// </summary>
        public bool isError { get; set; }

        /// <summary>
        /// Response message if any
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Response
        /// </summary>
        public DataTable Response { get; set; } = new DataTable();
    }
}