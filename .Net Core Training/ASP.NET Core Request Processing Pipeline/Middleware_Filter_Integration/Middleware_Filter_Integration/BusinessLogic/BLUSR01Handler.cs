using Middleware_Filter_Integration.Enum;
using Middleware_Filter_Integration.Model;
using Middleware_Filter_Integration.Model.DTO;
using Middleware_Filter_Integration.Model.POCO;
using ServiceStack.OrmLite;
using System.Data;

namespace Middleware_Filter_Integration.BusinessLogic
{
    /// <summary>
    /// Handles business logic operations related to USR01 entities.
    /// </summary>
    public class BLUSR01Handler
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

        /// <summary>
        /// Connection factory for database operations.
        /// </summary>
        private readonly BLConnection _dbFactory;

        #endregion

        #region Public Member

        /// <summary>
        /// Gets or sets the operation type (Insert, Update, etc.).
        /// </summary>
        public enmOperationType objOperation { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BLUSR01Handler"/> class with the specified database connection.
        /// </summary>
        /// <param name="connection">The database connection factory.</param>
        public BLUSR01Handler(BLConnection connection)
        {
            _dbFactory = connection;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Prepares the USR01 entity for saving by mapping from the DTO.
        /// </summary>
        /// <param name="objDtoUSR01">The data transfer object containing user data.</param>
        public void PreSave(DtoUSR01 objDtoUSR01)
        {
            _objUSR01 = _objBLHelper.Map<DtoUSR01, USR01>(objDtoUSR01);           
        }

        /// <summary>
        /// Validates the USR01 entity before saving.
        /// </summary>
        /// <returns>A response indicating the result of the validation.</returns>
        public Response Validation()
        {
            _objResponse = new Response();

            if (objOperation == enmOperationType.I)
            {
                if (_objUSR01.R01F03.Length < 3 )
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Enter valid data.";
                }
            }
            else if (objOperation == enmOperationType.U)
            {
                using(IDbConnection db = _dbFactory.OpenConnection())
                {
                    bool exists = db.Exists<USR01>(x => x.R01F01 == _objUSR01.R01F01);
                    if (!exists)
                    {
                        _objResponse.isError = true;
                        _objResponse.Message = "No matching data found.";
                    }
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Validates if the user exists before deleting.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A response indicating the result of the validation.</returns>
        public Response ValidationOnDelete(int id)
        {
            _objResponse = new Response();

            using(IDbConnection db = _dbFactory.OpenConnection())
            {
                bool exists = db.Exists<USR01>(x => x.R01F01 == id);
                if (!exists)
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "No matching data found.";
                }
                return _objResponse;
            }
        }

        /// <summary>
        /// Retrieves all USR01 entities from the database.
        /// </summary>
        /// <returns>A response containing all user data.</returns>
        public Response GetAll()
        {
            _objResponse = new Response();

            using (IDbConnection db = _dbFactory.OpenConnection())
            {
                _objResponse.response = db.Select<USR01>();
            }
            _objResponse.Message = "User Data..";
            return _objResponse;
        }

        /// <summary>
        /// Retrieves a USR01 entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A response containing the user data.</returns>
        public Response GetById(int id)
        {
            _objResponse = new Response();

            using (IDbConnection db = _dbFactory.OpenConnection())
            {
                _objResponse.response = db.SingleById<USR01>(id);
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves the USR01 entity to the database.
        /// </summary>
        /// <returns>A response indicating the result of the save operation.</returns>
        public Response Save()
        {
            _objResponse = new Response();
            try
            {
                using (IDbConnection db = _dbFactory.OpenConnection())
                {
                    if (objOperation == enmOperationType.I)
                    {
                        db.Insert(_objUSR01);
                        _objResponse.Message = "Inserted Successfully.";
                    }
                    else if (objOperation == enmOperationType.U)
                    {
                        db.Update(_objUSR01);
                        _objResponse.Message = "Updated Successfully.";
                    }

                    return _objResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a USR01 entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        public Response Delete(int id)
        {
            _objResponse = new Response();

            using(IDbConnection db = _dbFactory.OpenConnection())
            {
                db.DeleteById<USR01>(id);
            }
            _objResponse.Message = "Deleted Successfully.";
            return _objResponse;
        }

        #endregion
    }
}
