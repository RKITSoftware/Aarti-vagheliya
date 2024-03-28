namespace Routing.Model
{
    /// <summary>
    /// Represents a movie entity.
    /// </summary>
    public class MOV01
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the ID of the movie.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the movie.
        /// </summary>
        public string MovieName { get; set; }

        /// <summary>
        /// Gets or sets the genre of the movie.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the release date of the movie.
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        #endregion
    }
}
