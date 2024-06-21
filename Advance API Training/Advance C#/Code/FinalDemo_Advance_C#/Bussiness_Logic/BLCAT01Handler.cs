using FinalDemo_Advance_C_.DataBase;
using FinalDemo_Advance_C_.Models;
using FinalDemo_Advance_C_.Models.DTO;
using FinalDemo_Advance_C_.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;
using System.Data;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Business logic class for managing categories.
    /// </summary>
    public class BLCAT01Handler
    {
        #region Private member

        /// <summary>
        /// Private Instanse of Response class.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Private instance of DBCAT01Context class.
        /// </summary>
        private DBCAT01Context _objDBCAT01Context = new DBCAT01Context();

        /// <summary>
        /// Private instance of CAT01 Class
        /// </summary>
        private CAT01 _objCAT01;

        /// <summary>
        /// Instance of IDbConnectionFactory for database connection
        /// </summary>
        private readonly IDbConnectionFactory _dbFactory;

        /// <summary>
        /// Connection string to the database
        /// </summary>
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public Member

        /// <summary>
        /// Instance of Operation type.
        /// </summary>
        public Enums.enmOperationType objOperation { get; set; }

        #endregion

        #region Constructur

        /// <summary>
        /// Initializes a new instance of the BLCAT01Handler class.
        /// Sets up the OrmLiteConnectionFactory with the provided connection string and MySQL dialect.
        /// </summary>
        public BLCAT01Handler()
        {
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Prepares the category object from DTO.
        /// </summary>
        /// <param name="objDtoCAT01">Category DTO object.</param>
        /// <returns>Category object.</returns>
        public CAT01 PreSave(DtoCAT01 objDtoCAT01)
        {
            return _objCAT01 = objDtoCAT01.Map<DtoCAT01, CAT01>();
        }

        /// <summary>
        /// Validates the category data based on the operation type.
        /// </summary>
        /// <returns>Response object indicating validation status.</returns>
        public Response Validation()
        {
            _objResponse = new Response();

            if(objOperation == Enums.enmOperationType.I)
            {
                if (IsExist(_objCAT01.T01F02))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Category already exists.";
                }
            }
            else if(objOperation == Enums.enmOperationType.U)
            {
                if (!IsExist(_objCAT01.T01F01))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "No matching data found.";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves or updates the category based on the operation type.
        /// </summary>
        /// <returns>Response object indicating the operation status.</returns>
        public Response Save()
        {
            _objResponse = new Response();
            string result = "";

            switch (objOperation)
            {
                case Enums.enmOperationType.I:
                    result = _objDBCAT01Context.AddCategory(_objCAT01);
                    break;

                case Enums.enmOperationType.U:
                    result = _objDBCAT01Context.UpdateCategory(_objCAT01);
                    break;

                default:
                    _objResponse.isError = true;
                    _objResponse.Message = "Invalid operation type";
                    return _objResponse;
            }

            if (result == "Success")
            {
                _objResponse.isError = false;
            }
            else
            {
                _objResponse.isError = true;
            }

            _objResponse.Message = result;
            return _objResponse;
        }

        /// <summary>
        /// Retrieves all categories from the database and returns the result as a Response object.
        /// </summary>
        /// <returns>
        /// A Response object containing a DataTable with all categories if available, 
        /// or an error message if no data is found.
        /// </returns>
        public Response Select()
        {
            _objResponse = new Response();

            // Retrieve the DataTable directly from GetAllCategories
            DataTable dataTable = _objDBCAT01Context.GetAllCategories();

            if (dataTable.Rows.Count > 0)
            {
                _objResponse.isError = false;
                _objResponse.Message = "Ok";
                _objResponse.response = dataTable; // Directly assign the DataTable
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }

            return _objResponse;
        }

        /// <summary>
        /// Deletes a category based on the provided ID.
        /// </summary>
        /// <param name="id">Category ID to delete.</param>
        /// <returns>Response object indicating the delete operation status.</returns>
        public Response Delete(int id)
        {
            _objResponse = new Response();

            string result = _objDBCAT01Context.DeleteCategory(id);

            if (result == "Success")
            {
                _objResponse.isError = false;
                _objResponse.Message = result;
                return _objResponse;
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = result;
                return _objResponse;
            }
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Checks if a category with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the category to check.</param>
        /// <returns>True if the category exists; otherwise, false.</returns>
        private bool IsExist(int id)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Exists<CAT01>(x => x.T01F01 == id);
            }
        }


        /// <summary>
        /// Checks if a category with the specified name exists in the database.
        /// </summary>
        /// <param name="category">The name of the category to check.</param>
        /// <returns>True if the category exists; otherwise, false.</returns>
        private bool IsExist(string category)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Exists<CAT01>(x => x.T01F02 == category);
            }
        }

        #endregion
    }
}