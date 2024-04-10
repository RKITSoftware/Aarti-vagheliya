using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using System;

namespace ORMDemo.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for FAC01 entity.
    /// </summary>
    public class DtoFAC01
    {
        /// <summary>
        /// FacultyName
        /// </summary>
        [Required]
        [JsonProperty("C01F02")]
        [Default("'ABC'")]
        public string C01102 { get; set; }

        /// <summary>
        /// Department
        /// </summary>
        [Required]
        [Default("'CE'")]
        [JsonProperty("C01F03")]
        public string C01103 { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [Required]
        [Default("'Male'")]
        [JsonProperty("C01F04")]
        public string C01104 { get; set; }

        /// <summary>
        /// Joining Date
        /// </summary>
        [Required]
        [JsonProperty("C01F05")]
        public DateTime C01105 { get; set; } = DateTime.Now;

        /// <summary>
        /// EmailId
        /// </summary>
        [Required, Unique]
        [Default("''")]
        [JsonProperty("C01F06")]
        public string C01106 { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        [Default(25)]
        [JsonProperty("C01F07")]
        public int C01107 { get; set; }
    }
}