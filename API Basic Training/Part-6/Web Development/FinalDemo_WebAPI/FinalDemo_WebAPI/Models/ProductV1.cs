

namespace FinalDemo_WebAPI.Models
{
    /// <summary>
    /// Represents version 1 of the Product entity.
    /// </summary>
    public class ProductV1
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the unique identifier of the product.
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
        /// Gets or sets the count of the product.
        /// </summary>
        public int ProductCount { get; set; }

        #endregion
    }
}