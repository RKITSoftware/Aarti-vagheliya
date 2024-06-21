using FinalDemo_Advance_C_.Enums;
using ServiceStack.DataAnnotations;

namespace FinalDemo_Advance_C_.Models.POCO 
{ 
    /// <summary>
    /// Represents a contact entity.
    /// </summary>
    [Alias("CON01")]
    public class CON01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the contact ID.
        /// </summary>
        [AutoIncrement]
        public int N01F01 { get; set; } // Contact_Id

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        public string N01F02 { get; set; } // Company_Name

        /// <summary>
        /// Gets or sets the email ID.
        /// </summary>
        public string N01F03 { get; set; } // EmailId

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string N01F04 { get; set; } // Description

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string N01F05 { get; set; } // City

        /// <summary>
        /// Gets or sets the role for interaction.
        /// </summary>
        public enmContactType N01F06 { get; set; } // Role_For_interaction

        #endregion
    }
}