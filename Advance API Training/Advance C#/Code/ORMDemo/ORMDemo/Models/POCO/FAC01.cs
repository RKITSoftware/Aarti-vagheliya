using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using System;

namespace ORMDemo.Models.POCO
{
    /// <summary>
    /// Repesents poco entity for faculty table.
    /// </summary>
    [Alias("FAC01")]
    public class FAC01
    {
        /// <summary>
        /// FacultyId
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int C01F01 { get; set; }

        /// <summary>
        /// FacultyName
        /// </summary>
        [Required]
        [JsonProperty("C01102")]
        [Default("'ABC'")]
        public string C01F02 { get; set; }

        /// <summary>
        /// Department
        /// </summary>
        [Required]
        [Default("'CE'")]
        [JsonProperty("C01103")]
        public string C01F03 { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [Required]
        [Default("'Male'")]
        [JsonProperty("C01104")]
        public string C01F04 { get; set; }

        /// <summary>
        /// Joining date
        /// </summary>
        [Required]
        [JsonProperty("C01105")]
        [Default("'2024-04-03'")]
        public DateTime C01F05 { get; set; } 

        /// <summary>
        /// EmailID
        /// </summary>
        [Required,Unique]
        [Default("''")]
        [JsonProperty("C01106")]
        public string C01F06 { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        [Default(25)]
        [JsonProperty("C01107")]
        public int C01F07 { get; set; }
    }
}