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
    /// Class containing methods for managing contact operations.
    /// </summary>
    public class BLCON01Handler
    {
        #region Private member

        /// <summary>
        /// Instance of Response class.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Instance of DBCON01Context class.
        /// </summary>
        private DBCON01Context _objDBCON01Context = new DBCON01Context();

        /// <summary>
        /// Instance of CON01 class.
        /// </summary>
        private CON01 _objCON01 = new CON01();

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
        /// Initializes a new instance of the BLCON01Handler class.
        /// Sets up the OrmLiteConnectionFactory with the provided connection string and MySQL dialect.
        /// </summary>
        public BLCON01Handler()
        {
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        #endregion

        #region Public methods 

        /// <summary>
        /// Maps the DTO object to the corresponding POCO object.
        /// </summary>
        /// <param name="objDtoCON01">Contact DTO object.</param>
        public void PreSave(DtoCON01 objDtoCON01)
        {
            _objCON01 = objDtoCON01.Map<DtoCON01, CON01>();
        }

        /// <summary>
        /// Validates the contact data based on the operation type.
        /// </summary>
        /// <returns>Response object indicating validation status.</returns>
        public Response Validation()
        {
            _objResponse = new Response();

            if (objOperation == Enums.enmOperationType.I)
            {
                if (_objDBCON01Context.IsDuplicateContact(_objCON01))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Contact already exists.";
                }
            }
            else if (objOperation == Enums.enmOperationType.U)
            {
                if (!IsExist(_objCON01.N01F01))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "No matching data found.";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Executes the save or update operation based on the operation type.
        /// </summary>
        /// <returns>Response object indicating the operation status.</returns>
        public Response Save()
        {
            _objResponse = new Response();
            string result = "";

            switch (objOperation)
            {
                case Enums.enmOperationType.I:
                    result = _objDBCON01Context.AddContact(_objCON01);
                    break;

                case Enums.enmOperationType.U:
                    result = _objDBCON01Context.UpdateContact(_objCON01);
                    break;

                default:
                    _objResponse.isError = true;
                    _objResponse.Message = "Invalid operation type";
                    return _objResponse;
            }

            _objResponse.isError = result == "Success" ? false : true;
            _objResponse.Message = result;
            return _objResponse;
        }

        /// <summary>
        /// Retrieves all contacts from the database.
        /// </summary>
        /// <returns>A response containing the retrieved contacts.</returns>
        public Response Select()
        {
            _objResponse = new Response();

            // Retrieve the DataTable directly from GetAllContacts
            DataTable dataTable = _objDBCON01Context.GetAllContacts();

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
        /// Deletes a contact based on the provided ID.
        /// </summary>
        /// <param name="id">Contact ID to delete.</param>
        /// <returns>Response object indicating the delete operation status.</returns>
        public Response Delete(int id)
        {
            _objResponse = new Response();

            string result = _objDBCON01Context.DeleteContact(id);

            _objResponse.isError = result == "Success" ? false : true;
            _objResponse.Message = result;
            return _objResponse;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Checks if a contact with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the contact to check.</param>
        /// <returns>True if a contact with the specified ID exists, otherwise false.</returns>
        private bool IsExist(int id)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Exists<CON01>(x => x.N01F01 == id);
            }
        }

        #endregion

    }
}