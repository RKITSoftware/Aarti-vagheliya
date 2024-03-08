using Dependancy_Injection.Data;
using Dependancy_Injection.Model;

namespace Dependancy_Injection.Service
{
    /// <summary>
    /// Service class for managing country-related operations.
    /// Implements the <see cref="ICountryService"/> interface.
    /// </summary>
    public class CountryService : ICountryService
    {
        #region Private Member

        // Private field for database context
        private readonly DBContextClass _dbContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CountryService(DBContextClass context)
        {
            _dbContext = context;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a country to the database.
        /// </summary>
        /// <param name="objCountry">The country object to add.</param>
        /// <returns>The added country.</returns>
        public Country AddCountry(Country objCountry)
        {
            _dbContext.Countries.Add(objCountry);
            _dbContext.SaveChanges();
            return objCountry;
        }

        /// <summary>
        /// Retrieves all countries from the database.
        /// </summary>
        /// <returns>A list of countries.</returns>
        public List<Country> GetCountries()
        {
           return _dbContext.Countries.OrderBy(c => c.t01f02).ToList();
        }

        /// <summary>
        /// Retrieves a country by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve.</param>
        /// <returns>The retrieved country.</returns>
        public Country GetCountry(int id)
        {
            return _dbContext.Countries.FirstOrDefault(x => x.t01f01 == id);
        }

        /// <summary>
        /// Updates a country in the database.
        /// </summary>
        /// <param name="objcountry">The country object to update.</param>
        public void UpdateCountry(Country objcountry)
        {
            _dbContext.Countries.Update(objcountry);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes a country from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        public void DeleteCountry(int id)
        {
            var country = _dbContext.Countries.FirstOrDefault(x => x.t01f01 == id);
            if(country != null)
            {
                _dbContext.Countries.Remove(country);
                _dbContext.SaveChanges();
            }
        }

        #endregion
    }
}
