using FinalDemo_WebAPI.DAL;
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
        #region GetAllCategories

        /// <summary>
        /// Gets all categories.
        /// </summary>
        [HttpGet]
        [Route("GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            return Ok(BLCategory.GetAllCategories());
        }

        #endregion

        #region GetCategoryById

        /// <summary>
        /// Gets a category by its ID.
        /// </summary>
        [HttpGet]
        [Route("GetCategoryById/{categoryId}")]
        public IHttpActionResult GetCategoryById(int categoryId)
        {
            var category = BLCategory.GetCategoryById(categoryId);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region AddCategory

        /// <summary>
        /// Adds a new category.
        /// </summary>
        [HttpPost]
        [Route("AddCategory")]
        public IHttpActionResult AddCategory(Category category)
        {
            var addedCategory = BLCategory.AddCategory(category);
            return Created(Request.RequestUri + "/" + addedCategory.CategoryId, addedCategory);
        }

        #endregion

        #region UpdateCategory

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        [HttpPut]
        [Route("UpdateCategory/{categoryId}")]
        public IHttpActionResult UpdateCategory(int categoryId, Category updatedCategory)
        {
            var category = BLCategory.UpdateCategory(categoryId, updatedCategory);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region DeleteCategory

        /// <summary>
        /// Deletes a category by its ID.
        /// </summary>
        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public IHttpActionResult DeleteCategory(int categoryId)
        {
            var category = BLCategory.DeleteCategory(categoryId);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion   
    }
}
