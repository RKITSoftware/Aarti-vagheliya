using Job_Finder.Enum;
using Job_Finder.Model;

namespace Job_Finder.Interface
{
    /// <summary>
    /// Interface for CRUD operations.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface ICRUDService<T> where T : class
    {
        /// <summary>
        /// Gets or sets the object of type T.
        /// </summary>
        T obj { get; set; }

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        enmOperationType objOperation { get; set; }

        /// <summary>
        /// Checks if the entity with the specified id exists.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>True if the entity exists, otherwise false.</returns>
        bool IsExists(int id);

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <returns>A response indicating the result of the operation.</returns>
        Response Save();

        /// <summary>
        /// Retrieves entities.
        /// </summary>
        /// <returns>A response containing the retrieved entities.</returns>
        Response Select();

        /// <summary>
        /// Deletes the entity with the specified id.
        /// </summary>
        /// <param name="id">The id of the entity to delete.</param>
        /// <returns>A response indicating the result of the operation.</returns>
        Response Delete(int id);

       // Response Validation();
    }
}
