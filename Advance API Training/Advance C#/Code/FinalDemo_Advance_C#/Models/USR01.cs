using ServiceStack.DataAnnotations;

namespace FinalDemo_Advance_C_.Models
{
    /// <summary>
    /// Represents the roles that can be assigned to a user.
    /// </summary>
    public enum UserRole
    {
        Admin,
        Seller,
        Supplier,
        Customer

    }

    /// <summary>
    /// Represents a user entity with properties for UserID, Username, Password, Email, and Role.
    /// </summary>
    [Alias("USR01")]
    public class USR01
    {
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
        public UserRole R01F05 { get; set; } // Use enum type for roles

        
    }
}