using Job_Finder.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Job_Finder.Model.DTO
{
    public class DtoJOS01
    {
        /// <summary>
        /// Job seeker ID.
        /// </summary>
        [JsonProperty("S01101")]
        public int S01F01 { get; set; }

        /// <summary>
        /// Job seeker Name
        /// </summary>
        [JsonProperty("S01102")]
        [Required(ErrorMessage = "Name is required.")]
        public string S01F02 { get; set; }

        /// <summary>
        /// Qualification
        /// </summary>
        [JsonProperty("S01103")]
        [Required(ErrorMessage = "Qualification is required.")]
        public string S01F03 { get; set; }

        /// <summary>
        /// Experiance
        /// </summary>
        [JsonProperty("S01104")]
        [Required(ErrorMessage = "Experiance is required.")]
        public string S01F04 { get; set; }

        /// <summary>
        /// Resume  
        /// </summary>
        [JsonProperty("S01105")]
        [Required(ErrorMessage = "Resume is required.")]
        //[DataType(DataType.Upload)]
        //public IFormFile S01F05 { get; set; }
        public IFormFile S01F05 { get; set; }

        /// <summary>
        /// Contact Details.
        /// </summary>
        [JsonProperty("S01106")]
        [Required(ErrorMessage = "Contact detail is required.")]
        public string S01F06 { get; set; }

        /// <summary>
        /// Gender(M, F).
        /// </summary>
        [JsonProperty("S01107")]
        [Required(ErrorMessage = "Gender is required.")]
        public enmGender S01F07 { get; set; }

        /// <summary>
        /// EmailID
        /// </summary>
        [JsonProperty("S01108")]
        [Required(ErrorMessage = "Email Id is required.")]
        public string S01F08 { get; set; }
    }
}
