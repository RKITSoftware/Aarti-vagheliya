using System;

namespace FinalDemo_Advance_C_.Models
{
    #region Enum TransactionType

    /// <summary>
    /// Represents the types of transactions.
    /// </summary>
    public enum enmTransactionType
    {
        /// <summary>
        /// Indicates a purchase transaction.
        /// </summary>
        Purchase = 0,

        /// <summary>
        /// Indicates a sale transaction.
        /// </summary>
        Sale = 1,
    }

    #endregion

    /// <summary>
    /// Represents a transaction entity with properties for TransactionID, ProductID, ProductName, TransactionType, TransactionDate, Quantity, and TotalAmount.
    /// </summary>
    public class TRA01
    {
        #region Public Properties

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
        //public string ProductName { get; set; }

        public int A01F03  { get; set; } //StockId

        /// <summary>
        /// Gets or sets the TransactionDate.
        /// </summary>
        public DateTime A01F04 { get; set; }
       

        /// <summary>
        /// Gets or sets the TransactionType.
        /// </summary>
        public enmTransactionType A01F05 { get; set; }

        public int A01F06 { get; set; } // ContactId

      
        public int A01F07 { get; set; } //Quantity

       // public decimal UnitPrice { get; set; }

        public decimal A01F08 { get; set; } // netPirce 
        public string A01F09 { get; set; }// Description

        #endregion
    }
}