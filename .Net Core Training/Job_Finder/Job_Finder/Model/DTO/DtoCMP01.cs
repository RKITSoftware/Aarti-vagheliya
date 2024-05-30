using Job_Finder.Enum;
using Newtonsoft.Json;
using ServiceStack.DataAnnotations;

namespace Job_Finder.Model.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing company details.
    /// </summary>
    public class DtoCMP01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Company Id.
        /// </summary>
        [JsonProperty("P01101")]
        [PrimaryKey, AutoIncrement]
        public int P01F01 { get; set; }

        /// <summary>
        /// Gets or sets the Company Name.
        /// </summary>
        [JsonProperty("P01102")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Company Name is Required.")]
        public string P01F02 { get; set; }

        /// <summary>
        /// Gets or sets the Website.
        /// </summary>
        [JsonProperty("P01103")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Website url is Required.")]
        public string P01F03 { get; set; }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        [JsonProperty("P01104")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Location is Required.")]
        public string P01F04 { get; set; }

        /// <summary>
        /// Gets or sets the Capacity.
        /// </summary>
        [JsonProperty("P01105")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Capacity is Required.")]
        public int P01F05 { get; set; }

        /// <summary>
        /// Gets or sets the Ratings.
        /// </summary>
        [JsonProperty("P01106")]
        [System.ComponentModel.DataAnnotations.Required]
        public decimal P01F06 { get; set; }

        /// <summary>
        /// Gets or sets the type of Company (Product-based or Service-based).
        /// </summary>
        [JsonProperty("P01107")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Company Type is Required.")]
        public enmCompanyType P01F07 { get; set; }

        #endregion
    }
}
