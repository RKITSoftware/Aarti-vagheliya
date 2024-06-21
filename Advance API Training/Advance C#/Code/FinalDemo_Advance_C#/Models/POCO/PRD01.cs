namespace FinalDemo_Advance_C_.Models.POCO
{
    /// <summary>
    /// Represents a product entity with properties for ProductID, ProductName, CategoryID, UnitPrice, SupplierID, Description, DateAdded, Brand, DateRemoved, and Count.
    /// </summary>
    public class PRD01
    {
        #region Public Properties

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
        public int D01F03 { get; set; } // CategoryID

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string D01F04 { get; set; } // Description

        /// <summary>
        /// Gets or sets the UnitPrice.
        /// </summary>
        public decimal D01F05 { get; set; } // PURCHASE_PRICE

        /// <summary>
        /// Gets or sets the Selling Price.
        /// </summary>
        public decimal D01F06 { get; set; } // SELLING_PRICE

        #endregion
    }
}