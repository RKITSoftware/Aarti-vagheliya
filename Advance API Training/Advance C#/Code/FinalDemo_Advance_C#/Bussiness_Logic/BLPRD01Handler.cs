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
    /// Class containing methods for managing product operations.
    /// </summary>
    public class BLPRD01Handler
    {
        #region Private member

        /// <summary>
        /// Instance of Response.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Instance of DBPRD01Context.
        /// </summary>
        private DBPRD01Context _objDBPRD01Context = new DBPRD01Context();

        /// <summary>
        /// Instance of PRD01
        /// </summary>
        private PRD01 _objPRD01 = new PRD01();

        /// <summary>
        /// Instance of IDbConnectionFactory for database connection
        /// </summary>
        private readonly IDbConnectionFactory _dbFactory;

        /// <summary>
        /// Connection string to the database
        /// </summary>
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Constructur

        /// <summary>
        /// Initializes a new instance of the BLPRD01Handler class.
        /// Sets up the OrmLiteConnectionFactory with the provided connection string and MySQL dialect.
        /// </summary>
        public BLPRD01Handler()
        {
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        }

        #endregion

        #region Public Member

        /// <summary>
        /// Instance of Operation type.
        /// </summary>
        public Enums.enmOperationType objOperation { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Prepares the product object for saving by mapping DTO properties to POCO properties.
        /// </summary>
        /// <param name="objDtoPRD01">DTO object containing product data.</param>
        public void PreSave(DtoPRD01 objDtoPRD01)
        {
            _objPRD01 = objDtoPRD01.Map<DtoPRD01, PRD01>();
        }

        /// <summary>
        /// Validates the operation based on the operation type and existing data.
        /// </summary>
        /// <returns>A response indicating the validation result.</returns>
        public Response Validation()
        {
            _objResponse = new Response();

            if (objOperation == Enums.enmOperationType.I)
            {
                if (IsExist(_objPRD01.D01F02))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Product already exists.";
                }
            }
            else if (objOperation == Enums.enmOperationType.U)
            {
                if (!IsExist(_objPRD01.D01F01))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "No matching data found.";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves or updates the product based on the operation type.
        /// </summary>
        /// <returns>A response indicating the save/update result.</returns>
        public Response Save()
        {
            _objResponse = new Response();
            string result = "";

            switch (objOperation)
            {
                case Enums.enmOperationType.I:
                    result = _objDBPRD01Context.AddProduct(_objPRD01);
                    break;

                case Enums.enmOperationType.U:
                    result = _objDBPRD01Context.UpdateProduct(_objPRD01);
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
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A response containing the retrieved products.</returns>
        public Response Select()
        {
            _objResponse = new Response();

            DataTable dataTable = _objDBPRD01Context.GetAllProducts();
            int result = dataTable.Rows.Count;

            if (result > 0)
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
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">ID of the product to delete.</param>
        /// <returns>A response indicating the delete result.</returns>
        public Response Delete(int id)
        {
            _objResponse = new Response();

            string result = _objDBPRD01Context.DeleteProduct(id);

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

        /// <summary>
        /// Retrieves all products to display.
        /// </summary>
        /// <returns>A response containing the list of products for display.</returns>
        public Response Displayproducts()
        {
            _objResponse = new Response();

            int result = _objDBPRD01Context.DisplayProducts().Count;

            if (result > 0)
            {
                _objResponse.isError = false;
                _objResponse.Message = "Ok";
                _objResponse.response = BLHelper.ConvertListToDataTable(_objDBPRD01Context.DisplayProducts());
                return _objResponse;
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
                return _objResponse;
            }
        }

        #endregion

        #region Private methods


        /// <summary>
        /// Checks if a product with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the product to check.</param>
        /// <returns>True if a product with the specified ID exists, otherwise false.</returns>
        private bool IsExist(int id)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Exists<PRD01>(x => x.D01F01 == id);
            }
        }

        /// <summary>
        /// Checks if a product with the specified name exists in the database.
        /// </summary>
        /// <param name="product">The name of the product to check.</param>
        /// <returns>True if a product with the specified name exists, otherwise false.</returns>
        private bool IsExist(string product)
        {
            using (IDbConnection db = _dbFactory.Open())
            {
                return db.Exists<PRD01>(x => x.D01F02 == product);
            }
        }

        #endregion
    }
}