using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    /// <summary>
    /// Represents a job listing entity.
    /// </summary>
    public class JOL01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the job ID.
        /// </summary>
        public int L01F01 { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        public string L01F02 { get; set; }

        /// <summary>
        /// Gets or sets the company ID.
        /// </summary>
        public int L01F03 { get; set; }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        public decimal L01F04 { get; set; }

        /// <summary>
        /// Gets or sets the job type (e.g., Full-time, Part-time, Remote, Freelance).
        /// </summary>
        public enmJobType L01F05 { get; set; }

        /// <summary>
        /// Gets or sets the requirements for the job.
        /// </summary>
        public dynamic L01F06 { get; set; }

        #endregion
    }
}
