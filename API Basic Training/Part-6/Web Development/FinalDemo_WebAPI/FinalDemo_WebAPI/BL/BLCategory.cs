using FinalDemo_WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalDemo_WebAPI.BL
{
    /// <summary>
    /// Business Logic class for managing categories.
    /// </summary>
    public class BLCategory
    {
        #region Private Member

        // Private instance of Response class.
        private Response _objResponse;

        //Private instance of BLHelper
        private BLHelper _objBLHelper = new BLHelper();

        #endregion

        #region Public member

        // Static list to store categories
        public static List<Category> lstCategories = new List<Category>();

        #endregion

        #region Constructor

        // Static constructor to initialize the list
        static BLCategory()
        {
            lstCategories.Add( new Category { Id = BLHelper.GenerateId(lstCategories), CategoryName = "Category1", Description = "Description1" });
            lstCategories.Add( new Category { Id = BLHelper.GenerateId(lstCategories), CategoryName = "Category2", Description = "Description2" });
            lstCategories.Add( new Category { Id = BLHelper.GenerateId(lstCategories), CategoryName = "Category3", Description = "Description3" });
            lstCategories.Add( new Category { Id = BLHelper.GenerateId(lstCategories), CategoryName = "Category4", Description = "Description4" });
            lstCategories.Add( new Category { Id = BLHelper.GenerateId(lstCategories), CategoryName = "Category5", Description = "Description5" });
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>An IEnumerable of Category.</returns>
        public Response GetAllCategories()
        {
            _objResponse = new Response();

            if (lstCategories.Count > 0)
            {
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ToDataTable(lstCategories);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to retrieve.</param>
        /// <returns>A Response object containing the category if found, otherwise an error message.</returns>
        public Response GetCategoryById(int categoryId)
        {
            _objResponse = new Response();

            Category category = lstCategories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ObjectToDataTable(category);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The Category object to add.</param>
        /// <returns>A Response object containing the added category if successful, otherwise an error message.</returns>
        public Response AddCategory(Category category)
        {
            _objResponse = new Response();

            if (category != null)
            {
                category.Id = BLHelper.GenerateId(lstCategories);
                lstCategories.Add(category);
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ObjectToDataTable(category);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to update.</param>
        /// <param name="updatedCategory">The updated Category object.</param>
        /// <returns>A Response object containing the updated category if successful, otherwise an error message.</returns>
        public Response UpdateCategory(int categoryId, Category updatedCategory)
        {
            _objResponse = new Response();

            Category existingCategory = lstCategories.FirstOrDefault(c => c.Id == categoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = updatedCategory.CategoryName;
                existingCategory.Description = updatedCategory.Description;
                _objResponse.Message = "Category updated successfully.";
                _objResponse.response = _objBLHelper.ObjectToDataTable(existingCategory);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Category not found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to delete.</param>
        /// <returns>A Response object indicating the result of the operation.</returns>
        public Response DeleteCategory(int categoryId)
        {
            _objResponse = new Response();

            int index = lstCategories.FindIndex(c => c.Id == categoryId);

            if (index != -1)
            {
                Category category = lstCategories[index];
                lstCategories.RemoveAt(index);
                _objResponse.Message = "Category deleted successfully.";
                _objResponse.response = _objBLHelper.ObjectToDataTable(category);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Category not found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Validation of Category class perform.
        /// </summary>
        /// <param name="objCategory">object on which validation perform.</param>
        /// <returns>if object validated then returns true, else false.</returns>
        public Response Validation(Category objCategory)
        {
            _objResponse = new Response();

            if (!string.IsNullOrEmpty(objCategory.CategoryName) && !string.IsNullOrEmpty(objCategory.Description))
            {
                _objResponse.Message = "Validation successful.";
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "CategoryName and Description cannot be null or empty.";
            }
            return _objResponse;
        }

        #endregion

    }
}