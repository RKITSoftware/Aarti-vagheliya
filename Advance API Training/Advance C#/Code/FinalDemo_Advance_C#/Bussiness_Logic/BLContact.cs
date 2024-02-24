using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing contact operations.
    /// </summary>
    public class BLContact
    {
        #region Private member

        // Connection string for accessing the database
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public methods 

        /// <summary>
        /// Adds a new contact to the database.
        /// </summary>
        /// <param name="objCNT01">The contact to add.</param>
        /// <returns>True if the contact is successfully added, otherwise false.</returns>
        public bool AddContact(CNT01 objCNT01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO " +
                                           "CNT01 " +
                                           "(T01F02, " +
                                           " T01F03, " +
                                           " T01F04, " +
                                           " T01F05, " +
                                           " T01F06) " +
                                      "VALUES (@CompanyName, " +
                                              "@EmailId, " +
                                              "@Description, " +
                                              "@City, " +
                                              "@Role)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CompanyName", objCNT01.T01F02);
                command.Parameters.AddWithValue("@EmailId", objCNT01.T01F03);
                command.Parameters.AddWithValue("@Description", objCNT01.T01F04);
                command.Parameters.AddWithValue("@City", objCNT01.T01F05);
                command.Parameters.AddWithValue("@Role", objCNT01.T01F06.ToString());

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding contact: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Retrieves all contacts from the database.
        /// </summary>
        /// <returns>A list of all contacts.</returns>
        public List<CNT01> GetAllContacts()
        {
            List<CNT01> contacts = new List<CNT01>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT " +
                                    "T01F01 AS ContactId, " +
                                    "T01F02 AS CompanyName, " +
                                    "T01F03 AS EmailId, " +
                                    "T01F04 AS Description, " +
                                    "T01F05 AS City, " +
                                    "T01F06 AS Role_For_Interaction " +
                               "FROM " +
                                    "CNT01";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CNT01 contact = new CNT01
                            {
                                T01F01 = reader.GetInt32("ContactId"),
                                T01F02 = reader.GetString("CompanyName"),
                                T01F03 = reader.GetString("EmailId"),
                                T01F04 = reader.GetString("Description"),
                                T01F05 = reader.GetString("City"),
                                T01F06 = (enmContactType)Enum.Parse(typeof(enmContactType), reader.GetString("Role_For_Interaction"))
                            };
                            contacts.Add(contact);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching contacts: " + ex.Message);
                }
            }

            return contacts;
        }

        /// <summary>
        /// Updates an existing contact in the database.
        /// </summary>
        /// <param name="contactId">The ID of the contact to update.</param>
        /// <param name="objCNT01">The updated contact data.</param>
        /// <returns>True if the contact is successfully updated, otherwise false.</returns>
        public bool UpdateContact(int contactId, CNT01 objCNT01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE " +
                                    "CNT01 " +
                               "SET " +
                                    "T01F02 = @CompanyName, " +
                                    "T01F03 = @EmailId, " +
                                    "T01F04 = @Description, " +
                                    "T01F05 = @City, " +
                                    "T01F06 = @Role " +
                               "WHERE " +
                                    "T01F01 = @ContactId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CompanyName", objCNT01.T01F02);
                command.Parameters.AddWithValue("@EmailId", objCNT01.T01F03);
                command.Parameters.AddWithValue("@Description", objCNT01.T01F04);
                command.Parameters.AddWithValue("@City", objCNT01.T01F05);
                command.Parameters.AddWithValue("@Role", objCNT01.T01F06.ToString());
                command.Parameters.AddWithValue("@ContactId", contactId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating contact: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Deletes a contact from the database.
        /// </summary>
        /// <param name="contactId">The ID of the contact to delete.</param>
        /// <returns>True if the contact is successfully deleted, otherwise false.</returns>
        public bool DeleteContact(int contactId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE " +
                               "FROM " +
                                    "CNT01 " +
                               "WHERE " +
                                    "T01F01 = @ContactId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContactId", contactId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting contact: " + ex.Message);
                }
            }
        }

        #endregion
    }
}