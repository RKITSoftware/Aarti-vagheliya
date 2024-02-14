using CRUD_Operation.BL;
using CRUD_Operation.Models;
using System.Web.Http;

namespace CRUD_Operation.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations related to fruits.
    /// </summary>
    [RoutePrefix("api/Fruit")]
    public class CLFruitController : ApiController
    {
        BLFruit objBLFruit = new BLFruit();

        #region CreateTable

        /// <summary>
        /// Creates the table in the database for storing fruits.
        /// </summary>
        [HttpPost]
        [Route("CreateTable")]
        public IHttpActionResult CreateTable()
        {
            if (objBLFruit.CreateTable())
                return Ok("Table created successfully.");
            else
                return BadRequest("Failed to create table.");
        }

        #endregion

        #region Create

        /// <summary>
        /// Adds a new fruit to the database.
        /// </summary>
        /// <param name="fruit">The fruit object to be added.</param>

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(FRT01 fruit)
        {
            if (objBLFruit.AddFruit(fruit))
                return Ok("Fruit added successfully.");
            else
                return BadRequest("Failed to add Fruit.");
        }

        #endregion

        #region Read

        /// <summary>
        /// Retrieves all fruits from the database.
        /// </summary>

        [HttpGet]
        [Route("Read")]
        public IHttpActionResult Read()
        {
            var fruits = objBLFruit.GetAllFruits();
            return Ok(fruits);
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates the price of a fruit in the database.
        /// </summary>
        /// <param name="id">The ID of the fruit to be updated.</param>
        /// <param name="fruit">The updated fruit object.</param>

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(int id, FRT01 fruit)
        {
            if (objBLFruit.UpdateFruit(id, fruit))
                return Ok("Fruit price updated successfully.");
            else
                return BadRequest("Failed to update fruit price.");
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deletes a fruit from the database.
        /// </summary>
        /// <param name="id">The ID of the fruit to be deleted.</param>
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            if (objBLFruit.DeleteFruit(id))
                return Ok("Fruit deleted successfully.");
            else
                return BadRequest("Failed to delete fruit.");
        }

        #endregion
    }
}
