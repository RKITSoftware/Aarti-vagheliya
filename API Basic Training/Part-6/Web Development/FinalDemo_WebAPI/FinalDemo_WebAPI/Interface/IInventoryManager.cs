using System.Data;

namespace FinalDemo_WebAPI.Interface
{
    /// <summary>
    /// Interface for managing inventory-related operations.
    /// </summary>
    public interface IInventoryManager
    {
        /// <summary>
        /// Sell a specified quantity of a product and update the stock accordingly.
        /// </summary>
        /// <param name="productId">The ID of the product to be sold.</param>
        /// <param name="quantity">The quantity to be sold.</param>
        /// <returns>True if the product is sold successfully; otherwise, false.</returns>
        bool SellProduct(int productId, int quantity);

        /// <summary>
        /// Manage the stock of a product by increasing or decreasing the quantity.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="quantity">The quantity to be added (positive) or deducted (negative).</param>
        /// <returns>True if the stock is managed successfully; otherwise, false.</returns>
        bool AddStock(int productId, int quantity);

        /// <summary>
        /// Display the current stock of all products.
        /// </summary>
        /// <returns>A DataTable representing the current stock of all products.</returns>
        DataTable DisplayAllStock();

        /// <summary>
        /// Display the stock of products belonging to a specific category.
        /// </summary>
        /// <param name="categoryId">The ID of the category.</param>
        /// <returns>A DataTable representing the stock of products in the specified category.</returns>
        DataTable DisplayStockByCategory(int categoryId);
    }
}
