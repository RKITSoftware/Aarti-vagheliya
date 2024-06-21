using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    /// <summary>
    /// Represents a job seeker entity.
    /// </summary>
    public class JOS01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the job seeker ID.
        /// </summary>
        public int S01F01 { get; set; }

        /// <summary>
        /// Gets or sets the name of the job seeker.
        /// </summary>
        public string S01F02 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the qualification of the job seeker.
        /// </summary>
        public string S01F03 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the experience of the job seeker.
        /// </summary>
        public string S01F04 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the contact details of the job seeker.
        /// </summary>
        public string S01F06 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the gender of the job seeker (Male or Female).
        /// </summary>
        public enmGender S01F07 { get; set; }

        /// <summary>
        /// Gets or sets the email ID of the job seeker.
        /// </summary>
        public string S01F08 { get; set; } = string.Empty;

        #endregion
    }
}
