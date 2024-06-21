using FinalDemo_Advance_C_.Enums;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;


namespace FinalDemo_Advance_C_.Models.DTO
{
    /// <summary>
    /// Represents a transaction entity with properties for TransactionID, ProductID, ProductName, TransactionType, TransactionDate, Quantity, and TotalAmount.
    /// </summary>
    public class DtoTRA01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the TransactionID.
        /// </summary>
        [JsonProperty("A01101")]
        [Required]
        public int A01F01 { get; set; }

        /// <summary>
        /// Gets or sets the ProductID.
        /// </summary>
        [JsonProperty("A01102")]
        [Required (ErrorMessage = " Product ID is required.") ]
        public int A01F02 { get; set; }

        /// <summary>
        /// Gets or sets the StockId.
        /// </summary>
        [JsonProperty("A01103")]
        [Required(ErrorMessage = " StockId is required.")]
        public int A01F03 { get; set; }

        /// <summary>
        /// Gets or sets the TransactionDate.
        /// </summary>
        [JsonProperty("A01104")]
        [Required (ErrorMessage = "Transaction Date is required.")]
        public DateTime A01F04 { get; set; } = DateTime.Now;

        /// <summary>
        /// represent transaction type (Purchase or Sale).
        /// </summary>
        [JsonProperty("A01105")]
        [Required (ErrorMessage = "Enter Transaction type.")]
        public enmTransactionType A01F05 { get; set; }

        /// <summary>
        /// Gets or sets the ContactId.
        /// </summary>
        [JsonProperty("A01106")]
        [Required(ErrorMessage = "Enter Contact Id.")]
        public int A01F06 { get; set; }

        /// <summary>
        /// Gets or sets the Quantity.
        /// </summary>
        [JsonProperty("A01107")]
        [Required(ErrorMessage = "Quantity is required.")]
        public int A01F07 { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        [JsonProperty("A01109")]
        [Required, StringLength(250)]
        public string A01F09 { get; set; }

        #endregion
    }
}