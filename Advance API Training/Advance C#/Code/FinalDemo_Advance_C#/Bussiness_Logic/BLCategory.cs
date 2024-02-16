using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    public class BLCategory
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

       

        public List<CAT01> GetAllCategories()
        {
            List<CAT01> categories = new List<CAT01>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT T01F01, T01F02 FROM CAT01";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CAT01 category = new CAT01
                            {
                                T01F01 = reader.GetInt32("T01F01"),
                                T01F02 = reader.GetString("T01F02")
                            };
                            categories.Add(category);
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

        public bool AddCategory(CAT01 objCAT01)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO CAT01 (T01F01, T01F02) VALUES (@CategoryID, @CategoryName)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryID", objCAT01.T01F01);
                command.Parameters.AddWithValue("@CategoryName", objCAT01.T01F02);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding category: " + ex.Message);
                    return false;
                }
            }
        }



        public bool UpdateCategory(int categoryId, CAT01 objCAT01)
        {
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
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating category: " + ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM CAT01 WHERE T01F01 = @CategoryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
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