using FinalDemo_WebAPI.Models;

namespace FinalDemo_WebAPI.Interface
{
    /// <summary>
    /// Interface for managing inventory-related operations.
    /// </summary>
    public interface IInventoryManager
    {
        /// <summary>
        /// Sells a specified quantity of a product.
        /// </summary>
        /// <param name="productId">The ID of the product to sell.</param>
        /// <param name="quantity">The quantity of the product to sell.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        Response SellProduct(int productId, int quantity);

        /// <summary>
        /// Adds a specified quantity of stock for a product.
        /// </summary>
        /// <param name="productId">The ID of the product to add stock for.</param>
        /// <param name="quantity">The quantity of stock to add.</param>
        /// <returns>A response indicating the success or failure of the operation.</returns>
        Response AddStock(int productId, int quantity);

        /// <summary>
        /// Displays information about all products in stock.
        /// </summary>
        /// <returns>A response containing information about all products in stock.</returns>
        Response DisplayAllStock();

        /// <summary>
        /// Displays information about products in stock filtered by category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter by.</param>
        /// <returns>A response containing information about products in stock filtered by category.</returns>
        Response DisplayStockByCategory(int categoryId);
    }
}
