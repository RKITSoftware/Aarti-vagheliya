using FinalDemo_Advance_C_.Models.POCO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace FinalDemo_Advance_C_.DataBase
{
    /// <summary>
    /// Provides data access methods for the PRD01 table related to products.
    /// </summary>
    public class DBPRD01Context
    {
        #region Private member

        /// <summary>
        /// Connection string for accessing the database.
        /// </summary>
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A DataTable containing the retrieved products.</returns>
        public DataTable GetAllProducts()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // SQL query to fetch product details
                string query = @"SELECT 
                            D01F01 AS ProductID,
                            D01F02 AS ProductName,
                            D01F03 AS CategoryID, 
                            D01F04 AS Description, 
                            D01F05 AS PurchasePrice, 
                            D01F06 AS SellingPrice   
                         FROM 
                            PRD01";

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
                    throw new Exception("Error fetching products: " + ex.Message);
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Adds a new product to the PRD01 table.
        /// </summary>
        /// <param name="objPRD01">The product to add.</param>
        /// <returns>Success message or error message.</returns>
        public string AddProduct(PRD01 objPRD01)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // SQL query to insert a new product
                string query = string.Format(@"INSERT INTO 
                                                        PRD01 
                                                            (D01F02, 
                                                            D01F03, 
                                                            D01F04, 
                                                            D01F05, 
                                                            D01F06) 
                                                        VALUES 
                                                            ('{0}',
                                                              {1},
                                                             '{2}',
                                                              {3}, 
                                                              {4} )",
                                                            objPRD01.D01F02,
                                                            objPRD01.D01F03,
                                                            objPRD01.D01F04,
                                                            objPRD01.D01F05,
                                                            objPRD01.D01F06);
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return "Success";
                    else
                        return "Failed to Add new Product.";
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error in Inserting Product : {ex.Message}");
                }

            }
        }
        /// <summary>
        /// Updates an existing product in the PRD01 table.
        /// </summary>
        /// <param name="objPRD01">The product to update.</param>
        /// <returns>Success message or error message.</returns>
        public string UpdateProduct( PRD01 objPRD01)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"UPDATE 
                                                    PRD01 
                                                SET 
                                                   D01F02 = '{0}', 
                                                   D01F03 = {1}, 
                                                   D01F04 = '{2}', 
                                                   D01F05 = {3}, 
                                                   D01F06 = {4} 
                                               WHERE D01F01 = {5}",
                                               objPRD01.D01F02,
                                               objPRD01.D01F03,
                                               objPRD01.D01F04,
                                               objPRD01.D01F05,
                                               objPRD01.D01F06,
                                               objPRD01.D01F01);
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return "Success";
                    else
                        return "Failed to update Product details.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating product: " + ex.Message);

                }

            }
        }

        /// <summary>
        /// Deletes a product from the PRD01 table.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>Success message or error message.</returns>
        public string DeleteProduct(int productId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // SQL query to delete a product
                string query = string.Format(@"DELETE
                                               FROM 
                                                    PRD01 
                                                WHERE 
                                                    D01F01 = {0}", productId);

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        return "Success";
                    else
                        return "Failed to Delete product.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting product: " + ex.Message);
                }

            }
        }

        /// <summary>
        /// Retrieves products along with their category names from the PRD01 and CAT01 tables.
        /// </summary>
        /// <returns>List of products with category names.</returns>
        public dynamic DisplayProducts()
        {
            List<object> products = new List<object>();

            // Establish database connection
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // SQL query to retrieve product details with category information
                string query = string.Format(@"SELECT 
                                                    D01.D01F01 AS ProductID, 
                                                    D01.D01F02 AS ProductName, 
                                                    T01.T01F02 AS CategoryName, 
                                                    D01.D01F04 AS Description, 
                                                    D01.D01F06 AS Price 
                                              FROM 
                                                   PRD01 AS D01 
                                              JOIN 
                                                    CAT01 AS T01 ON D01.D01F03 = T01.T01F01");

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