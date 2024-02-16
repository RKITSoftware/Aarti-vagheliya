using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo_Advance_C_.Models
{
    [Alias("USR01")]
    public class USR01
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [AutoIncrement]
        public int R01F01 { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string R01F02 { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string R01F03 { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string R01F04 { get; set; }

        /// <summary>
        /// Gets or sets the roles assigned to the user.
        /// </summary>
        public string R01F05 { get; set; }
    }
}