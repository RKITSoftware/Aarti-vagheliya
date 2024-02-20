using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Business logic class for managing categories.
    /// </summary>
    public class BLCategory
    {
        // Connection string for accessing the database
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        /// <summary>
        /// Retrieves all categories from the database.
        /// </summary>
        /// <returns>List of categories.</returns>
        public List<CAT01> GetAllCategories()
        {
            List<CAT01> categories = new List<CAT01>();

            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT T01F01, T01F02 FROM CAT01";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    // Executing the query to fetch categories
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Creating category objects from the retrieved data
                            CAT01 category = new CAT01
                            {
                                T01F01 = reader.GetInt32("T01F01"),
                                T01F02 = reader.GetString("T01F02")
                            };
                            categories.Add(category); // Adding category to the list
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching categories: " + ex.Message);
                }
            }

            return categories;
        }

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="objCAT01">Category object to add.</param>
        /// <returns>True if the category is added successfully, otherwise false.</returns>
        public bool AddCategory(CAT01 objCAT01)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO CAT01 " +
                                                "(T01F01, T01F02) " +
                                          "VALUES (@CategoryID, @CategoryName)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryID", objCAT01.T01F01);
                command.Parameters.AddWithValue("@CategoryName", objCAT01.T01F02);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the insertion query
                    return rowsAffected > 0; // Returning true if rows were affected, indicating success
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding category: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates an existing category in the database.
        /// </summary>
        /// <param name="categoryId">ID of the category to update.</param>
        /// <param name="objCAT01">Updated category object.</param>
        /// <returns>True if the category is updated successfully, otherwise false.</returns>
        public bool UpdateCategory(int categoryId, CAT01 objCAT01)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE CAT01 " +
                                "SET T01F02 = @NewCategoryName " +
                                "WHERE T01F01 = @CategoryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewCategoryName", objCAT01.T01F02);
                command.Parameters.AddWithValue("@CategoryID", categoryId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the update query
                    return rowsAffected > 0; // Returning true if rows were affected, indicating success
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating category: " + ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Deletes a category from the database.
        /// </summary>
        /// <param name="categoryId">ID of the category to delete.</param>
        /// <returns>True if the category is deleted successfully, otherwise false.</returns>
        public bool DeleteCategory(int categoryId)
        {
            // Establishing a connection to the database
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE " +
                                    "FROM " +
                                        "CAT01 " +
                                    "WHERE " +
                                        "T01F01 = @CategoryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Executing the deletion query
                    return rowsAffected > 0; // Returning true if rows were affected, indicating success
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting category: " + ex.Message);
                    return false;
                }
            }
        }
    }
}