using Middleware_Filter_Integration.Enum;
using ServiceStack.DataAnnotations;

namespace Middleware_Filter_Integration.Model.POCO
{
    /// <summary>
    /// Represents a user entity with details such as User ID, Username, Password, and User Role.
    /// </summary>
    public class USR01
    {
        #region Public Member

        /// <summary>
        /// Gets or sets the User ID. This field is auto-incremented and is the primary key.
        /// </summary>
        [AutoIncrement,PrimaryKey]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the User Role.
        /// </summary>
        public enmUserRole R01F04 { get; set; }

        #endregion
    }
}
