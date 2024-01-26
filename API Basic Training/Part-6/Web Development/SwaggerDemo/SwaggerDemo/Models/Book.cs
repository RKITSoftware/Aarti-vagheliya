

namespace SwaggerDemo.Models
{
    /// <summary>
    /// Represents a book entity with basic information.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the unique identifier of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the price of the book.
        /// </summary>
        public decimal Price { get; set; }
    }
}