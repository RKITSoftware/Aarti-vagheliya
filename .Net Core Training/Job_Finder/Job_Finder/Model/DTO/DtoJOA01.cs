using Job_Finder.Enum;
using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Job_Finder.Model.DTO
{
    public class DtoJOA01
    {
        /// <summary>
        /// Job Application ID.
        /// </summary>
        [JsonProperty("A01101")]
        [PrimaryKey, AutoIncrement]
        public int A01F01 { get; set; }

        /// <summary>
        /// Job ID 
        /// </summary>
        [JsonProperty("A01102")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Job Id is required.")]
        public int A01F02 { get; set; }

        /// <summary>
        /// Job Seeker ID.
        /// </summary>
        [JsonProperty("A01103")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Job seeker Id is required.")]
        public int A01F03 { get; set; }

        /// <summary>
        /// represent Job Apllication Status.
        /// </summary>
        [JsonProperty("A01104")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Job Application Status is required.")]
        public enmJobApplicationStatus A01F04 { get; set; }

    }
}
