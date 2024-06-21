using FinalDemo_Advance_C_.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinalDemo_Advance_C_.Models.DTO
{
    /// <summary>
    /// Represents a user entity with properties for UserID, Username, Password, Email, and Role.
    /// </summary>
    public class DtoUSR01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [JsonProperty("R01101")]
        [Required]
        [ServiceStack.DataAnnotations.PrimaryKey]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [JsonProperty("R01102")]
        [Required(ErrorMessage = "Username is required."), StringLength(100)]
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [JsonProperty("R01103")]
        [Required ( ErrorMessage = "Password is required.")]
        public string R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [JsonProperty("R01104")]
        [Required (ErrorMessage = "Email is required.")]
        public string R01F04 { get; set; }

        /// <summary>
        /// Represent role of User(Admin, DEO, Accountant).
        /// </summary>
        [JsonProperty("R01105")]
        [Required]
        public enmUserRole R01F05 { get; set; } 

        #endregion
    }
}