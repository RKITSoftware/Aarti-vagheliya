using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Represents a controller for managing categories.
    /// </summary>
    [RoutePrefix("api/CLCategory")]
    public class CLCategoryController : ApiController
    {
        #region Private member

        // Instance of the category business logic class
        private BLCategory _objBLCategory;

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>The list of categories.</returns>
        [HttpGet]
        [Route("GetAllCategories")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Customer,Seller,Admin,Supplier"))]
        public IHttpActionResult GetAllCategories()
        {
            // Instantiates the category business logic class
            _objBLCategory = new BLCategory();

            // Retrieves all categories from the database
            List<CAT01> categories = _objBLCategory.GetAllCategories();
            if (categories != null)
                // Returns the list of categories
                return Ok(categories);
            else
                // Returns an internal server error response
                return InternalServerError();
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="Category">The category to add.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPost]
        [Route("AddCategory")]
        [BearerAuthentication]
        [Authorize(Roles = ("Seller,Admin"))]
        public IHttpActionResult AddCategory(CAT01 Category)
        {
            _objBLCategory = new BLCategory();

            // Attempts to add the category
            if (_objBLCategory.AddCategory(Category))
                return Ok("Category added successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to update.</param>
        /// <param name="Category">The updated category data.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateCategory")]
        [BearerAuthentication]
        [Authorize(Roles = ("Seller,Admin"))]
        public IHttpActionResult UpdateCategory(int categoryId, CAT01 Category)
        {
            // Instantiates the category business logic class
            _objBLCategory = new BLCategory();

            // Attempts to update the category
            if (_objBLCategory.UpdateCategory(categoryId, Category))
                return Ok("Category updated successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Deletes a category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to delete.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteCategory")]
        [BearerAuthentication]
        [Authorize(Roles = ("Seller,Admin"))]
        public IHttpActionResult DeleteCategory(int categoryId)
        {
            _objBLCategory = new BLCategory();
            if (_objBLCategory.DeleteCategory(categoryId))
                return Ok("Category deleted successfully.");
            else
                // Returns a not found response
                return NotFound();
        }

        #endregion
    }
}
