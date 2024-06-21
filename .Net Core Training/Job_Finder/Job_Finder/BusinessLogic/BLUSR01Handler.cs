using Job_Finder.Enum;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Job_Finder.Services;
using ServiceStack.OrmLite;
using System.Text.RegularExpressions;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Business logic handler for USR01 operations.
    /// </summary>
    public class BLUSR01Handler : CRUDImplementation<USR01>
    {
        #region Private Members

        /// <summary>
        /// Response object used to store the result of operations.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// USR01 object representing the user data.
        /// </summary>
        private USR01 _objUSR01 = new USR01();

        /// <summary>
        /// Helper class instance for business logic operations.
        /// </summary>
        private readonly BLHelper _objBLHelper = new BLHelper();

        #endregion

        #region Public Methods

        /// <summary>
        /// Prepares the user data for saving by mapping the DTO to the POCO and encrypting the password.
        /// </summary>
        /// <param name="objDtoUSR01">Data transfer object containing user data.</param>
        public void PreSave(DTOUSR01 objDtoUSR01)
        {
            _objUSR01 = _objBLHelper.Map<DTOUSR01, USR01>(objDtoUSR01);
            _objUSR01.R01F03 = _objBLHelper.Encrypt(_objUSR01.R01F03);
            obj = _objUSR01;
        }

        /// <summary>
        /// Validates the user data based on the operation type.
        /// </summary>
        /// <returns>Response object indicating the validation result.</returns>
        public Response Validation()
        {
            _objResponse = new Response();

            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            Regex regex = new Regex(emailPattern);

            if (objOperation == enmOperationType.I)
            {
                if (!regex.IsMatch(_objUSR01.R01F04))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Enter valid data.";
                }
            }
            else if (objOperation == enmOperationType.U)
            {
                if (!IsExists(_objUSR01.R01F01))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "No matching data found.";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Validates the deletion of user data based on the user ID.
        /// </summary>
        /// <param name="id">User ID to validate.</param>
        /// <returns>Response object indicating the validation result.</returns>
        public Response ValidationDelete(int id)
        {
            _objResponse = new Response();

            if (!IsExists(id))
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves all users from the database, decrypting their passwords.
        /// </summary>
        /// <returns>List of USR01 objects representing all users.</returns>
        public List<USR01> GetAllUsers()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                if (!db.TableExists<USR01>())
                {
                    return null; // Table does not exist
                }

                // Retrieve all users
                var users = db.Select<USR01>();

                // Decrypt the password for each user
                foreach (var user in users)
                {
                    user.R01F03 = _objBLHelper.Decrypt(user.R01F03);
                }
                return users;
            }

        }

        #endregion
    }
}