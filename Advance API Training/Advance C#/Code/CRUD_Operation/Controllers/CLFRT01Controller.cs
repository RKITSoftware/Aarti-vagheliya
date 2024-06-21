using CRUD_Operation.BL;
using CRUD_Operation.Models.DTO;
using System.Web.Http;

namespace CRUD_Operation.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations related to fruits.
    /// </summary>
    [RoutePrefix("api/Fruit")]
    public class CLFRT01Controller : ApiController
    {
        #region Private Member

        /// <summary>
        /// Private instance of BLFRT01 class.
        /// </summary>
        private BLFRT01 _objBLFRT01 = new BLFRT01();

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all fruit records.
        /// </summary>
        /// <returns>Returns a list of all fruit records.</returns>
        [HttpGet]
        [Route("Read")]
        public IHttpActionResult Read()
        {
            return Ok(_objBLFRT01.Select());
        }

        /// <summary>
        /// Creates a new fruit record.
        /// </summary>
        /// <param name="fruit">The fruit DTO containing the new fruit data.</param>
        /// <returns>Returns the result of the create operation.</returns>
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(DtoFRT01 fruit)
        {
            _objBLFRT01.PreSave(fruit);
            if (_objBLFRT01.Validation().isError == false)
            {
                return Ok(_objBLFRT01.Insert());
            }
            return Ok(_objBLFRT01.Validation());
        }

        /// <summary>
        /// Updates an existing fruit record.
        /// </summary>
        /// <param name="id">The ID of the fruit record to update.</param>
        /// <param name="fruit">The fruit DTO containing the updated fruit data.</param>
        /// <returns>Returns the result of the update operation.</returns>
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update( DtoFRT01 fruit)
        {
            _objBLFRT01.PreSave(fruit);
            if (_objBLFRT01.Validation().isError == false)
            {
                return Ok(_objBLFRT01.Update());
            }
            return Ok(_objBLFRT01.Validation());
        }

        /// <summary>
        /// Deletes a fruit record by ID.
        /// </summary>
        /// <param name="id">The ID of the fruit record to delete.</param>
        /// <returns>Returns the result of the delete operation.</returns>
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_objBLFRT01.Delete(id));
        }

        #endregion
    }
}
