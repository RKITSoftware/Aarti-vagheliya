using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing supplier operations.
    /// </summary>
    public class BLSupplier
    {
        #region Private member

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public methods

        /// <summary>
        /// Adds a new supplier to the database.
        /// </summary>
        /// <param name="objSUP01">The supplier to add.</param>
        /// <returns>True if the supplier is successfully added, otherwise false.</returns>
        public bool AddSupplier(SUP01 objSUP01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO " +
                                           "SUP01 " +
                                           "(P01F02," +
                                           " P01F03, " +
                                           " P01F04) " +
                                      "VALUES (@SupplierName, " +
                                              "@ContactNumber, " +
                                              "@Email)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierName", objSUP01.P01F02);
                command.Parameters.AddWithValue("@ContactNumber", objSUP01.P01F03);
                command.Parameters.AddWithValue("@Email", objSUP01.P01F04);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding supplier: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Retrieves all suppliers from the database.
        /// </summary>
        /// <returns>A list of all suppliers.</returns>
        public List<SUP01> GetAllSuppliers()
        {
            List<SUP01> suppliers = new List<SUP01>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT " +
                                    "P01F01 AS SupplierID, " +
                                    "P01F02 AS SupplierName, " +
                                    "P01F03 AS ContactNumber, " +
                                    "P01F04 AS Email " +
                               "FROM " +
                                    "SUP01";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SUP01 supplier = new SUP01
                            {
                                P01F01 = reader.GetInt32("SupplierID"),
                                P01F02 = reader.GetString("SupplierName"),
                                P01F03 = reader.GetString("ContactNumber"),
                                P01F04 = reader.GetString("Email")
                            };
                            suppliers.Add(supplier);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching suppliers: " + ex.Message);
                }
            }

            return suppliers;
        }

        /// <summary>
        /// Updates an existing supplier in the database.
        /// </summary>
        /// <param name="supplierId">The ID of the supplier to update.</param>
        /// <param name="objSUP01">The updated supplier data.</param>
        /// <returns>True if the supplier is successfully updated, otherwise false.</returns>
        public bool UpdateSupplier(int supplierId, SUP01 objSUP01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE " +
                                    "SUP01 " +
                               "SET " +
                                    "P01F02 = @SupplierName, " +
                                    "P01F03 = @ContactNumber, " +
                                    "P01F04 = @Email " +
                               "WHERE " +
                                    "P01F01 = @SupplierId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierName", objSUP01.P01F02);
                command.Parameters.AddWithValue("@ContactNumber", objSUP01.P01F03);
                command.Parameters.AddWithValue("@Email", objSUP01.P01F04);
                command.Parameters.AddWithValue("@SupplierId", supplierId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                   throw new Exception("Error updating supplier: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Deletes a supplier from the database.
        /// </summary>
        /// <param name="supplierId">The ID of the supplier to delete.</param>
        /// <returns>True if the supplier is successfully deleted, otherwise false.</returns>
        public bool DeleteSupplier(int supplierId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE " +
                               "FROM " +
                                    "SUP01 " +
                               "WHERE " +
                                    "P01F01 = @SupplierId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierId", supplierId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting supplier: " + ex.Message);
                }
            }
        }

        #endregion
    }
}