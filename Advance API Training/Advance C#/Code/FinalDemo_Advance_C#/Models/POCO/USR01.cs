using FinalDemo_Advance_C_.Enums;
using ServiceStack.DataAnnotations;

namespace FinalDemo_Advance_C_.Models.POCO
{
    /// <summary>
    /// Represents a user entity with properties for UserID, Username, Password, Email, and Role.
    /// </summary>
    [Alias("USR01")]
    public class USR01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [AutoIncrement]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string R01F04 { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public enmUserRole R01F05 { get; set; } // Use enum type for roles

        #endregion
    }
}