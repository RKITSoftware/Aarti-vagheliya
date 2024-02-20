using System;

namespace FinalDemo_Advance_C_.Models
{
    /// <summary>
    /// Represents the types of transactions.
    /// </summary>
    public enum TransactionType
    {
        //[EnumMember(Value = "Purchase")]
        //Purchase,

        //[EnumMember(Value = "Sale")]
        //Sale

        /// <summary>
        /// Indicates a purchase transaction.
        /// </summary>
        Purchase = 0,

        /// <summary>
        /// Indicates a sale transaction.
        /// </summary>
        Sale = 1,
    }

    /// <summary>
    /// Represents a transaction entity with properties for TransactionID, ProductID, ProductName, TransactionType, TransactionDate, Quantity, and TotalAmount.
    /// </summary>
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
        /// Gets or sets the ProductName.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the TransactionType.
        /// </summary>
        public TransactionType A01F03 { get; set; }

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