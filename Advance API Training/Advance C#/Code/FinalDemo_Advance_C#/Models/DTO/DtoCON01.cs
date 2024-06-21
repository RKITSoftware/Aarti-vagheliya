using FinalDemo_Advance_C_.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinalDemo_Advance_C_.Models.DTO
{ 
   
    /// <summary>
    /// Represents a contact entity.
    /// </summary>
    public class DtoCON01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the contact ID.
        /// </summary>
        [ServiceStack.DataAnnotations.PrimaryKey]
        [Required]
        [JsonProperty("N01101")]
        public int N01F01 { get; set; } 

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        [JsonProperty("N01102")]
        [Required (ErrorMessage = "Company name is required.")]
        public string N01F02 { get; set; }

        /// <summary>
        /// Gets or sets the email ID.
        /// </summary>
        [JsonProperty("N01103")]
        [Required(ErrorMessage = "Email address is required.")]
        public string N01F03 { get; set; } 

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("N01104")]
        [Required (ErrorMessage = "Enter Description.")]
        public string N01F04 { get; set; } 

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [JsonProperty("N01105")]
        [Required (ErrorMessage = "City is required.")]
        public string N01F05 { get; set; } 

        /// <summary>
        /// Roles of contact types ( Supplier, Retailer, Wholesaler, Consumer). 
        /// </summary>
        [JsonProperty("N01106")]
        [Required (ErrorMessage = "Enter Contact type.")]
        public enmContactType N01F06 { get; set; } 

        #endregion
    }
}