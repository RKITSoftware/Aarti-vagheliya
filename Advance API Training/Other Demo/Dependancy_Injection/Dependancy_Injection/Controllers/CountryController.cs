using Dependancy_Injection.Model;
using Dependancy_Injection.Service;
using Microsoft.AspNetCore.Mvc;

namespace Dependancy_Injection.Controllers
{
    /// <summary>
    /// Controller for managing countries.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Private Member

        // Private field for country service dependency
        private readonly ICountryService countryService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryController"/> class.
        /// </summary>
        /// <param name="_countryService">The country service dependency.</param>
        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService ?? throw new ArgumentNullException(nameof(_countryService));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all countries.
        /// </summary>
        [HttpGet]
        public IActionResult GetCountries()
        {
            try
            {
                // Retrieve countries from service
                var countries = countryService.GetCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving countries: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new country.
        /// </summary>
        [HttpPost]
        public IActionResult AddCountry([FromBody] Country country)
        {
            try
            {
                // Check if country object is null
                if (country == null)
                    return BadRequest("Country object is null");

                // Add country through service
                var addedCountry = countryService.AddCountry(country);

                // Return created at action response
                return CreatedAtAction(nameof(GetCountry), new { id = addedCountry.t01f01 }, addedCountry);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while adding the country: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing country.
        /// </summary>
        /// <param name="country">The updated country object.</param>
        [HttpPut]
        public IActionResult UpdateCountry([FromBody] Country country)
        {
            try
            {
                // Check if country object is null
                if (country == null)
                    return BadRequest("Country object is null");

                // Update country through service
                countryService.UpdateCountry(country);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while updating the country: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a country by ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            try
            {
                // Get existing country from service
                var existingCountry = countryService.GetCountry(id);
                if (existingCountry == null)
                    return NotFound($"Country not found with ID : {id}");

                // Delete country through service
                countryService.DeleteCountry(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting the country: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a country by ID.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve.</param>
        [HttpGet("{id}")]
        public IActionResult GetCountry(int id)
        {
            try
            {
                // Get country by ID from service
                var country = countryService.GetCountry(id);
                if (country == null)
                    return NotFound($"Country not found with ID : {id}");

                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving the country: {ex.Message}");
            }
        }

        #endregion
    }
}
