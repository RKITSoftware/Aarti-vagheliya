using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinalDemo_Advance_C_.Models.DTO
{
    /// <summary>
    /// Represents a product entity with properties.
    /// </summary>
    public class DtoPRD01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the ProductID.
        /// </summary>
        [JsonProperty("D01101")]
        [Required]
        public int D01F01 { get; set; } 

        /// <summary>
        /// Gets or sets the ProductName.
        /// </summary>
        [JsonProperty("D01102")]
        [Required (ErrorMessage = "Product Name is required.")]
        public string D01F02 { get; set; } 

        /// <summary>
        /// Gets or sets the CategoryID.
        /// </summary>
        [JsonProperty("D01103")]
        [Required (ErrorMessage = "Enter Category ID.")]
        public int? D01F03 { get; set; } 

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        [JsonProperty("D01104")]
        public string D01F04 { get; set; } 

        /// <summary>
        /// Gets or sets the UnitPrice.
        /// </summary>
        [JsonProperty("D01105")]
        [Required (ErrorMessage = "Unit price of the product is required."), ServiceStack.DataAnnotations.DecimalLength(precision:10, scale:2)]
        public decimal? D01F05 { get; set; } 

        /// <summary>
        /// Gets or sets the Selling Price.
        /// </summary>
        [JsonProperty("D01106")]
        [Required (ErrorMessage = "Selling price of the product is required."), ServiceStack.DataAnnotations.DecimalLength(precision: 10, scale: 2)]
        public decimal? D01F06 { get; set; } 

        #endregion
    }
}