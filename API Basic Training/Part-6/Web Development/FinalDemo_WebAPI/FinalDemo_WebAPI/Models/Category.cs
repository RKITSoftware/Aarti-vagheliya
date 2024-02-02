namespace FinalDemo_WebAPI.Models
{
    /// <summary>
    /// Represents a category for products.
    /// </summary>
    public class Category
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the unique identifier of the category.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the description of the category.
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}