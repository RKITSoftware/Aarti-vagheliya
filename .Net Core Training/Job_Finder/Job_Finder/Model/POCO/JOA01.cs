using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    public class JOA01
    {
        /// <summary>
        /// Job Application ID.
        /// </summary>
        public int A01F01 { get; set; }

        /// <summary>
        /// Job ID 
        /// </summary>
        public int A01F02 { get; set; }

        /// <summary>
        /// Job Seeker ID.
        /// </summary>
        public int A01F03 { get; set; }

        /// <summary>
        /// represent Job Apllication Status.
        /// </summary>
        public enmJobApplicationStatus A01F04 { get; set; }

    }
}
