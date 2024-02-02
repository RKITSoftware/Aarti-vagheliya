using System;

namespace FinalDemo_WebAPI.Models
{
    /// <summary>
    /// Represents a version 2 (V2) of a product in the system.
    /// </summary>
    public class ProductV2
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the available quantity of the product in stock.
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the product.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing date of the product.
        /// </summary>
        public DateTime ManufacturingDate { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the category to which the product belongs.
        /// </summary>
        public int CategoryId { get; set; }

        #endregion

    }
}