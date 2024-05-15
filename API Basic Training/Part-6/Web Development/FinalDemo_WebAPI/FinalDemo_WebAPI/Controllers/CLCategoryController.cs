using FinalDemo_WebAPI.BL;
using FinalDemo_WebAPI.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalDemo_WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing categories.
    /// </summary>
    [EnableCorsAttribute("*","*","*")]
    [RoutePrefix("api/CLCategory")]
    public class CLCategoryController : ApiController
    {
        #region Private Member

        /// <summary>
        /// private instance of BLCategory class.
        /// </summary>
        private BLCategory _objBLCategory = new BLCategory();

        #endregion

        #region Public Methods 

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>An IHttpActionResult containing the response with all categories.</returns>
        [HttpGet]
        [Route("GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            return Ok(_objBLCategory.GetAllCategories());
        }

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to retrieve.</param>
        /// <returns>An IHttpActionResult containing the response with the category if found.</returns>
        [HttpGet]
        [Route("GetCategoryById/{categoryId}")]
        public IHttpActionResult GetCategoryById(int categoryId)
        {
           return Ok( _objBLCategory.GetCategoryById(categoryId));
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The Category object to add.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the category addition.</returns>
        [HttpPost]
        [Route("AddCategory")]
        public IHttpActionResult AddCategory(Category category)
        {
            Response response = _objBLCategory.Validation(category);
            if (!response.isError)
            {
                response = _objBLCategory.AddCategory(category);
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to update.</param>
        /// <param name="updatedCategory">The updated Category object.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the category update.</returns>
        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        public IHttpActionResult UpdateCategory(int categoryId, Category updatedCategory)
        {
            Response response = _objBLCategory.Validation(updatedCategory);
            if (!response.isError)
            {
                response = _objBLCategory.UpdateCategory(categoryId, updatedCategory);
            }
            return Ok(response);

        }

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to delete.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the category deletion.</returns>
        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public IHttpActionResult DeleteCategory(int categoryId)
        {
            return Ok(_objBLCategory.DeleteCategory(categoryId));
        }

        #endregion
    }
}
