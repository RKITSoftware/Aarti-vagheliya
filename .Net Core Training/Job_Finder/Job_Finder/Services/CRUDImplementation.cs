using Job_Finder.BusinessLogic;
using Job_Finder.DataBase;
using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model;
using ServiceStack.OrmLite;

namespace Job_Finder.Services
{
    /// <summary>
    /// Provides CRUD (Create, Read, Update, Delete) operations for a generic type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity for which CRUD operations are performed.</typeparam>
    public class CRUDImplementation<T> : ICRUDService<T> where T : class
    {
        #region Private Member

        /// <summary>
        /// Instance of BLHelper class.
        /// </summary>
        private readonly BLHelper _objBLHelper = new BLHelper();

        /// <summary>
        /// Response object containing the outcome of CRUD operations.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Database context for common operations.
        /// </summary>
        private readonly DBCommonContext<T> _objDBCommomContext = new DBCommonContext<T>();

        /// <summary>
        /// Connection string for the database.
        /// </summary>
        private readonly string _connectionString;

        #endregion

        #region Public Member

        /// <summary>
        /// Factory for creating database connections.
        /// </summary>
        public readonly OrmLiteConnectionFactory _dbFactory;

        /// <summary>
        /// Gets or sets the object for which CRUD operations are performed.
        /// </summary>
        public T obj { get; set; }

        /// <summary>
        /// Gets or sets the operation type for CRUD operations.
        /// </summary>
        public enmOperationType objOperation { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CRUDImplementation{T}"/> class.
        /// </summary>
        public CRUDImplementation()
        {
            _connectionString = _objBLHelper.GetConnectionString();
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
            CreateIfNotExists();
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Checks if an entity with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the entity to check.</param>
        /// <returns>True if the entity exists; otherwise, false.</returns>
        public bool IsExists(int id)
        {
             T obj;

            using(var db = _dbFactory.OpenDbConnection())
            {
                 obj = db.SingleById<T>(id);
            }

            return  obj != null ? true : false; 
        }

        /// <summary>
        /// Saves the object to the database based on the specified CRUD operation type.
        /// </summary>
        /// <returns>A <see cref="Response"/> object containing information about the operation outcome.</returns>
        public Response Save()
        {
            _objResponse = new Response();
            try
            {
                using(var db = _dbFactory.OpenDbConnection())
                {
                    if(objOperation == enmOperationType.I)
                    {
                        db.Insert<T>(obj);
                        _objResponse.Message = "Inserted Successfully.";
                    }
                    else if(objOperation == enmOperationType.U)
                    {
                        db.Update<T>(obj);
                        _objResponse.Message = "Updated Successfully.";
                    }

                    return _objResponse;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retrieves data from the database.
        /// </summary>
        /// <returns>A <see cref="Response"/> object containing the retrieved data.</returns>
        public Response Select()
        {
            _objResponse = new Response();

            _objResponse.response = _objDBCommomContext.Select();

            return _objResponse;
        }

        /// <summary>
        /// Deletes the object with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the object to delete.</param>
        /// <returns>A <see cref="Response"/> object containing information about the operation outcome.</returns>
        public Response Delete(int id)
        {
            _objResponse = new Response();
            try
            {
                using (var db = _dbFactory.OpenDbConnection())
                {
                    db.DeleteById<T>(id);
                    _objResponse.Message = "Deleted Successfully.";
                }
                return _objResponse;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region Private Method

        /// <summary>
        /// Creates the table in the database if it does not already exist.
        /// </summary>
        private void CreateIfNotExists()
        {
            using (var db = _dbFactory.Open())
            {
                if (!db.TableExists<T>())
                {
                    db.CreateTable<T>(); // Creating the table if it doesn't exist
                }
            }
        }

        #endregion
    }
}
