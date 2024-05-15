using Job_Finder.Enum;
using Newtonsoft.Json;
using ServiceStack;
using System.ComponentModel.DataAnnotations;

namespace Job_Finder.Model.DTO
{
    public class DtoJOL01
    {
        /// <summary>
        /// Job ID.
        /// </summary>
        [JsonProperty("L01101")]
        public int L01F01 { get; set; }

        /// <summary>
        /// Job Title
        /// </summary>
        [JsonProperty("L01102")]
        [Required(ErrorMessage = "Job Title is required.")]
        public string L01F02 { get; set; }

        /// <summary>
        /// Company id
        /// </summary>
        [JsonProperty("L01103")]
        [Required(ErrorMessage = "Company id is required.")]
        public int L01F03 { get; set; }

        /// <summary>
        /// Salary
        /// </summary>
        [JsonProperty("L01104")]
        [Required(ErrorMessage = "Salary is required.")]
        public decimal L01F04 { get; set; }

        /// <summary>
        /// Represent Job type(Ft, Pt, Rm, Fl)
        /// </summary>
        [JsonProperty("L01105")]
        [Required(ErrorMessage = "Job Type is required.")]
        public enmJobType L01F05 { get; set; }

        /// <summary>
        /// Basic Requirnments
        /// </summary>
        [JsonProperty("L01106")]
        [Required(ErrorMessage = "Basic requirments is required.")]
        public dynamic L01F06 { get; set; }
    }
}
