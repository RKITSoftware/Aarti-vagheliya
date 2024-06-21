using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    /// <summary>
    /// Represents a user entity.
    /// </summary>
    public class USR01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string R01F02 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string R01F03 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string R01F04 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        public enmUserRole R01F05 { get; set; }

        #endregion
    }
}
 