using Job_Finder.Enum;
using System.ComponentModel.DataAnnotations;

namespace Job_Finder.Model.POCO
{
    public class JOS01
    {
        /// <summary>
        /// Job seeker ID.
        /// </summary>
        public int S01F01 { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string S01F02 { get; set; }

        /// <summary>
        /// Qualification
        /// </summary>
        public string S01F03 { get; set; }

        /// <summary>
        /// Experiance
        /// </summary>
        public string S01F04 { get; set; }

        /// <summary>
        /// Resume  
        /// </summary>
       // [DataType(DataType.Upload)]
        public IFormFile S01F05 { get; set; }

        /// <summary>
        /// Contact Details.
        /// </summary>
        public string S01F06 { get; set; }

        /// <summary>
        /// Gender(M, F).
        /// </summary>
        public enmGender S01F07 { get; set; }

        /// <summary>
        /// EmailID
        /// </summary>
        public string S01F08 { get; set; }
    }
}
