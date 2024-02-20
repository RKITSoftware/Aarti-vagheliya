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
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

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
                                     "D01F04 AS UnitPrice, " +
                                     "D01F05 AS SupplierID, " +
                                     "D01F06 AS Description, " +
                                     "D01F07 AS DateAdded, " +
                                     "D01F08 AS Brand, " +
                                     "D01F09 AS DateRemoved, " +
                                     "D01F10 AS Count " +
                               "FROM " +
                                    "PRD01";
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PRD01 product = new PRD01
                    {
                        D01F01 = Convert.ToInt32(reader["ProductID"]),
                        D01F02 = Convert.ToString(reader["ProductName"]),
                        D01F03 = Convert.ToInt32(reader["CategoryID"]),
                        D01F04 = Convert.ToDecimal(reader["UnitPrice"]),
                        D01F05 = Convert.ToInt32(reader["SupplierID"]),
                        D01F06 = Convert.ToString(reader["Description"]),
                        D01F07 = Convert.ToDateTime(reader["DateAdded"]),
                        D01F08 = Convert.ToString(reader["Brand"]),
                        D01F09 = Convert.ToDateTime(reader["DateRemoved"]),
                        D01F10 = Convert.ToInt32(reader["Count"])
                    };
                    products.Add(product);
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
                                            "D01F06, " +
                                            "D01F07, " +
                                            "D01F08, " +
                                            "D01F09, " +
                                            "D01F10) " +
                                    "VALUES " +
                                            "(@ProductName, " +
                                            "@CategoryID, " +
                                            "@UnitPrice, " +
                                            "@SupplierID, " +
                                            "@Description, " +
                                            "@DateAdded, " +
                                            "@Brand, " +
                                            "@DateRemoved, " +
                                            "@Count)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", objPRD01.D01F02);
                command.Parameters.AddWithValue("@CategoryID", objPRD01.D01F03);
                command.Parameters.AddWithValue("@UnitPrice", objPRD01.D01F04);
                command.Parameters.AddWithValue("@SupplierID", objPRD01.D01F05);
                command.Parameters.AddWithValue("@Description", objPRD01.D01F06);
                command.Parameters.AddWithValue("@DateAdded", objPRD01.D01F07);
                command.Parameters.AddWithValue("@Brand", objPRD01.D01F08);
                command.Parameters.AddWithValue("@DateRemoved", objPRD01.D01F09);
                command.Parameters.AddWithValue("@Count", objPRD01.D01F10);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
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
                                   "D01F04 = @UnitPrice, " +
                                   "D01F05 = @SupplierID, " +
                                   "D01F06 = @Description, " +
                                   "D01F07 = @DateAdded, " +
                                   "D01F08 = @Brand, " +
                                   "D01F09 = @DateRemoved, " +
                                   "D01F10 = @Count " +
                               "WHERE D01F01 = @ProductID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@ProductName", objPRD01.D01F02);
                command.Parameters.AddWithValue("@CategoryID", objPRD01.D01F03);
                command.Parameters.AddWithValue("@UnitPrice", objPRD01.D01F04);
                command.Parameters.AddWithValue("@SupplierID", objPRD01.D01F05);
                command.Parameters.AddWithValue("@Description", objPRD01.D01F06);
                command.Parameters.AddWithValue("@DateAdded", objPRD01.D01F07);
                command.Parameters.AddWithValue("@Brand", objPRD01.D01F08);
                command.Parameters.AddWithValue("@DateRemoved", objPRD01.D01F09);
                command.Parameters.AddWithValue("@Count", objPRD01.D01F10);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
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

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Updates the brand of a product in the database.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="brand">The new brand name.</param>
        /// <returns>True if the product brand is successfully updated, otherwise false.</returns>
        public bool UpdateProductBrand(int productId, string brand)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE " +
                                    "PRD01 " +
                                "SET " +
                                   "D01F08 = @Brand " +
                               "WHERE D01F01 = @ProductID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@Brand", brand);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error updating product brand: " + ex.Message);
                    return false;
                }
            }
        }

    }
}