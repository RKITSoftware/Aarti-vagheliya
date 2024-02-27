using System.Collections.Generic;
using System.Linq;


namespace FinalDemo
{
    /// <summary>
    /// Provides helper methods for validating product and category properties.
    /// </summary>
    public static class ValidationHelper
    {
        #region IsProductIdValid
        /// <summary>
        /// Checks if the product ID is valid (greater than 0 and unique).
        /// </summary>
        /// <param name="productId">The product ID to validate.</param>
        /// <param name="existingProducts">The list of existing products for validation.</param>
        /// <returns>True if the product ID is valid; otherwise, false.</returns>
        public static bool IsProductIdValid(int productId, List<Product> existingProducts)
        {
            // Check if the product ID is greater than 0
            if (productId < 0)
            {
                return false;
            }

            // Check if the product ID is unique (not already used by another product)
            return !existingProducts.Any(p => p.ProductId == productId);
        }
        #endregion
        
        #region IsProductNameValid
        /// <summary>
        /// Checks if the product name is valid (non-empty and not null or whitespace).
        /// </summary>
        /// <param name="productName">The product name to validate.</param>
        /// <returns>True if the product name is valid; otherwise, false.</returns>
        public static bool IsProductNameValid(string productName)
        {
           return !string.IsNullOrWhiteSpace(productName);
            
        }
        #endregion

        #region IsPriceValid
        /// <summary>
        /// Checks if the price is valid (non-negative).
        /// </summary>
        /// <param name="price">The price to validate.</param>
        /// <returns>True if the price is valid; otherwise, false.</returns>
        public static bool IsPriceValid(decimal price)
        {
            return price > 0;
        }
        #endregion

        #region IsQuantityInStockValid
        /// <summary>
        /// Checks if the quantity in stock is valid (non-negative).
        /// </summary>
        /// <param name="quantityInStock">The quantity in stock to validate.</param>
        /// <returns>True if the quantity in stock is valid; otherwise, false.</returns>
        public static bool IsQuantityInStockValid(int quantityInStock)
        {
            return quantityInStock > 0;
        }
        #endregion

        #region IsCategoryIdValid
        /// <summary>
        /// Checks if the category ID is valid (greater than 0 and unique).
        /// </summary>
        /// <param name="categoryId">The category ID to validate.</param>
        /// <param name="existingCategories">The list of existing categories for validation.</param>
        /// <returns>True if the category ID is valid; otherwise, false.</returns>
        public static bool IsCategoryIdValid(int categoryId, List<Category> existingCategories)
        {
            // Check if the category ID is greater than 0
            if (categoryId < 0)
            {
                return false;
            }

            // Check if the category ID is unique (not already used by another category)
            return !existingCategories.Any(c => c.CategoryId == categoryId);
        }
        #endregion

        #region IsCategoryNameValid
        /// <summary>
        /// Checks if the category name is valid (non-empty and not null or whitespace).
        /// </summary>
        /// <param name="categoryName">The category name to validate.</param>
        /// <returns>True if the category name is valid; otherwise, false.</returns>
        public static bool IsCategoryNameValid(string categoryName)
        {
            return !string.IsNullOrWhiteSpace(categoryName);
        }
        #endregion
    }

}

