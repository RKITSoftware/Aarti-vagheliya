using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo_Advance_C_.Models
{
    public class PRD01
    {
        /// <summary>
        /// Gets or sets the ProductID.
        /// </summary>
        public int D01F01 { get; set; } // ProductID

        /// <summary>
        /// Gets or sets the ProductName.
        /// </summary>
        public string D01F02 { get; set; } // ProductName

        /// <summary>
        /// Gets or sets the CategoryID.
        /// </summary>
        public int? D01F03 { get; set; } // CategoryID

        /// <summary>
        /// Gets or sets the UnitPrice.
        /// </summary>
        public decimal? D01F04 { get; set; } // UnitPrice

        /// <summary>
        /// Gets or sets the SupplierID.
        /// </summary>
        public int? D01F05 { get; set; } // SupplierID

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string D01F06 { get; set; } // Description

        /// <summary>
        /// Gets or sets the Date when product add.
        /// </summary>
        public DateTime? D01F07 { get; set; } // DateAdded

        /// <summary>
        /// Gets or sets the Brand.
        /// </summary>
        public string D01F08 { get; set; } // Brand

        /// <summary>
        /// Gets or sets the Date when product remove.
        /// </summary>
        public DateTime? D01F09 { get; set; } //DateRemoved

        /// <summary>
        /// Gets or sets the product count
        /// </summary>
        public int D01F10 { get; set; } //Count
    }
}