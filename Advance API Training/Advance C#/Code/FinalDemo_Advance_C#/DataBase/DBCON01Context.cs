using FinalDemo_Advance_C_.Models.POCO;
using MySql.Data.MySqlClient;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Configuration;
using System.Data;
using System.Linq;

namespace FinalDemo_Advance_C_.DataBase
{
    /// <summary>
    /// Provides data access methods for the CON01 table related to contacts.
    /// </summary>
    public class DBCON01Context
    {
        #region Private member

        /// <summary>
        ///  Connection string for accessing the database
        /// </summary>
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        /// <summary>
        /// Instance of IDbConnectionFactory for database connection
        /// </summary>
        private readonly IDbConnectionFactory _dbFactory = new OrmLiteConnectionFactory(_connectionString, MySqlDialect.Provider);
        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves all contacts from the database.
        /// </summary>
        /// <returns>A DataTable containing the retrieved contacts.</returns>
        public DataTable GetAllContacts()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // SQL query to fetch contact details
                string query = @"SELECT 
                            N01F01 AS ContactId,
                            N01F02 AS CompanyName,
                            N01F03 AS EmailId, 
                            N01F04 AS Description,
                            N01F05 AS City, 
                            N01F06 AS Role_For_Interaction 
                        FROM
                            CON01";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Fill the DataTable with data from the database
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching contacts: " + ex.Message);
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Adds a new contact to the CON01 table.
        /// </summary>
        /// <param name="objCON01">The contact to add.</param>
        /// <returns>Success message or error message.</returns>
        public string AddContact(CON01 objCON01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"INSERT INTO 
                                                        CON01 
                                                          ( N01F02, 
                                                            N01F03, 
                                                            N01F04, 
                                                            N01F05,
                                                            N01F06)     
                                                        VALUES (  '{0}',
                                                                  '{1}', 
                                                                  '{2}',
                                                                  '{3}',
                                                                  '{4}')",
                                                                 objCON01.N01F02,
                                                                 objCON01.N01F03,
                                                                 objCON01.N01F04,
                                                                 objCON01.N01F05,
                                                                 objCON01.N01F06.ToString());
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return "Success";
                    else
                        return "failed to Add new contact.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding contact: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Updates an existing contact in the CON01 table.
        /// </summary>
        /// <param name="objCON01">The contact to update.</param>
        /// <returns>Success message or error message.</returns>
        public string UpdateContact(CON01 objCON01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"UPDATE 
                                                    CON01 
                                               SET 
                                                    N01F02 = '{0}', 
                                                    N01F03 = '{1}', 
                                                    N01F04 = '{2}',
                                                    N01F05 = '{3}', 
                                                    N01F06 = '{4}'
                                               WHERE 
                                                    N01F01 = {5}",
                                                    objCON01.N01F02,
                                                    objCON01.N01F03,
                                                    objCON01.N01F04,
                                                    objCON01.N01F05,
                                                    objCON01.N01F06.ToString(),
                                                    objCON01.N01F01);
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return "Success";
                    else
                        return "Failed to update Contact details.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating contact: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Deletes a contact from the CON01 table.
        /// </summary>
        /// <param name="contactId">The ID of the contact to delete.</param>
        /// <returns>Success message or error message.</returns>
        public string DeleteContact(int contactId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"DELETE 
                                               FROM 
                                                    CON01
                                               WHERE 
                                                    N01F01 = {0}",
                                                    contactId);
                MySqlCommand command = new MySqlCommand(query, connection);



                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0 ? "Success" : "Failed to delete Contact.";
                
             
            }
        }

        /// <summary>
        /// Checks if a duplicate contact exists in the CON01 table.
        /// </summary>
        /// <param name="contact">The contact to check for duplicates.</param>
        /// <returns>True if a duplicate contact exists, otherwise false.</returns>
        public bool IsDuplicateContact(CON01 contact)
        {
            using (var db = _dbFactory.Open())
            {
                // Check if there's a contact with the same email and different role
                var existingContact = db.Single<CON01>(x => x.N01F02 == contact.N01F02 && x.N01F03 == contact.N01F03 && x.N01F06 == contact.N01F06);

                if (existingContact != null)
                    return true;
                else
                    return false;
            }
        }

        #endregion
    }
}