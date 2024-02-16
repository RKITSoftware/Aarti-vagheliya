using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    public class BLTransaction
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public List<TRA01> GetAllTransactions()
        {
            List<TRA01> transactions = new List<TRA01>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT A01F01, A01F02, A01F03, A01F04, A01F05, A01F06 FROM TRA01";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TRA01 transaction = new TRA01
                            {
                                A01F01 = reader.GetInt32("A01F01"),
                                A01F02 = reader.GetInt32("A01F02"),
                                A01F03 = reader.GetString("A01F03"),
                                A01F04 = reader.GetDateTime("A01F04"),
                                A01F05 = reader.GetInt32("A01F05"),
                                A01F06 = reader.GetDecimal("A01F06")
                            };
                            transactions.Add(transaction);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching transactions: " + ex.Message);
                }
            }

            return transactions;
        }

        public bool InsertTransaction(TRA01 transaction)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO TRA01 (A01F02, A01F03, A01F04, A01F05, A01F06) VALUES (@ProductId, @TransactionType, @TransactionDate, @Quantity, @TotalAmount)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", transaction.A01F02);
                command.Parameters.AddWithValue("@TransactionType", transaction.A01F03);
                command.Parameters.AddWithValue("@TransactionDate", transaction.A01F04);
                command.Parameters.AddWithValue("@Quantity", transaction.A01F05);
                command.Parameters.AddWithValue("@TotalAmount", transaction.A01F06);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding transaction: " + ex.Message);
                    return false;
                }
            }
        }
    }
}