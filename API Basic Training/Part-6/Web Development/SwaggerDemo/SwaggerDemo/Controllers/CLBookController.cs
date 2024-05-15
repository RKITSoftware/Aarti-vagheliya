using SwaggerDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SwaggerDemo.Controllers
{
    /// <summary>
    /// Controller for managing Book entities.
    /// </summary>
    public class CLBookController : ApiController
    {
        #region Private Member

        // Static list to store Book objects
        private static List<Book> _lstBooks = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1", Price = 29.99m },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", Price = 19.99m },
            new Book { Id = 3, Title = "Book 3", Author = "Author 3", Price = 39.99m }
        };

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>An IHttpActionResult with the list of books.</returns>
        // GET api/books
        [HttpGet]
        [Route("api/books/Get")]
        public IHttpActionResult Get()
        {
            return Ok(_lstBooks);
        }

        /// <summary>
        /// Retrieves a specific book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>An IHttpActionResult with the specified book.</returns>
        // GET api/books/1
        [HttpGet]
        [Route("api/books/GetById")]
        public IHttpActionResult Get(int id)
        {
            var book = _lstBooks.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        /// <summary>
        /// Adds a new book to the collection.
        /// </summary>
        /// <param name="book">The book to be added.</param>
        /// <returns>An IHttpActionResult with the newly added book.</returns>
        // POST api/books
        [HttpPost]
        [Route("api/book/Add")]
        public IHttpActionResult Post(Book book)
        {
            book.Id = _lstBooks.Count + 1;
            _lstBooks.Add(book);
            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        /// <summary>
        /// Updates an existing book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="book">The updated book data.</param>
        /// <returns>An IHttpActionResult with the updated book.</returns>
        // PUT api/books/1
        [HttpPut]
        [Route("api/books/Put")]
        public IHttpActionResult Put(int id, Book book)
        {
            var existingBook = _lstBooks.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
                return NotFound();

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;

            return Ok(existingBook);
        }

        /// <summary>
        /// Deletes a book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>An IHttpActionResult with the deleted book.</returns>
        // DELETE api/books/1
        [HttpDelete]
        [Route("api/books/Delete")]
        public IHttpActionResult Delete(int id)
        {
            var book = _lstBooks.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            _lstBooks.Remove(book);
            return Ok(book);
        }

        #endregion
    }
}
