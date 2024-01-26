using SwaggerDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SwaggerDemo.Controllers
{
    /// <summary>
    /// Controller for managing Book entities.
    /// </summary>
    public class BookController : ApiController
    {
        // Static list to store Book objects
        private static List<Book> _objBooks = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1", Price = 29.99m },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", Price = 19.99m },
            new Book { Id = 3, Title = "Book 3", Author = "Author 3", Price = 39.99m }
        };

        #region Get
        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>An IHttpActionResult with the list of books.</returns>
        // GET api/books
        public IHttpActionResult Get()
        {
            return Ok(_objBooks);
        }
        #endregion

        #region GetById
        /// <summary>
        /// Retrieves a specific book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>An IHttpActionResult with the specified book.</returns>
        // GET api/books/1
        public IHttpActionResult Get(int id)
        {
            var book = _objBooks.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        #endregion

        #region Post
        /// <summary>
        /// Adds a new book to the collection.
        /// </summary>
        /// <param name="book">The book to be added.</param>
        /// <returns>An IHttpActionResult with the newly added book.</returns>
        // POST api/books
        public IHttpActionResult Post(Book book)
        {
            book.Id = _objBooks.Count + 1;
            _objBooks.Add(book);
            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }
        #endregion

        #region Put
        /// <summary>
        /// Updates an existing book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="book">The updated book data.</param>
        /// <returns>An IHttpActionResult with the updated book.</returns>
        // PUT api/books/1
        public IHttpActionResult Put(int id, Book book)
        {
            var existingBook = _objBooks.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
                return NotFound();

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;

            return Ok(existingBook);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>An IHttpActionResult with the deleted book.</returns>
        // DELETE api/books/1
        public IHttpActionResult Delete(int id)
        {
            var book = _objBooks.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            _objBooks.Remove(book);
            return Ok(book);
        }
        #endregion
    }
}
