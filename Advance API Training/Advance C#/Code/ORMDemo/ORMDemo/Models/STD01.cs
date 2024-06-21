using ServiceStack.DataAnnotations;
using System;

namespace ORMDemo.Models
{
    /// <summary>
    /// Represents a student entity.
    /// </summary>
    [Alias("STD01")]
    public class STD01
    {
        /// <summary>
        /// Gets or sets the student ID (e.g., D01F01).
        /// </summary>
        [AutoIncrement]
        public int D01F01 { get; set; }

        /// <summary>
        /// Gets or sets the student's first name.
        /// </summary>
        public string D01F02 { get; set; }

        /// <summary>
        /// Gets or sets the student's last name.
        /// </summary>
        public string D01F03 { get; set; }

        /// <summary>
        /// Gets or sets the student's date of birth.
        /// </summary>
        public DateTime D01F04 { get; set; }

        /// <summary>
        /// Gets or sets the student's gender (e.g., Male, Female, Other).
        /// </summary>
        public string D01F05 { get; set; }

        /// <summary>
        /// Gets or sets the student's email ID.
        /// </summary>
        public string D01F06 { get; set; }

        /// <summary>
        /// Faculty Id.
        /// </summary>
        public int D01F07 { get; set; }
    }
}