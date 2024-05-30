using Job_Finder.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Job_Finder.Model.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing job seeker details.
    /// </summary>
    public class DtoJOS01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Job Seeker ID.
        /// </summary>
        [JsonProperty("S01101")]
        public int S01F01 { get; set; }

        /// <summary>
        /// Gets or sets the Job Seeker Name.
        /// </summary>
        [JsonProperty("S01102")]
        [Required(ErrorMessage = "Name is required.")]
        public string S01F02 { get; set; }

        /// <summary>
        /// Gets or sets the Qualification.
        /// </summary>
        [JsonProperty("S01103")]
        [Required(ErrorMessage = "Qualification is required.")]
        public string S01F03 { get; set; }

        /// <summary>
        /// Gets or sets the Experience.
        /// </summary>
        [JsonProperty("S01104")]
        [Required(ErrorMessage = "Experience is required.")]
        public string S01F04 { get; set; }

        /// <summary>
        /// Gets or sets the Resume.
        /// </summary>
        [JsonProperty("S01105")]
        [JsonIgnore]
        [Required(ErrorMessage = "Resume is required.")]
        public IFormFile S01F05 { get; set; }

        /// <summary>
        /// Gets or sets the Contact Details.
        /// </summary>
        [JsonProperty("S01106")]
        [Required(ErrorMessage = "Contact detail is required.")]
        public string S01F06 { get; set; }

        /// <summary>
        /// Gets or sets the Gender (M, F).
        /// </summary>
        [JsonProperty("S01107")]
        [Required(ErrorMessage = "Gender is required.")]
        public enmGender S01F07 { get; set; }

        /// <summary>
        /// Gets or sets the Email ID.
        /// </summary>
        [JsonProperty("S01108")]
        [Required(ErrorMessage = "Email Id is required.")]
        public string S01F08 { get; set; }

        #endregion
    }
}
