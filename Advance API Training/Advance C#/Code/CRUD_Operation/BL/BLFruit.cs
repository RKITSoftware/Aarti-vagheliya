using CRUD_Operation.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CRUD_Operation.BL
{
    /// <summary>
    /// Business logic class for performing CRUD operations on fruits.
    /// </summary>
    public class BLFruit
    {
        //Establish connection with database
        private static string _connectionString = @"server=127.0.0.1; user id=Admin; password=gs@123; database=FruitDemo";

        #region CreateTable

        /// <summary>
        /// Creates the table in the database for storing fruits.
        /// </summary>
        /// <returns>True if table creation is successful, otherwise false.</returns>
        public bool CreateTable()
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);

                // SQL query to create the table if it does not exist
                string query = "CREATE TABLE IF NOT EXISTS FRT01 " +
                               "(" +
                                   " T01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT 'Fruit id'," +
                                   " T01F02 VARCHAR(50) NOT NULL COMMENT 'Fruit Name'," +
                                   " T01F03 VARCHAR(50) COMMENT 'Fruit Color', " +
                                   " T01F04 DECIMAL(18,2) COMMENT 'Price'" +
                               ")";
                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);

                // Open the database connection
                connection.Open();

                // Execute the query to create the table
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                // Display error message if table creation fails
                Console.WriteLine("Error creating table: " + ex.Message);
                return false;
            }
            finally
            {
                // Close the database connection in all cases
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region AddFruit

        /// <summary>
        /// Adds a new fruit to the database.
        /// </summary>
        /// <param name="objFRT01">The fruit object to be added.</param>
        /// <returns>True if the fruit is added successfully, otherwise false.</returns>
        public bool AddFruit(FRT01 objFRT01)
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);

                // SQL query to insert a new fruit into the table
                string query = "INSERT INTO FRT01 " +
                                            "(T01F02, " +
                                            "T01F03, " +
                                            "T01F04) " +
                                     "VALUES (@Name, " +
                                             "@Color, " +
                                             "@Price)";

                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);

                // Set parameter values for the fruit object
                command.Parameters.AddWithValue("@Name", objFRT01.T01F02);
                command.Parameters.AddWithValue("@Color", objFRT01.T01F03);
                command.Parameters.AddWithValue("@Price", objFRT01.T01F04);

                // Open the database connection
                connection.Open();

                // Execute the query to insert the fruit
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                // Display error message if fruit addition fails
                Console.WriteLine("Error adding fruit: " + ex.Message);
                return false;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region GetAllFruits

        /// <summary>
        /// Retrieves all fruits from the database.
        /// </summary>
        /// <returns>An enumerable collection of fruits.</returns>
        public IEnumerable<FRT01> GetAllFruits()
        {
            List<FRT01> fruits = new List<FRT01>();
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);

                // SQL query to select all fruits from the table
                string query = "SELECT * FROM FRT01";

                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);

                // Open the database connection
                connection.Open();

                // Execute the query and read the results
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Iterate through the results and populate the fruit list
                    while (reader.Read())
                    {
                        FRT01 fruit = new FRT01
                        {
                            // Populate the fruit object properties from the query results
                            T01F01 = reader.GetInt32(0),
                            T01F02 = reader.GetString(1),
                            T01F03 = reader.GetString(2),
                            T01F04 = reader.GetDecimal(3)
                        };
                        fruits.Add(fruit);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error getting all fruits: " + ex.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            // Return the list of fruits
            return fruits;
        }


        #endregion

        #region UpdateFruit

        /// <summary>
        /// Updates the price of a fruit in the database.
        /// </summary>
        /// <param name="id">The ID of the fruit to be updated.</param>
        /// <param name="objFRT01">The updated fruit object.</param>
        /// <returns>True if the fruit price is updated successfully, otherwise false.</returns>
        public bool UpdateFruit(int id, FRT01 objFRT01)
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);
                // SQL query to update the fruit price
                string query = "UPDATE FRT01 " +
                               "SET T01F02 = @Name," +
                                   "T01F03 = @Color," +
                                   "T01F04 = @Price " +
                               "WHERE T01F01 = @Id";
                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);

                // Set parameter values for the update operation
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", objFRT01.T01F02);
                command.Parameters.AddWithValue("@Color", objFRT01.T01F03);
                command.Parameters.AddWithValue("@Price", objFRT01.T01F04);

                // Open the database connection
                connection.Open();
                // Execute the query to update the fruit price
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                // Display error message if updating fruit fails
                Console.WriteLine("Error updating fruit: " + ex.Message);
                return false;
            }
            finally
            {
                // Close the database connection in all cases
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region DeleteFruit

        /// <summary>
        /// Deletes a fruit from the database.
        /// </summary>
        /// <param name="id">The ID of the fruit to be deleted.</param>
        /// <returns>True if the fruit is deleted successfully, otherwise false.</returns>
        public bool DeleteFruit(int id)
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);
                // SQL query to delete a fruit from the table
                string query = "DELETE " +
                               "FROM FRT01 " +
                               "WHERE T01F01 = @Id";
                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);
                // Set parameter value for the delete operation
                command.Parameters.AddWithValue("@Id", id);

                // Open the database connection
                connection.Open();
                // Execute the query to delete the fruit
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (MySqlException ex)
            {
                // Display error message if deleting fruit fails
                Console.WriteLine("Error deleting fruit: " + ex.Message);
                return false;
            }
            finally
            {
                // Close the database connection in all cases
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        #endregion

    }
}