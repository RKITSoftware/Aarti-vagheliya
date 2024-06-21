using Job_Finder.Enum;

namespace Job_Finder.Model.POCO
{
    /// <summary>
    /// Represents a company entity.
    /// </summary>
    public class CMP01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the company ID.
        /// </summary>
        public int P01F01 { get; set; }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string P01F02 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the company website URL.
        /// </summary>
        public string P01F03 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the company location.
        /// </summary>
        public string P01F04 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the company capacity.
        /// </summary>
        public int P01F05 { get; set; }

        /// <summary>
        /// Gets or sets the company ratings.
        /// </summary>
        public decimal P01F06 { get; set; }

        /// <summary>
        /// Gets or sets the type of the company (Product-based or Service-based).
        /// </summary>
        public enmCompanyType P01F07 { get; set; }

        #endregion
    }
}
