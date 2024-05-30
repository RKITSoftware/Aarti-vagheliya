using Job_Finder.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Job_Finder.Model.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing job listing details.
    /// </summary>
    public class DtoJOL01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Job ID.
        /// </summary>
        [JsonProperty("L01101")]
        public int L01F01 { get; set; }

        /// <summary>
        /// Gets or sets the Job Title.
        /// </summary>
        [JsonProperty("L01102")]
        [Required(ErrorMessage = "Job Title is required.")]
        public string L01F02 { get; set; }

        /// <summary>
        /// Gets or sets the Company ID.
        /// </summary>
        [JsonProperty("L01103")]
        [Required(ErrorMessage = "Company ID is required.")]
        public int L01F03 { get; set; }

        /// <summary>
        /// Gets or sets the Salary.
        /// </summary>
        [JsonProperty("L01104")]
        [Required(ErrorMessage = "Salary is required.")]
        public decimal L01F04 { get; set; }

        /// <summary>
        /// Gets or sets the Job Type (e.g., Ft, Pt, Rm, Fl).
        /// </summary>
        [JsonProperty("L01105")]
        [Required(ErrorMessage = "Job Type is required.")]
        public enmJobType L01F05 { get; set; }

        /// <summary>
        /// Gets or sets the Basic Requirements.
        /// </summary>
        [JsonProperty("L01106")]
        [Required(ErrorMessage = "Basic requirements are required.")]
        public dynamic L01F06 { get; set; }

        #endregion
    }
}
