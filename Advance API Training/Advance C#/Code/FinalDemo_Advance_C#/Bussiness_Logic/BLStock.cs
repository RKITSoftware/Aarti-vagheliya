using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Business logic class for managing stock.
    /// </summary>
    public class BLStock
    {
        #region Private members

        // Connection string for accessing the database
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all stock entries from the database.
        /// </summary>
        /// <returns>List of stock entries.</returns>
        public List<STK01> GetAllStockEntries()
        {
            List<STK01> stockEntries = new List<STK01>();

            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT " +
                                    "K01F01, " +
                                    "K01F02, " +
                                    "K01F03 " +
                                "FROM " +
                                    "STK01";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    // Executing the query to fetch stock entries
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Creating stock entry objects from the retrieved data
                            STK01 stockEntry = new STK01
                            {
                                K01F01 = reader.GetInt32("K01F01"), // StockId
                                K01F02 = reader.GetInt32("K01F02"), // ProductId
                                K01F03 = reader.GetInt32("K01F03") // Quantity
                            };
                            stockEntries.Add(stockEntry); // Adding stock entry to the list
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching stock entries: " + ex.Message);
                }
            }

            return stockEntries;
        }

        /// <summary>
        /// Adds a new stock entry to the database.
        /// </summary>
        /// <param name="objSTK01">Stock entry object to add.</param>
        /// <returns>True if the stock entry is added successfully, otherwise false.</returns>
        public bool AddStockEntry(STK01 objSTK01)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO " +
                                        "STK01 " +
                                            "(K01F02, " +
                                            "K01F03) " +
                                         "VALUES " +
                                            "(@ProductId, " +
                                            "@Quantity)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", objSTK01.K01F02);
                command.Parameters.AddWithValue("@Quantity", objSTK01.K01F03);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the insertion query
                    return rowsAffected > 0; // Returning true if rows were affected, indicating success
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding stock entry: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Updates the quantity of an existing stock entry in the database.
        /// </summary>
        /// <param name="stockId">ID of the stock entry to update.</param>
        /// <param name="quantity">New quantity value.</param>
        /// <returns>True if the stock entry is updated successfully, otherwise false.</returns>
        public bool UpdateStockEntry(int stockId, int quantity)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE " +
                                    "STK01 " +
                               "SET " +
                                    "K01F03 = @Quantity " +
                               "WHERE " +
                                    "K01F01 = @StockId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@StockId", stockId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the update query
                    return rowsAffected > 0; // Returning true if rows were affected, indicating success
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating stock entry quantity: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Deletes a stock entry from the database.
        /// </summary>
        /// <param name="stockId">ID of the stock entry to delete.</param>
        /// <returns>True if the stock entry is deleted successfully, otherwise false.</returns>
        public bool DeleteStockEntry(int stockId)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE " +
                                "FROM " +
                                    "STK01 " +
                                "WHERE " +
                                    "K01F01 = @StockId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@StockId", stockId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the deletion query
                    return rowsAffected > 0; // Returning true if rows were affected, indicating success
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting stock entry: " + ex.Message);
                }
            }
        }

        #endregion
    }
}