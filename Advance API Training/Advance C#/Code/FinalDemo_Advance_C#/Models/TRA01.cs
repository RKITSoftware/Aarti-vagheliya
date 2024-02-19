using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FinalDemo_Advance_C_.Models
{
    // Define enum for transaction types
    public enum TransactionType
    {
        //[EnumMember(Value = "Purchase")]
        //Purchase,

        //[EnumMember(Value = "Sale")]
        //Sale

        Purchase = 0,
        Sale = 1,
    }
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
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the TransactionType (e.g., Purchase, Sale).
        /// </summary>
        public TransactionType A01F03 { get; set; }
      //  public TransactionType TransactionType { get; set; }

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

        public override string ToString()
        {
            return A01F03.ToString();
        }

        // Method to convert integer to enum
        public static TransactionType ConvertToTransactionType(int value)
        {
            return (TransactionType)value;
        }
        
    }
}