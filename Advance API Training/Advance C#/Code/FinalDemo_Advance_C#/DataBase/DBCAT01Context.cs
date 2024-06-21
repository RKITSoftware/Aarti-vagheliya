using FinalDemo_Advance_C_.Models.POCO;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace FinalDemo_Advance_C_.DataBase
{
    /// <summary>
    /// Provides data access methods for the CAT01 table.
    /// </summary>
    public class DBCAT01Context
    {
        #region Private Member

        /// <summary>
        /// Initialize connection to the database.
        /// </summary>
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all categories from the database.
        /// </summary>
        /// <returns>A DataTable containing the retrieved categories.</returns>
        public DataTable GetAllCategories()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT 
                                    T01F01,
                                    T01F02, 
                                    T01F03 
                                 FROM 
                                    CAT01";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                try
                {
                    connection.Open();

                    // Fill the DataTable with data from the database
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching categories: " + ex.Message);
                }
            }

            return dataTable;
        }

        /// <summary> 
        /// Adds a new category to the CAT01 table.
        /// </summary>
        /// <param name="objCAT01">The category to add.</param>
        /// <returns>Success message or error message.</returns>
        public string AddCategory(CAT01 objCAT01)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"INSERT INTO 
                                                         CAT01 
                                                            ( T01F01,
                                                              T01F02,  
                                                              T01F03 ) 
                                                         VALUES 
                                                            ( {0}, 
                                                              '{1}', 
                                                              '{2}' )",
                                                              objCAT01.T01F01,
                                                              objCAT01.T01F02,
                                                              objCAT01.T01F03);
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the insertion query
                    if (rowsAffected > 0)
                        return "Success";
                    else
                        return "Failed to add ctegory";
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in Inserting Category : {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Updates an existing category in the CAT01 table.
        /// </summary>
        /// <param name="objCAT01">The category to update.</param>
        /// <returns>Success message or error message.</returns>
        public string UpdateCategory(CAT01 objCAT01)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"UPDATE 
                                                    CAT01 
                                               SET
                                                    T01F02 = '{0}', 
                                                    T01F03 = '{1}' 
                                               WHERE 
                                                    T01F01 = {2}",
                                                    objCAT01.T01F02,
                                                    objCAT01.T01F03,
                                                    objCAT01.T01F01);
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the update query
                    if (rowsAffected > 0)
                        return "Success";
                    else
                        return "Failed to update Category";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating category: " + ex.Message);

                }
            }
        }

        /// <summary>
        /// Deletes a category from the CAT01 table.
        /// </summary>
        /// <param name="categoryId">The ID of the category to delete.</param>
        /// <returns>Success message or error message.</returns>
        public string DeleteCategory(int categoryId)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"DELETE 
                                                    FROM 
                                               CAT01 
                                                    WHERE 
                                               T01F01 = {0}",
                                               categoryId);
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the deletion query
                    if (rowsAffected > 0)
                        return "Success";
                    else
                        return "Failed to delete Category.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting category: " + ex.Message);
                }
            }
        }

        #endregion
    }

}