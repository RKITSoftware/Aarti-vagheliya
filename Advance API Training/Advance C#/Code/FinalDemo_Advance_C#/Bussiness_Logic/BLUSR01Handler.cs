using FinalDemo_Advance_C_.Models;
using FinalDemo_Advance_C_.Models.DTO;
using FinalDemo_Advance_C_.Models.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing user data.
    /// </summary>
    public class BLUSR01Handler
    {
        #region Private Member

        /// <summary>
        /// Instance of IDbConnectionFactory for database connection
        /// </summary>
        private readonly IDbConnectionFactory _dbFactory;

        /// <summary>
        /// Connection string to the database
        /// </summary>
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        /// <summary>
        /// private instance of Response class.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// private instance of USR01 class.
        /// </summary>
        private USR01 _objUSR01 = new USR01();

        #endregion

        #region Public Member

        /// <summary>
        /// Instance of Operation type enum.
        /// </summary>
        public Enums.enmOperationType objOperation { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for BLUser class.
        /// </summary>
        public BLUSR01Handler()
        {
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider); // Initializing IDbConnectionFactory
            CreateIfNotExists(); // Creating the table if it doesn't exist
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to configure SQL dialect.
        /// </summary>
        public static void Configure()
        {
            // Configuring SQL dialect
            SqlServerDialect.Provider.StringSerializer = new JsonStringSerializer(); // Or any other serializer that supports enum serialization
        }

        /// <summary>
        /// Method to create the table if it doesn't exist.
        /// </summary>
        public void CreateIfNotExists()
        {
            using (var db = _dbFactory.Open())
            {
                if (!db.TableExists<USR01>())
                {
                    db.CreateTable<USR01>(); // Creating the table if it doesn't exist
                    Console.WriteLine("Table USR01 created successfully.");
                }
            }
        }

        /// <summary>
        /// Maps data transfer object to persistent object.
        /// </summary>
        /// <param name="objDtoUSR01">Data transfer object for user.</param>
        public void PreSave(DtoUSR01 objDtoUSR01)
        {
            _objUSR01 = objDtoUSR01.Map<DtoUSR01, USR01>();
        }

        /// <summary>
        /// Validates the user data.
        /// </summary>
        /// <returns>Validation result.</returns>
        public Response Validation()
        {
            _objResponse = new Response();

            if (objOperation == Enums.enmOperationType.I)
            {
                if (IsExist(_objUSR01.R01F02))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "User already exists.";
                }
            }
            else if (objOperation == Enums.enmOperationType.U)
            {
                if (!IsExist(_objUSR01.R01F01))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "No matching data found.";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Method to retrieve all users from the database.
        /// </summary>
        /// <returns>List of users.</returns>
        public Response GetAllUsers()
        {
            _objResponse = new Response();

            using (var db = _dbFactory.Open())
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
                    user.R01F03 = BLCryptography.Decrypt(user.R01F03);
                }

                _objResponse.isError = false;
                _objResponse.Message = "Success";
                _objResponse.response = BLHelper.ToDataTable(users);
                return _objResponse;
            }

        }

        /// <summary>
        /// Saves or updates a user record in the database.
        /// </summary>
        /// <returns>Save result.</returns>
        public Response Save()
        {
            _objResponse = new Response();
            try
            {
                using (var db = _dbFactory.Open())
                {
                    if (objOperation == Enums.enmOperationType.I)
                    {
                        _objUSR01.R01F03 = BLCryptography.Encrypt(_objUSR01.R01F03);
                        db.Insert(_objUSR01);
                        _objResponse.Message = "Inserted Successfully.";
                    }
                    else if (objOperation == Enums.enmOperationType.U)
                    {
                        _objUSR01.R01F03 = BLCryptography.Encrypt(_objUSR01.R01F03);
                        db.Update(_objUSR01);
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
        /// Deletes a record from table USR01
        /// </summary>
        /// <param name="id">ID of the user record to be deleted</param>
        /// <returns>Message indicating the success of the operation</returns>
        public Response Delete(int id)
        {
            _objResponse = new Response();
            // Open a database connection
            using (var db = _dbFactory.Open())
            {
                // Check if table exists
                if (!db.TableExists<USR01>())
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Table does not exist!";
                    return _objResponse;
                }
                // Find existing user by ID
                var existingUser = db.SingleById<USR01>(id);
                if (existingUser == null)
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "User not found!!";
                    return _objResponse;
                }

                // Delete user record
                db.DeleteById<USR01>(id);
                _objResponse.isError = true;
                _objResponse.Message = "Success!!";
                return _objResponse;
            }
        }

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<USR01> GetUsers()
        {
            using (var db = _dbFactory.Open())
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
                    user.R01F03 = BLCryptography.Decrypt(user.R01F03);
                }
                return users; // Returning the list of users
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if a user with given ID exists.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>True if user exists, otherwise false.</returns>
        private bool IsExist(int id)
        {
            using(var db = _dbFactory.Open())
            {
                var  _objUSR01 = db.SingleById<USR01>(id);
                return _objUSR01 == null ? false : true;
            }
        }

        /// <summary>
        /// Checks if a user with given username exists.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns>True if user exists, otherwise false.</returns>
        private bool IsExist(string username)
        {
            using (var db = _dbFactory.Open())
            {
                var _objUSR01 = db.SingleById<USR01>(username);
                return _objUSR01 == null ? false : true;
            }
        }

        #endregion
    }
}