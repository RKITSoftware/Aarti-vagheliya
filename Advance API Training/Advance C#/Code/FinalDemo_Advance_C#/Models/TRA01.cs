using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo_Advance_C_.Models
{
    public class TRA01
    {
        /// <summary>
        /// Gets or sets the TransactionID.
        /// </summary>
        public int A01F01 { get; set; }

        /// <summary>
        /// Gets or sets the ProductID.
        /// </summary>
        public int A01F02 { get; set; }

        /// <summary>
        /// Gets or sets the TransactionType (e.g., Purchase, Sale).
        /// </summary>
        public string A01F03 { get; set; }

        /// <summary>
        /// Gets or sets the TransactionDate.
        /// </summary>
        public DateTime A01F04 { get; set; }

        /// <summary>
        /// Gets or sets the Quantity.
        /// </summary>
        public int A01F05 { get; set; }

        /// <summary>
        /// Gets or sets the TotalAmount.
        /// </summary>
        public decimal A01F06 { get; set; }
    }
}