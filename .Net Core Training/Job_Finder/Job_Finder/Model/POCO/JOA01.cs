using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    /// <summary>
    /// Represents a job application entity.
    /// </summary>
    public class JOA01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the job application ID.
        /// </summary>
        public int A01F01 { get; set; }

        /// <summary>
        /// Gets or sets the job ID.
        /// </summary>
        public int A01F02 { get; set; }

        /// <summary>
        /// Gets or sets the job seeker ID.
        /// </summary>
        public int A01F03 { get; set; }

        /// <summary>
        /// Gets or sets the job application status.
        /// </summary>
        public enmJobApplicationStatus A01F04 { get; set; } = enmJobApplicationStatus.AP;

        #endregion
    }
}
