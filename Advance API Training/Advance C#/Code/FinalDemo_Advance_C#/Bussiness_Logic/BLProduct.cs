using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing product operations.
    /// </summary>
    public class BLProduct
    {
        #region Private member

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of all products.</returns>
        public List<PRD01> GetAllProducts()
        {
            List<PRD01> products = new List<PRD01>();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT " +
                                     "D01F01 AS ProductID, " +
                                     "D01F02 AS ProductName, " +
                                     "D01F03 AS CategoryID, " +
                                     "D01F04 AS Description, " +
                                     "D01F05 AS PurchasePrice, " +
                                     "D01F06 AS SellingPrice " +   
                               "FROM " +
                                    "PRD01";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        PRD01 product = new PRD01
                        {
                            D01F01 = Convert.ToInt32(reader["ProductID"]),
                            D01F02 = Convert.ToString(reader["ProductName"]),
                            D01F03 = Convert.ToInt32(reader["CategoryID"]),
                            D01F04 = Convert.ToString(reader["Description"]),
                            D01F05 = Convert.ToDecimal(reader["PurchasePrice"]),
                            D01F06 = Convert.ToDecimal(reader["SellingPrice"])
                        };
                        products.Add(product);
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("Error fetching products: " + ex.Message);
                }
                
            }
            return products;
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="objPRD01">The product to add.</param>
        /// <returns>True if the product is successfully added, otherwise false.</returns>
        public bool AddProduct(PRD01 objPRD01)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO " +
                                        "PRD01 " +
                                            "(D01F02, " +
                                            "D01F03, " +
                                            "D01F04, " +
                                            "D01F05, " +
                                            "D01F06) " +
                                    "VALUES " +
                                            "(@ProductName, " +
                                            "@CategoryID, " +
                                            "@Description, " +
                                            "@PurchasePrice, " +
                                            "@SellingPrice )";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", objPRD01.D01F02);
                command.Parameters.AddWithValue("@CategoryID", objPRD01.D01F03);
                command.Parameters.AddWithValue("@Description", objPRD01.D01F04);
                command.Parameters.AddWithValue("@PurchasePrice", objPRD01.D01F05);
                command.Parameters.AddWithValue("@SellingPrice", objPRD01.D01F06);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch(Exception ex)
                {
                    throw new Exception($"Error in Inserting Product : {ex.Message}");
                }
               
            }
        }

        /// <summary>
        /// Updates an existing product in the database.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="objPRD01">The updated product data.</param>
        /// <returns>True if the product is successfully updated, otherwise false.</returns>
        public bool UpdateProduct(int productId, PRD01 objPRD01)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE " +
                                    "PRD01 " +
                                "SET " +
                                   "D01F02 = @ProductName, " +
                                   "D01F03 = @CategoryID, " +
                                   "D01F04 = @Description, " +
                                   "D01F05 = @PurchasePrice, " +
                                   "D01F06 = @SellingPrice " +
                               "WHERE D01F01 = @ProductID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@ProductName", objPRD01.D01F02);
                command.Parameters.AddWithValue("@CategoryID", objPRD01.D01F03);
                command.Parameters.AddWithValue("@Description", objPRD01.D01F04);
                command.Parameters.AddWithValue("@PurchasePrice", objPRD01.D01F05);
                command.Parameters.AddWithValue("@SellingPrice", objPRD01.D01F06);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating product: " + ex.Message);

                }

            }
        }

        /// <summary>
        /// Deletes a product from the database.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>True if the product is successfully deleted, otherwise false.</returns>
        public bool DeleteProduct(int productId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE " +
                                "FROM " +
                                    "PRD01 " +
                                "WHERE " +
                                    "D01F01 = @ProductID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting product: " + ex.Message);
                }

            }
        }

        /// <summary>
        /// Retrieves product details including ID, name, category, description, and price.
        /// </summary>
        /// <returns>A dynamic collection containing product details.</returns>
        public dynamic DisplayProducts()
        {
            List<object> products = new List<object>();

            // Establish database connection
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // Define SQL query to retrieve product details along with category information
                string query = "SELECT " +
                                    "P.D01F01 AS ProductID, " +
                                    "P.D01F02 AS ProductName, " +
                                    "C.T01F02 AS CategoryName, " +
                                    "P.D01F04 AS Description, " +
                                    "P.D01F06 AS Price " +
                              "FROM " +
                                   "PRD01 AS P " +
                                   "JOIN CAT01 AS C ON P.D01F03 = C.T01F01";

                // Create MySqlCommand object
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    // Open database connection
                    connection.Open();

                    // Execute SQL query and get data reader
                    MySqlDataReader dataReader = command.ExecuteReader();

                    // Iterate through each row of the data reader
                    while (dataReader.Read())
                    {
                        // Add product details to the list
                        products.Add(new
                        {
                            ProductID = dataReader[0],
                            ProductName = dataReader[1],
                            CategoryName = dataReader[2],
                            Description = dataReader[3],
                            Price = dataReader[4],
                        });
                    }

                    // Close the data reader
                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    // Throw an exception if an error occurs
                    throw new Exception($"Error in Displaying Products: {ex.Message}");
                }

                // Return the list of products
                return products;
            }
        }


        #endregion
    }
}