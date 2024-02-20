using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing transactions.
    /// </summary>
    public class BLTransaction
    {
        // Connection string to the database
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // App data folder path
        static string appDataFolderPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

        // Path to save the JSON file
        string filePath = Path.Combine(appDataFolderPath, "transactions.json");

        /// <summary>
        /// Retrieves all transactions from the database.
        /// </summary>
        /// <returns>A list of transactions.</returns>
        public List<TRA01> GetAllTransactions()
        {
            List<TRA01> transactions = new List<TRA01>(); // List to store transactions

            using (MySqlConnection connection = new MySqlConnection(_connectionString)) // Creating a MySqlConnection object
            {
                string query = @"SELECT T.A01F01, T.A01F02, T.A01F03, T.A01F04, T.A01F05, T.A01F06, 
                                P.D01F02 
                         FROM TRA01 AS T
                         JOIN PRD01 AS P ON T.A01F02 = P.D01F01"; // SQL query to retrieve transactions along with product details
                MySqlCommand command = new MySqlCommand(query, connection); // Creating a MySqlCommand object

                try
                {
                    connection.Open(); // Opening the database connection
                    using (MySqlDataReader reader = command.ExecuteReader()) // Executing the SQL command
                    {
                        while (reader.Read()) // Looping through the result set
                        {
                            TRA01 transaction = new TRA01 // Creating a new transaction object
                            {
                                A01F01 = reader.GetInt32("A01F01"), // Setting transaction ID
                                A01F02 = reader.GetInt32("A01F02"), // Setting product ID
                                ProductName = reader.GetString("D01F02"), // Setting product name
                                A01F03 = (TransactionType)Enum.Parse(typeof(TransactionType), reader.GetString("A01F03")), // Setting transaction type
                                A01F04 = reader.GetDateTime("A01F04"), // Setting transaction date
                                A01F05 = reader.GetInt32("A01F05"), // Setting quantity
                                A01F06 = reader.GetDecimal("A01F06") // Setting net price
                            };
                            transactions.Add(transaction); // Adding the transaction to the list
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching transactions: " + ex.Message);
                }
            }

            return transactions; // Returning the list of transactions
        }

        /// <summary>
        /// Inserts a new transaction into the database.
        /// </summary>
        /// <param name="objTRA01">The transaction object to insert.</param>
        /// <returns>True if the transaction is successfully inserted, otherwise false.</returns>
        public bool InsertTransaction(TRA01 objTRA01)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Open the connection before beginning the transaction

                // Calculate net price
                decimal unitPrice = GetUnitPrice(objTRA01.A01F02); // Getting the unit price of the product
                int productCount = objTRA01.A01F05; // Getting the quantity of the product
                decimal netPrice = CalculateNetPrice(unitPrice, productCount); // Calculating the net price

                // Begin a transaction
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    string query = "INSERT INTO " +
                                        "TRA01 (" +
                                            "A01F02, " +
                                            "A01F03, " +
                                            "A01F04, " +
                                            "A01F05, " +
                                            "A01F06) " +
                                     "VALUES (" +
                                            "@ProductId, " +
                                            "@TransactionType, " +
                                            "@TransactionDate, " +
                                            "@Quantity, " +
                                            "@NetPrice)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductId", objTRA01.A01F02);
                    command.Parameters.AddWithValue("@TransactionType", objTRA01.A01F03.ToString());
                    command.Parameters.AddWithValue("@TransactionDate", objTRA01.A01F04);
                    command.Parameters.AddWithValue("@Quantity", objTRA01.A01F05);
                    command.Parameters.AddWithValue("@NetPrice", netPrice);

                    try
                    {
                        //connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update product quantity in PRD01 table
                            if (UpdateProductQuantity(connection, objTRA01.A01F02, objTRA01.A01F05, objTRA01.A01F03, transaction))
                            {
                                transaction.Commit(); // Commit the transaction if both inserts succeed
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error adding transaction: " + ex.Message);
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Generates a JSON file containing all transactions.
        /// </summary>
        public void GenerateTransactionJsonFile()
        {
            List<TRA01> transactions = GetAllTransactions();

            // Serialize transactions to JSON
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);

            // Write JSON to file
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Retrieves the unit price of a product from the database.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <returns>The unit price of the product.</returns>
        private decimal GetUnitPrice(int productId)
        {
            decimal unitPrice = 0;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT D01F04 FROM PRD01 WHERE D01F01 = @ProductId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    // Checking if the result is not null
                    if (result != null && result != DBNull.Value)
                    {
                        // Converting the result to decimal and assigning it to unitPrice
                        unitPrice = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    // Handling any exceptions
                    Console.WriteLine("Error retrieving unit price: " + ex.Message);
                }
            }

            return unitPrice;
        }

        /// <summary>
        /// Calculates the net price of a transaction.
        /// </summary>
        /// <param name="unitPrice">The unit price of the product.</param>
        /// <param name="productCount">The quantity of the product.</param>
        /// <returns>The net price of the transaction.</returns>
        private decimal CalculateNetPrice(decimal unitPrice, int productCount)
        {
            // Implement logic to calculate net price using the unit price and transaction count
            decimal netPrice = unitPrice * productCount;

            return netPrice;
        }

        /// <summary>
        /// Update product quantity based on transaction type.
        /// </summary>
        /// <param name="connection">The MySqlConnection object.</param>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="quantity">The quantity to update.</param>
        /// <param name="transactionType">The type of transaction (Sale or Purchase).</param>
        /// <param name="transaction">The MySqlTransaction object.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
        private bool UpdateProductQuantity(MySqlConnection connection, int productId, int quantity, TransactionType transactionType, MySqlTransaction transaction)
        {
            string updateQuery = "";
            if (transactionType == TransactionType.Sale)
            {
                // For sale transactions, decrease the product quantity
                updateQuery = "UPDATE " +
                                "PRD01 " +
                             "SET " +
                                "D01F10 = D01F10 - @Quantity " +
                             "WHERE " +
                                "D01F01 = @ProductId AND D01F10 >= @Quantity";
            }
            else if (transactionType == TransactionType.Purchase)
            {
                // For purchase transactions, increase the product quantity
                updateQuery = "UPDATE " +
                                "PRD01 " +
                             "SET " +
                                "D01F10 = D01F10 + @Quantity " +
                             "WHERE " +
                                "D01F01 = @ProductId";
            }

            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection, transaction);
            updateCommand.Parameters.AddWithValue("@Quantity", quantity);
            updateCommand.Parameters.AddWithValue("@ProductId", productId);

            try
            {
                int rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to update product quantity. No rows affected.");
                    transaction.Rollback(); // Rollback the transaction if no rows were affected
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating product quantity: " + ex.Message);
                transaction.Rollback(); // Rollback the transaction if an error occurs
                return false;
            }
        }
    }
}