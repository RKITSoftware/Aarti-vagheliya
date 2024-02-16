using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    [RoutePrefix("api/CLCategory")]
    public class CLCategoryController : ApiController
    {
        private BLCategory _objBLCategory;

        [HttpGet]
        [Route("GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            _objBLCategory = new BLCategory();
            List<CAT01> categories = _objBLCategory.GetAllCategories();
            if (categories != null)
                return Ok(categories);
            else
                return InternalServerError();
        }

        [HttpPost]
        [Route("AddCategory")]
        public IHttpActionResult AddCategory(CAT01 Category)
        {
            _objBLCategory = new BLCategory();
            
            if (_objBLCategory.AddCategory(Category))
                return Ok("Category added successfully.");
            else
                return InternalServerError();
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public IHttpActionResult UpdateCategory(int categoryId, CAT01 Category)
        {
            _objBLCategory = new BLCategory();

            if (_objBLCategory.UpdateCategory(categoryId, Category))
                return Ok("Category updated successfully.");
            else
                return InternalServerError();
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public IHttpActionResult DeleteCategory(int categoryId)
        {
            _objBLCategory = new BLCategory();
            if (_objBLCategory.DeleteCategory(categoryId))
                return Ok("Category deleted successfully.");
            else
                return NotFound();
        }
    }
}
