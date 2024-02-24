using ServiceStack.DataAnnotations;

namespace FinalDemo_Advance_C_.Models
{
    #region Enum enmContactType

    /// <summary>
    /// Enum representing different types of contacts.
    /// </summary>
    public enum enmContactType
    {
        Supplier,
        Retailer,
        Wholesaler,
        Consumer
    }

    #endregion

    /// <summary>
    /// Represents a contact entity.
    /// </summary>
    [Alias("CNT01")]
    public class CNT01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the contact ID.
        /// </summary>
        [AutoIncrement]
        public int T01F01 { get; set; } // Contact_Id

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string T01F02 { get; set; } // Company_Name

        /// <summary>
        /// Gets or sets the email ID.
        /// </summary>
        public string T01F03 { get; set; } // EmailId

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string T01F04 { get; set; } // Description

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string T01F05 { get; set; } // City

        /// <summary>
        /// Gets or sets the role for interaction.
        /// </summary>
        public enmContactType T01F06 { get; set; } // Role_For_interaction

        #endregion
    }
}