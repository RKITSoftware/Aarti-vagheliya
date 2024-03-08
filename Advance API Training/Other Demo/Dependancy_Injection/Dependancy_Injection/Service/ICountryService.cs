using Dependancy_Injection.Model;

namespace Dependancy_Injection.Service
{
    /// <summary>
    /// Interface for country-related operations.
    /// </summary>
    public interface ICountryService
    {
        /// <summary>
        /// Adds a country to the database.
        /// </summary>
        /// <param name="objCountry">The country object to add.</param>
        /// <returns>The added country.</returns>
        Country AddCountry(Country objCountry);

        /// <summary>
        /// Retrieves all countries from the database.
        /// </summary>
        /// <returns>A list of countries.</returns>
        List<Country> GetCountries();


        /// <summary>
        /// Updates a country in the database.
        /// </summary>
        /// <param name="objCountry">The country object to update.</param>
        void UpdateCountry(Country objCountry);

        /// <summary>
        /// Deletes a country from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        void DeleteCountry(int id);

        /// <summary>
        /// Retrieves a country by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve.</param>
        /// <returns>The retrieved country.</returns>
        Country GetCountry(int id);
    }
}
