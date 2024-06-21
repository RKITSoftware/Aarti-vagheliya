using FiltersApi.Model;

namespace FiltersApi.BusinessLogic
{
    /// <summary>
    /// Business logic class for managing users.
    /// </summary>
    public class BLUser
    {
        #region Private Member

        /// <summary>
        /// Static counter for generate unique ID.
        /// </summary>
        private static int _count = 0;

        /// <summary>
        /// Static list to store User details
        /// </summary>
        private static List<USR01> _lstuser = new List<USR01>
        {
            new USR01 {R01F01 = GenerateId(), R01F02 = "Arti", R01F03 = "arti123", R01F04 = 0 },
            new USR01 {R01F01 = GenerateId(), R01F02 = "Aarti", R01F03 = "aarti123", R01F04 = enmUserRole.Guest }
        };

        #endregion

        #region Public Methods

        public List<USR01> GetUsers()
        {
            return _lstuser.ToList();
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="objUSR01">The user object to add.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        public string AddUser(USR01 objUSR01)
        {
            objUSR01.R01F01 = GenerateId();
            _lstuser.Add(objUSR01);
            return "User Added suceccfully";
        }

        /// <summary>
        /// Validates a user object.
        /// </summary>
        /// <param name="objUSR01">The user object to validate.</param>
        /// <returns>True if the user object is valid; otherwise, false.</returns>
        public bool Validation(USR01 objUSR01)
        {
            if (objUSR01.R01F03.Length >= 3)
            {
                return true;
            }
            else
                return false;
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Generates a unique ID for a new user.
        /// </summary>
        /// <returns>The generated unique ID.</returns>
        private static int GenerateId()
        {
            return ++_count;
        }

        #endregion
    }
}
