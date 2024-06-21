using FiltersApi.BusinessLogic;
using FiltersApi.Filters;
using FiltersApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FiltersApi.Controllers
{
    /// <summary>
    /// Controller class for managing countries.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuthenticationFilter]  // Apply basic authentication filter
    [ServiceFilter(typeof(ResourceFilter))] // Apply resource filter
    [ResultFilter("X-Custom-Header", "MyCustomValue")] // Apply result filter

    public class CLCountryController : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Create instance of BLCountry class
        /// </summary>
        private readonly BLCountry _objBLCountry;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for CLCountryController.
        /// </summary>
        public CLCountryController()
        {
            _objBLCountry = new BLCountry();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all countries.
        /// </summary>
        /// <returns>A list of all countries.</returns>
        [HttpGet]
        [Route("GetAllCountries")]  
        public IActionResult GetAllCountries()
        {
            //throw new Exception("Error occured.");
            return Ok(_objBLCountry.GetCountries());
        }

        /// <summary>
        /// Retrieves a single country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve.</param>
        /// <returns>The country object if found; otherwise, a 404 Not Found response.</returns>
        [HttpGet]
        [Route("GetOneCountry/{id}")]
        public IActionResult GetOneCountry(int id)
        {
            var country = _objBLCountry.GetOneCountry(id);
            if (country != null)
                return Ok(country);
            else
                return NotFound();
        }

        /// <summary>
        /// Adds a new country.
        /// </summary>
        /// <param name="objCountry">The country object to add.</param>
        /// <returns>The added country object if successful; otherwise, a 400 Bad Request response.</returns>
        [HttpPost]
        [Route("AddNewCountry")]
        [ServiceFilter(typeof(ActionFilter))] // Apply the ActionFilter as a service filter
        public IActionResult AddCountry( CNT01 objCountry)
        {
            if (_objBLCountry.Validation(objCountry))
            {
                _objBLCountry.AddCountry(objCountry);
                return Ok(objCountry);
            }
            else
                return BadRequest("Invalid data.");
        }

        /// <summary>
        /// Updates a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to update.</param>
        /// <param name="objCountry">The updated country object.</param>
        /// <returns>The updated country object if successful; otherwise, a 204 No Content response.</returns>
        [HttpPut]
        [Route("UpdateCountry")]
        public IActionResult UpdateCountry(int id, CNT01 objCountry)
        {
            if (_objBLCountry.Validation(objCountry))
            {
                _objBLCountry.UpdateCountry(id, objCountry);
                return Ok(objCountry);
            }
            else
                return NoContent();
        }

        /// <summary>
        /// Deletes a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        /// <returns>A 200 OK response if successful; otherwise, a 404 Not Found response.</returns>
        [HttpDelete]
        [Route("DeleteCountry")]
        public IActionResult DeleteCoutry(int id)
        {
            if (_objBLCountry.DeleteCountry(id))
                return Ok();
            else
                return NotFound();
        }

        #endregion
    }
}
