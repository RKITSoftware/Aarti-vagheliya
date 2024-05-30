using Job_Finder.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Job_Finder.Model.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing user details.
    /// </summary>
    public class DtoUSR01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the User ID.
        /// </summary>
        [JsonProperty("R01101")]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
        [JsonProperty("R01102")]
        [Required(ErrorMessage = "User Name is required.")]
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        [JsonProperty("R01103")]
        [Required(ErrorMessage = "Password is required.")]
        public string R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        [JsonProperty("R01104")]
        [Required(ErrorMessage = "Email is required.")]
        public string R01F04 { get; set; }

        /// <summary>
        /// Gets or sets the User Role.
        /// </summary>
        [JsonProperty("R01105")]
        [Required(ErrorMessage = "User Role is required.")]
        public enmUserRole R01F05 { get; set; }

        #endregion
    }
}
