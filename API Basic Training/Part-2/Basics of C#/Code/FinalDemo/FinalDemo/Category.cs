using System;
using System.Collections.Generic;


namespace FinalDemo
{
    /// <summary>
    /// Represents a category in the inventory.
    /// </summary>
    public class Category
    {
        #region Public Properties 
        // Properties with private setters for encapsulation
        public int CategoryId { get; private set; }
        public string CategoryName { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="categoryId">The unique identifier for the category.</param>
        /// <param name="categoryName">The name of the category.</param>
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
        #endregion

        #region Public Methods

        #region SetCategoryName
        /// <summary>
        /// Sets a new name for the category.
        /// </summary>
        /// <param name="newCategoryName">The new name for the category.</param>
        public void SetCategoryName(string newCategoryName)
        {
            // Basic validation: ensure the new category name is not empty
            if (!string.IsNullOrWhiteSpace(newCategoryName))
            {
                CategoryName = newCategoryName;
            }
            else
            {
                Console.WriteLine("Invalid category name. Please provide a non-empty name.");
            }
        }
        #endregion

        #region Validate
        /// <summary>
        /// Validates the category's properties against existing categories.
        /// </summary>
        /// <param name="existingCategories">The list of existing categories for validation.</param>
        public void Validate(List<Category> existingCategories)
        {
            // Validate the uniqueness of Category ID
            if (!ValidationHelper.IsCategoryIdValid(CategoryId, existingCategories))
            {
                throw new ArgumentException("Invalid or duplicate Category ID.");
            }

            // Validate the Category Name
            if (!ValidationHelper.IsCategoryNameValid(CategoryName))
            {
                throw new ArgumentException("Invalid Category Name. Please provide a non-empty string.");
            }
        }
        #endregion

        #endregion
    }

}
