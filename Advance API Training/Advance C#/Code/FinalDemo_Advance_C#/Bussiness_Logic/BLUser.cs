using FinalDemo_Advance_C_.Models;
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
    public class BLUser
    {
        #region Private Member

        // Instance of IDbConnectionFactory for database connection
        private readonly IDbConnectionFactory _dbFactory;

        // Connection string to the database
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for BLUser class.
        /// </summary>
        public BLUser()
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
        /// Method to retrieve all users from the database.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<USR01> GetAllUsers()
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

        /// <summary>
        /// Inserts a new record into table USR01
        /// </summary>
        /// <param name="objUSR01">New user object to be inserted</param>
        /// <returns>Message indicating the success of the operation</returns>
        public string Insert(USR01 objUSR01)
        {
            // Open a database connection
            using (var db = _dbFactory.Open())
            {
                // Create table if it doesn't exist
                if (!db.TableExists<USR01>())
                {
                    db.CreateTable<USR01>();
                }

                // Encrypt the password before storing it in the database
                objUSR01.R01F03 = BLCryptography.Encrypt(objUSR01.R01F03);

                // Insert new user object
                db.Insert(objUSR01);
                return "Success!";
            }
        }

        /// <summary>
        /// Updates a record in table USR01
        /// </summary>
        /// <param name="objUSR01">User object with updated data</param>
        /// <returns>Message indicating the success of the operation</returns>
        public string Update(USR01 objUSR01)
        {
            // Open a database connection
            using (var db = _dbFactory.Open())
            {
                // Check if table exists
                if (!db.TableExists<USR01>())
                {
                    return "Table does not exist!";
                }

                // Find existing user by ID
                var existingUser = db.SingleById<USR01>(objUSR01.R01F01);
                if (existingUser == null)
                {
                    return "User not found!";
                }

                // Encrypt the password before storing it in the database
                objUSR01.R01F03 = BLCryptography.Encrypt(objUSR01.R01F03);

                // Update user object
                db.Update(objUSR01);
                return "Success!";
            }
        }

        /// <summary>
        /// Deletes a record from table USR01
        /// </summary>
        /// <param name="id">ID of the user record to be deleted</param>
        /// <returns>Message indicating the success of the operation</returns>
        public string Delete(int id)
        {
            // Open a database connection
            using (var db = _dbFactory.Open())
            {
                // Check if table exists
                if (!db.TableExists<USR01>())
                {
                    return "Table does not exist!";
                }

                // Find existing user by ID
                var existingUser = db.SingleById<USR01>(id);
                if (existingUser == null)
                {
                    return "User not found!";
                }

                // Delete user record
                db.DeleteById<USR01>(id);
                return "Success!";
            }
        }

        #endregion
    }
}