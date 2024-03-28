using FiltersApi.Model;

namespace FiltersApi.BusinessLogic
{
    /// <summary>
    /// Business logic class for managing countries.
    /// </summary>
    public class BLCountry
    {
        #region Private member

        /// <summary>
        /// Static counter for generate unique id.
        /// </summary>
        private static int _count = 0;

        /// <summary>
        /// Static list for store object of country.
        /// </summary>
        private static List<CNT01> _lstcountry = new List<CNT01>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all countries.
        /// </summary>
        /// <returns>A list of all countries.</returns>
        public List<CNT01> GetCountries()
        {
            return _lstcountry.ToList();
        }

        /// <summary>
        /// Retrieves a single country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve.</param>
        /// <returns>The country object if found; otherwise, null.</returns>
        public CNT01 GetOneCountry(int id)
        {
            return _lstcountry.FirstOrDefault(x => x.T01F01 == id);
        }

        /// <summary>
        /// Adds a new country.
        /// </summary>
        /// <param name="objCNT01">The country object to add.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        public string AddCountry(CNT01 objCNT01)
        {
            objCNT01.T01F01 = GenerateId();
            _lstcountry.Add(objCNT01);
            return "Country Added Succesfully.";
        }

        /// <summary>
        /// Deletes a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        /// <returns>True if the country was successfully deleted; otherwise, false.</returns>
        public bool DeleteCountry(int id)
        {
            var index = _lstcountry.FindIndex(x => x.T01F01 == id);

            if (index != -1)
            {
                _lstcountry.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Updates a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to update.</param>
        /// <param name="objCNT01">The updated country object.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        public string UpdateCountry(int id, CNT01 objCNT01)
        {
            var index = _lstcountry.FindIndex(x => x.T01F01 == id);

            if (index != -1)
            {
                _lstcountry[index] = objCNT01; 
                return "Success";
            }
            else
            {
                return "Fail"; 
            }
        }

        /// <summary>
        /// Validates a country object.
        /// </summary>
        /// <param name="objCNT01">The country object to validate.</param>
        /// <returns>True if the country object is valid; otherwise, false.</returns>
        public bool Validation(CNT01 objCNT01)
        {
           
            if (objCNT01.T01F03 > 0 && objCNT01.T01F03 < 1000)
            {
                return true;
            }
            else
                return false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generates a unique ID for a new country.
        /// </summary>
        /// <returns>The generated unique ID.</returns>
        private static int GenerateId()
        {
            return ++_count;
        }

        #endregion
    }
}
