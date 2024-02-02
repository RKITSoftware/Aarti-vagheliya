using FinalDemo_WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalDemo_WebAPI.DAL
{
    /// <summary>
    /// Business Logic class for managing categories.
    /// </summary>
    public class BLCategory
    {
        #region Private Member

        // Static variable to maintain a unique identifier for categories
        private static int  _categoryId = 0;

        #endregion

        #region Public member

        // Static list to store categories
        public static List<Category> _categories = new List<Category>
        {
            new Category { CategoryId = GenerateId(), CategoryName = "Category1", Description = "Description1" },
            new Category { CategoryId = GenerateId(), CategoryName = "Category2", Description = "Description2" },
            new Category { CategoryId = GenerateId(), CategoryName = "Category3", Description = "Description3" },
            new Category { CategoryId = GenerateId(), CategoryName = "Category4", Description = "Description4" },
            new Category { CategoryId = GenerateId(), CategoryName = "Category5", Description = "Description5" },
        };

        #endregion

        #region Public methods

        #region GetAllCategories

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>An IEnumerable of Category.</returns>
        public static IEnumerable<Category> GetAllCategories()
        {
            return _categories;
        }

        #endregion

        #region GetCategoryById

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to retrieve.</param>
        /// <returns>A Category object if found, otherwise null.</returns>
        public static Category GetCategoryById(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        #endregion

        #region AddCategory

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The Category object to add.</param>
        /// <returns>The added Category object.</returns>
        public static Category AddCategory(Category category)
        {
            category.CategoryId = GenerateId();
            _categories.Add(category);
            return category;
        }

        #endregion

        #region UpdateCategory

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to update.</param>
        /// <param name="updatedCategory">The updated Category object.</param>
        /// <returns>The updated Category object if successful, otherwise null.</returns>
        public static Category UpdateCategory(int categoryId, Category updatedCategory)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = updatedCategory.CategoryName;
                existingCategory.Description = updatedCategory.Description;
                return existingCategory;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region DeleteCategory

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to delete.</param>
        /// <returns>The deleted Category object if successful, otherwise null.</returns>
        public static Category DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
                return category;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #endregion

        #region Private method

        #region GenerateId

        /// <summary>
        /// Generates a unique ID for categories.
        /// </summary>
        /// <returns>The generated unique ID.</returns>
        private static int GenerateId()
        {
            return ++_categoryId;
        }

        #endregion

        #endregion

    }
}