using Routing.Model;

namespace Routing.BusinessLogic
{
    /// <summary>
    /// Business logic class for managing movies.
    /// </summary>
    public class BLMovie
    {
        #region Private Member

        /// <summary>
        /// Static variable for  unique id.
        /// </summary>
        private static int _count = 0;

        /// <summary>
        /// static list to store data.
        /// </summary>
        private static List<MOV01> _movie = new List<MOV01>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves a list of all movies.
        /// </summary>
        /// <returns>A list of movies.</returns>
        public List<MOV01> GetMovies()
        {
            return _movie.ToList();
        }

        /// <summary>
        /// Retrieves a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns>The movie with the specified ID, or null if not found.</returns>
        public MOV01 GetById(int id)
        {
            var movie = _movie.FirstOrDefault(x => x.ID == id);

            return movie != null ? movie : null;
        }

        /// <summary>
        /// Adds a new movie.
        /// </summary>
        /// <param name="objMOV01">The movie to add.</param>
        /// <returns>True if the movie was added successfully, otherwise false.</returns>
        public bool Post(MOV01 objMOV01)
        {
            if (objMOV01 != null)
            {
                objMOV01.ID = Generator();
                _movie.Add(objMOV01);
                return true;
            }
            else
                return false;
          
        }

        /// <summary>
        /// Deletes a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie to delete.</param>
        /// <returns>True if the movie was deleted successfully, otherwise false.</returns>
        public bool Delete(int id)
        {
            int index = _movie.FindIndex(x => x.ID == id);
            if (index != -1)
            {
                _movie.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Updates a movie.
        /// </summary>
        /// <param name="objMOV01">The updated movie.</param>
        /// <returns>True if the movie was updated successfully, otherwise false.</returns>
        public bool Update(MOV01 objMOV01)
        {
            var movieIndex = _movie.FindIndex(x => x.ID == objMOV01.ID);

            if (movieIndex != -1)
            {
                _movie[movieIndex] = objMOV01; // Replace the movie at the found index with the updated movie
                return true;
            }
            else
            {
                return false; // Movie with the specified ID not found
            }
        }
        #endregion

        #region Private Method

        /// <summary>
        /// Generates a unique ID for a new movie.
        /// </summary>
        /// <returns>A unique ID.</returns>
        private static int Generator()
        {
            return ++_count;
        }

        #endregion
    }
}
