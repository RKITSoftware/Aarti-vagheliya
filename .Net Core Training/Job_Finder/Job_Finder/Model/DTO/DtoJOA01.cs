using Newtonsoft.Json;
using ServiceStack.DataAnnotations;

namespace Job_Finder.Model.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing job application details.
    /// </summary>
    public class DtoJOA01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Job Application ID.
        /// </summary>
        [JsonProperty("A01101")]
        [PrimaryKey, AutoIncrement]
        public int A01F01 { get; set; }

        /// <summary>
        /// Gets or sets the Job ID.
        /// </summary>
        [JsonProperty("A01102")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Job Id is required.")]
        public int A01F02 { get; set; }

        /// <summary>
        /// Gets or sets the Job Seeker ID.
        /// </summary>
        [JsonProperty("A01103")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Job seeker Id is required.")]
        public int A01F03 { get; set; }

        #endregion
    }
}
