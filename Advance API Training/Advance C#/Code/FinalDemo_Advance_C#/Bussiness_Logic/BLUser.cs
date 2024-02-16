using FinalDemo_Advance_C_.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    public class BLUser
    {
        //private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //private readonly IDbConnectionFactory _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);


        private readonly IDbConnectionFactory _dbFactory;
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public BLUser()
        {
            _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
            CreateIfNotExists();
        }


        public void CreateIfNotExists()
        {
            using (var db = _dbFactory.Open())
            {
                if (!db.TableExists<USR01>())
                {
                    db.CreateTable<USR01>();
                    Console.WriteLine("Table USR01 created successfully.");
                }
            }
        }


        public List<USR01> GetAllUsers()
        {
            List<USR01> users = new List<USR01>();

            using (var db = _dbFactory.Open())
            {
                if (!db.TableExists<USR01>())
                {
                    return users; // Table does not exist
                }

                // Retrieve all users
                users = db.Select<USR01>();

                // Decrypt the password for each user
                foreach (var user in users)
                {
                    user.R01F03 = BLCryptography.Decrypt(user.R01F03);
                }
                return users;
            }

        }
            #region Insert Method

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

        #endregion

        #region Update Method

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

        #endregion

        #region Delete Method

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