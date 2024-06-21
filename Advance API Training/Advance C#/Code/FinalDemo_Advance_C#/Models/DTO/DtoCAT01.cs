using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinalDemo_Advance_C_.Models.DTO
{
    /// <summary>
    /// Represents a category entity with properties for CategoryID and CategoryName.
    /// </summary>
    public class DtoCAT01
    {
        #region Public Properties

       
        /// <summary>
        /// Gets or sets the CategoryID.
        /// </summary>
        [JsonProperty("T01101")]
        [Required]
        public int T01F01 { get; set; }

        /// <summary>
        /// Gets or sets the CategoryName.
        /// </summary>
        [JsonProperty("T01102")]
        [Required (ErrorMessage = "Category name is required.")]
        public string T01F02 { get; set; }

        /// <summary>
        /// Gets or sets the description for the T01F03 property.
        /// </summary>
        [JsonProperty("T01103")]
        [Required (ErrorMessage = "Description is required.")]
        public string T01F03 { get; set; } 

        #endregion
    }
}