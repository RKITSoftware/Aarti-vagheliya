using CRUD_Operation.Models.POCO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CRUD_Operation.DataBase
{
    /// <summary>
    /// Data access class for CRUD operations related to fruits in the database.
    /// </summary>
    public class DBFRT01
    {
        #region Private Member

        /// <summary>
        /// Establish connection with database
        /// </summary>
        private readonly string _connectionString = @"server=127.0.0.1; user id=Admin; password=gs@123; database=FruitDemo";

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks if a table of the given type exists in the database.
        /// </summary>
        /// <param name="type">Type representing the table.</param>
        /// <returns>Returns true if the table exists; otherwise, false.</returns>
        public bool TableExists(Type type)
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);

                string query = string.Format(@"SHOW TABLES LIKE 
                                                '{0}'"
                                            , type.Name);

                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();

                return false;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        /// <summary>
        /// Creates the fruit table in the database if it does not exist.
        /// </summary>
        /// <returns>Returns a message indicating the result of the table creation.</returns>
        public string CreateTable()
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);

                // SQL query to create the table if it does not exist
                string tableName = "FRT01";
                string query = string.Format(@"CREATE TABLE IF NOT EXISTS {0} 
                                               (
                                                    T01F01 INT PRIMARY KEY AUTO_INCREMENT,
                                                    T01F02 VARCHAR(50) NOT NULL,
                                                    T01F03 VARCHAR(50), 
                                                    T01F04 DECIMAL(18,2) 
                                               )", tableName);

                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);

                // Open the database connection
                connection.Open();

                // Execute the query to create the table
                command.ExecuteNonQuery();
                return "Table created successfully.";
            }
            catch (MySqlException ex)
            {
                // Display error message if table creation fails
                return string.Format($"Error while creating table: {0}", ex.Message);
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

        /// <summary>
        /// Inserts a new fruit record into the database.
        /// </summary>
        /// <param name="objFRT01">The fruit object to insert.</param>
        /// <returns>Returns a message indicating the result of the insertion operation.</returns>
        public string AddFruit(FRT01 objFRT01)
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);

                // SQL query to insert a new fruit into the table
                string query = string.Format(@"INSERT INTO FRT01 (T01F02,T01F03,T01F04)
                                                          VALUES ('{0}','{1}',{2})",
                                                             objFRT01.T01F02,
                                                             objFRT01.T01F03,
                                                             objFRT01.T01F04);

                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);

                // Open the database connection
                connection.Open();

                // Execute the query to insert the fruit
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return "success";
                else
                    return "Failed to add fruit!";
            }
            catch (MySqlException ex)
            {
                // Display error message if fruit addition fails
                return string.Format(@"Error while adding fruit: {0}", ex.Message);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Retrieves all fruit records from the database.
        /// </summary>
        /// <returns>Returns a list of all fruit records.</returns>
        public List<FRT01> GetAllFruits()
        {
            List<FRT01> fruits = new List<FRT01>();
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);

                // SQL query to select all fruits from the table
                string query = string.Format(@"SELECT 
                                                    T01F01,
                                                    T01F02,
                                                    T01F03,
                                                    T01F04
                                                FROM 
                                                    FRT01");

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
                throw new Exception("Error getting all fruits: " + ex.Message);
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

        /// <summary>
        /// Updates an existing fruit record in the database.
        /// </summary>
        /// <param name="id">The ID of the fruit to update.</param>
        /// <param name="objFRT01">The updated fruit object.</param>
        /// <returns>Returns a message indicating the result of the update operation.</returns>
        public string UpdateFruit( FRT01 objFRT01)
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);
           
                // SQL query to update the fruit price
                string query = string.Format(@"UPDATE
                                                    FRT01 
                                               SET
                                                    T01F02 = '{0}',
                                                    T01F03 = '{1}',
                                                    T01F04 = {2}
                                               WHERE 
                                                    T01F01 = {3}"
                                                    ,objFRT01.T01F02, objFRT01.T01F03, objFRT01.T01F04, objFRT01.T01F01);
                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);

                // Open the database connection
                connection.Open();

                // Execute the query to update the fruit price
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return "success";
                else
                    return "Failed to update fruit!";
            }
            catch (MySqlException ex)
            {
                // Display error message if updating fruit fails
                return string.Format(@"Error updating fruit: {0}", ex.Message);

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

        /// <summary>
        /// Deletes a fruit record from the database.
        /// </summary>
        /// <param name="id">The ID of the fruit to delete.</param>
        /// <returns>Returns a message indicating the result of the deletion operation.</returns>
        public string DeleteFruit(int id)
        {
            MySqlConnection connection = null;
            try
            {
                // Establish a connection to the database
                connection = new MySqlConnection(_connectionString);

                // SQL query to delete a fruit from the table
                string query = string.Format(@"DELETE 
                                               FROM 
                                                    FRT01 
                                               WHERE 
                                                    T01F01 = {0}", id);

                // Create a MySqlCommand object to execute the query
                MySqlCommand command = new MySqlCommand(query, connection);

                // Open the database connection
                connection.Open();

                // Execute the query to delete the fruit
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    return "success";
                else
                    return "Failed to delete fruit!";
            }
            catch (MySqlException ex)
            {
                // Display error message if deleting fruit fails
                return string.Format(@"Error deleting fruit: {0}", ex.Message);

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