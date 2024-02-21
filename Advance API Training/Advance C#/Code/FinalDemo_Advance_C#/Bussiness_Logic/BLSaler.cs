using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing saler operations.
    /// </summary>
    public class BLSaler
    {
        #region Private member

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public methods 

        /// <summary>
        /// Adds a new saler to the database.
        /// </summary>
        /// <param name="objSLR01">The saler to add.</param>
        /// <returns>True if the saler is successfully added, otherwise false.</returns>
        public bool AddSaler(SLR01 objSLR01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO " +
                                           "SLR01 " +
                                           "(R01F02," +
                                           " R01F03, " +
                                           " R01F04, " +
                                           " R01F05) " +
                                      "VALUES (@SalerName, " +
                                              "@ContactNumber, " +
                                              "@Email, " +
                                              "@City)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SalerName", objSLR01.R01F02);
                command.Parameters.AddWithValue("@ContactNumber", objSLR01.R01F03);
                command.Parameters.AddWithValue("@Email", objSLR01.R01F04);
                command.Parameters.AddWithValue("@City", objSLR01.R01F05);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                   throw new Exception("Error adding saler: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Retrieves all salers from the database.
        /// </summary>
        /// <returns>A list of all salers.</returns>
        public List<SLR01> GetAllSalers()
        {
            List<SLR01> salers = new List<SLR01>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT " +
                                    "R01F01 AS SalerID, " +
                                    "R01F02 AS SalerName, " +
                                    "R01F03 AS ContactNumber, " +
                                    "R01F04 AS Email, " +
                                    "R01F05 AS City " +
                               "FROM " +
                                    "SLR01";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SLR01 saler = new SLR01
                            {
                                R01F01 = reader.GetInt32("SalerID"),
                                R01F02 = reader.GetString("SalerName"),
                                R01F03 = reader.GetString("ContactNumber"),
                                R01F04 = reader.GetString("Email"),
                                R01F05 = reader.GetString("City")
                            };
                            salers.Add(saler);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching salers: " + ex.Message);
                }
            }

            return salers;
        }

        /// <summary>
        /// Updates an existing saler in the database.
        /// </summary>
        /// <param name="salerId">The ID of the saler to update.</param>
        /// <param name="objSLR01">The updated saler data.</param>
        /// <returns>True if the saler is successfully updated, otherwise false.</returns>
        public bool UpdateSaler(int salerId, SLR01 objSLR01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE " +
                                    "SLR01 " +
                               "SET " +
                                    "R01F02 = @SalerName, " +
                                    "R01F03 = @ContactNumber, " +
                                    "R01F04 = @Email, " +
                                    "R01F05 = @City " +
                               "WHERE " +
                                    "R01F01 = @SalerId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SalerName", objSLR01.R01F02);
                command.Parameters.AddWithValue("@ContactNumber", objSLR01.R01F03);
                command.Parameters.AddWithValue("@Email", objSLR01.R01F04);
                command.Parameters.AddWithValue("@City", objSLR01.R01F05);
                command.Parameters.AddWithValue("@SalerId", salerId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating saler: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Deletes a saler from the database.
        /// </summary>
        /// <param name="salerId">The ID of the saler to delete.</param>
        /// <returns>True if the saler is successfully deleted, otherwise false.</returns>
        public bool DeleteSaler(int salerId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE " +
                               "FROM " +
                                    "SLR01 " +
                               "WHERE " +
                                    "R01F01 = @SalerId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SalerId", salerId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting saler: " + ex.Message);
                }
            }
        }

        #endregion
    }
}