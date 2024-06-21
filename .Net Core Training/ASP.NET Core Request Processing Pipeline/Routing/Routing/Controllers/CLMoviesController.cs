using Microsoft.AspNetCore.Mvc;
using Routing.BusinessLogic;
using Routing.Model;

namespace Routing.Controllers
{
    /// <summary>
    /// Controller for managing movie data through API endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLMoviesController : ControllerBase
    {
        #region Private member

        /// <summary>
        /// Create instance of BLMovie class.
        /// </summary>
        private BLMovie _objBLMovie = new BLMovie();

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves the list of movies.
        /// </summary>
        /// <returns>The list of movies.</returns>
        [HttpGet("GetList")]
        public IActionResult GetMovies()
        {
            return Ok(_objBLMovie.GetMovies());
        }

        // Not work
        //[HttpGet("GetList")]
        //public IActionResult Get()
        //{
        //    return Ok("Hello");
        //}

        /// <summary>
        /// Retrieves a single movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>The movie with the specified ID if found, otherwise returns NotFound.</returns>
        [HttpGet("GetById/{id:int}")]
        public IActionResult GetOneMovie(int id)
        {
            var movie = _objBLMovie.GetById(id);
            if (movie != null)
                return Ok(movie);
            else
                return NotFound();
        }

        /// <summary>
        /// Adds details of a new movie.
        /// </summary>
        /// <param name="objMovie">The movie details to add.</param>
        /// <returns>The added movie details if successful, otherwise returns NoContent.</returns>
        [HttpPost("AddDetails")]
        public IActionResult AddDetails(MOV01 objMovie)
        {
            if (objMovie != null)
            {
                _objBLMovie.Post(objMovie);
                return Ok(objMovie);
            }
            else
                return NoContent();
        }

        /// <summary>
        /// Updates details of an existing movie.
        /// </summary>
        /// <param name="objMovie">The updated movie details.</param>
        /// <returns>The updated movie details if successful, otherwise returns NotFound.</returns>
        [HttpPut("UpdateDetails")]
        public IActionResult UpdateDetails(MOV01 objMovie)
        {
            if (objMovie != null)
            {
                _objBLMovie.Update(objMovie);
                return Ok(objMovie);
            }
            else
                return NotFound();
        }

        /// <summary>
        /// Deletes a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>Ok if the movie was successfully deleted, otherwise returns NotFound.</returns>
        [HttpDelete("DeleteMovie")]
        public IActionResult Delete(int id)
        {
            if (_objBLMovie.Delete(id))
                return Ok();
            else
                return NotFound();
        }

        #endregion
    }
}
