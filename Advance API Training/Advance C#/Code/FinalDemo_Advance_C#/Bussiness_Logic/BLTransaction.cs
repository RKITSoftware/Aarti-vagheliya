using FinalDemo_Advance_C_.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing transactions.
    /// </summary>
    public class BLTransaction
    {
        #region Private member

        // Connection string to the database
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // App data folder path
        private static string appDataFolderPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

        // Path to save the JSON file
        private string filePath = Path.Combine(appDataFolderPath, "transactions.json");

        #endregion

        #region Public Methods 

        /// <summary>
        /// Adds a new transaction to the database.
        /// </summary>
        /// <param name="transaction">The transaction to add.</param>
        /// <returns>True if the transaction is successfully added, otherwise false.</returns>
        public bool AddTransaction(TRA01 objTRA01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Open the connection before beginning the transaction

                // Calculate net price
                decimal unitPrice = GetUnitPrice(objTRA01.A01F02, objTRA01.A01F05); // Getting the unit price of the product
                int productCount = objTRA01.A01F07; // Getting the quantity of the product
                decimal netPrice = CalculateNetPrice(unitPrice, productCount); // Calculating the net price

                // Begin a transaction
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    string query = "INSERT INTO " +
                                            "TRA01 " +
                                               "(A01F02, " +
                                               " A01F03, " +
                                               " A01F04, " +
                                               " A01F05, " +
                                               " A01F06, " +
                                               " A01F07, " +
                                               " A01F08, " +
                                               " A01F09) " +
                                            "VALUES " +
                                                "(@ProductId, " +
                                               " @StockId, " +
                                               " @TransactionDate, " +
                                               " @TransactionType, " +
                                               " @ContactId, " +
                                               " @Quantity, " +
                                               " @NetPrice, " +
                                               " @Description)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductId", objTRA01.A01F02);
                    command.Parameters.AddWithValue("@StockId", objTRA01.A01F03);
                    command.Parameters.AddWithValue("@TransactionDate", objTRA01.A01F04);
                    command.Parameters.AddWithValue("@TransactionType", objTRA01.A01F05.ToString());
                    command.Parameters.AddWithValue("@ContactId", objTRA01.A01F06);
                    command.Parameters.AddWithValue("@Quantity", objTRA01.A01F07);
                    command.Parameters.AddWithValue("@NetPrice", netPrice);
                    command.Parameters.AddWithValue("@Description", objTRA01.A01F09);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update product quantity in PRD01 table
                            if (UpdateStockQuantity(connection, objTRA01.A01F03, objTRA01.A01F07, objTRA01.A01F05, transaction))
                            {
                                transaction.Commit(); // Commit the transaction if both inserts succeed
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error adding transaction: " + ex.Message);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Retrieves all transactions from the database.
        /// </summary>
        /// <returns>A list of all transactions.</returns>
        public List<TRA01> GetAllTransactions()
        {
            List<TRA01> transactions = new List<TRA01>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT " +
                                   "A01F01 AS TransactionID, " +
                                   "A01F02 AS ProductID, " +
                                   "A01F03 AS StockID, " +
                                   "A01F04 AS TransactionDate, " +
                                   "A01F05 AS TransactionType, " +
                                   "A01F06 AS ContactID, " +
                                   "A01F07 AS Quantity, " +
                                   "A01F08 AS NetPrice, " +
                                   "A01F09 AS Description " +
                               "FROM " +
                                    "TRA01";
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
                                A01F01 = reader.GetInt32("TransactionID"),
                                A01F02 = reader.GetInt32("ProductID"),
                                A01F03 = reader.GetInt32("StockID"),
                                A01F04 = reader.GetDateTime("TransactionDate"),
                                A01F05 = (enmTransactionType)Enum.Parse(typeof(enmTransactionType), reader.GetString("TransactionType")),
                                A01F06 = reader.GetInt32("ContactID"),
                                A01F07 = reader.GetInt32("Quantity"),
                                A01F08 = reader.GetDecimal("NetPrice"),
                                A01F09 = reader.GetString("Description")
                            };
                            transactions.Add(transaction);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching transactions: " + ex.Message);
                }
            }

            return transactions;
        }

        /// <summary>
        /// Updates an existing transaction in the database.
        /// </summary>
        /// <param name="transactionId">The ID of the transaction to update.</param>
        /// <param name="transaction">The updated transaction data.</param>
        /// <returns>True if the transaction is successfully updated, otherwise false.</returns>
        public bool UpdateTransaction(int transactionId, TRA01 transaction)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE " +
                               "TRA01 " +
                               "SET " +
                               "A01F02 = @ProductId, " +
                               "A01F03 = @StockId, " +
                               "A01F04 = @TransactionDate, " +
                               "A01F05 = @TransactionType, " +
                               "A01F06 = @ContactId, " +
                               "A01F07 = @Quantity, " +
                               "A01F08 = @NetPrice, " +
                               "A01F09 = @Description " +
                               "WHERE " +
                               "A01F01 = @TransactionId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", transaction.A01F02);
                command.Parameters.AddWithValue("@StockId", transaction.A01F03);
                command.Parameters.AddWithValue("@TransactionDate", transaction.A01F04);
                command.Parameters.AddWithValue("@TransactionType", (int)transaction.A01F05);
                command.Parameters.AddWithValue("@ContactId", transaction.A01F06);
                command.Parameters.AddWithValue("@Quantity", transaction.A01F07);
                command.Parameters.AddWithValue("@NetPrice", transaction.A01F08);
                command.Parameters.AddWithValue("@Description", transaction.A01F09);
                command.Parameters.AddWithValue("@TransactionId", transactionId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating transaction: " + ex.Message);
                }
            }
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

        public void GenerateTransactionJsonFile(string userRole)
        {
            List<TRA01> transactions = GetAllTransactions();

            // Filter transactions based on user role
            switch (userRole.ToLower())
            {
                case "admin":
                    // Include all transactions
                    transactions.ToList();
                    break;
                case "seller":
                    // Include only sale transactions
                    transactions = transactions.Where(t => t.A01F05 == enmTransactionType.Sale).ToList();
                    break;
                case "supplier":
                    // Include only purchase transactions
                    transactions = transactions.Where(t => t.A01F05 == enmTransactionType.Purchase).ToList();
                    break;
                default:
                    throw new ArgumentException("Invalid user role");
            }

            // Serialize transactions to JSON
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);

            // Determine file path based on user role
            string fileName = $"{userRole.ToLower()}_transactions.json";
            string filePath = Path.Combine(appDataFolderPath, fileName);

            // Write JSON to file
            File.WriteAllText(filePath, json);
        }

        public dynamic GetTransactionBill()
        {
            List<object> transaction = new List<object>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT " +
                                    "T.A01F01 AS TransactionID, " +
                                    "P.D01F02 AS ProductName, " +
                                    "T.A01F04 AS TransactionDate, " +
                                    "T.A01F05 AS TransactionType, " +
                                    "C.T01F02 AS PartyName, " +
                                    "T.A01F07 AS Quantity, " +
                                    "T.A01F08 AS NetPrice, " +
                                    "T.A01F09 AS Description " +
                                "FROM " +
                                     "TRA01 AS T " +
                                 "JOIN PRD01 AS P ON T.A01F02 = P.D01F01 " + 
                                 "JOIN CNT01 AS C ON T.A01F06 = C.T01F01";


                //Create Command
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        transaction.Add(new
                        {
                            TransactionID = dataReader[0],
                            ProductName = dataReader[1],
                            TransactionDate = dataReader[2],
                            TransactionType = dataReader[3],
                            PartyName = dataReader[4],
                            Quantity = dataReader[5],
                            NetPrice = dataReader[6],
                            Description = dataReader[7]
                        });
                    }

                    dataReader.Close();
                }
                catch(Exception ex)
                {
                    throw new Exception("Error Generate in bill: " + ex.Message);
                }
                    
                
                return transaction;
            }
           
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Retrieves the unit price of a product from the database.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <returns>The unit price of the product.</returns>
        private decimal GetUnitPrice(int productId, enmTransactionType transactionType)
        {
            decimal unitPrice = 0;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT " +
                                    (transactionType == enmTransactionType.Purchase ? "D01F05 " : "D01F06 ") +
                               "FROM " +
                                    "PRD01 " +
                               "WHERE " +
                                    "D01F01 = @ProductId";
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
                    throw new Exception("Error retrieving unit price: " + ex.Message);
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
        private bool UpdateStockQuantity(MySqlConnection connection, int stockId, int quantity, enmTransactionType transactionType, MySqlTransaction transaction)
        {
            string updateQuery = "";
            if (transactionType == enmTransactionType.Sale)
            {
                // For sale transactions, decrease the product quantity
                updateQuery = "UPDATE " +
                                "STK01 " +
                              "SET " +
                                "K01F03 = K01F03 - @Quantity " +
                              "WHERE " +
                                "K01F01 = @StockId AND K01F03 >= @Quantity";
            }
            else if (transactionType == enmTransactionType.Purchase)
            {
                // For purchase transactions, increase the product quantity
                updateQuery = "UPDATE " +
                                "STK01 " +
                              "SET " +
                                "K01F03 = K01F03 + @Quantity " +
                              "WHERE " +
                                "K01F01 = @StockId";
            }

            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection, transaction);
            updateCommand.Parameters.AddWithValue("@Quantity", quantity);
            updateCommand.Parameters.AddWithValue("@StockId", stockId);

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
                transaction.Rollback(); // Rollback the transaction if an error occurs
                throw new Exception("Error updating product quantity: " + ex.Message);
            }
        }

        #endregion
    }

}


//#region Public methods

///// <summary>
///// Retrieves all transactions from the database.
///// </summary>
///// <returns>A list of transactions.</returns>
//public List<TRA01> GetAllTransactions()
//{
//    List<TRA01> transactions = new List<TRA01>(); // List to store transactions

//    using (MySqlConnection connection = new MySqlConnection(_connectionString)) // Creating a MySqlConnection object
//    {
//        string query = @"SELECT T.A01F01, T.A01F02, T.A01F03, T.A01F04, T.A01F05, T.A01F06, 
//                        P.D01F02 
//                 FROM TRA01 AS T
//                 JOIN PRD01 AS P ON T.A01F02 = P.D01F01"; // SQL query to retrieve transactions along with product details




//        MySqlCommand command = new MySqlCommand(query, connection); // Creating a MySqlCommand object

//        try
//        {
//            connection.Open(); // Opening the database connection
//            using (MySqlDataReader reader = command.ExecuteReader()) // Executing the SQL command
//            {
//                while (reader.Read()) // Looping through the result set
//                {
//                    TRA01 transaction = new TRA01 // Creating a new transaction object
//                    {
//                        A01F01 = reader.GetInt32("A01F01"), // Setting transaction ID
//                        A01F02 = reader.GetInt32("A01F02"), // Setting product ID
//                        //ProductName = reader.GetString("D01F02"), // Setting product name
//                        A01F03 = (enmTransactionType)Enum.Parse(typeof(enmTransactionType), reader.GetString("A01F03")), // Setting transaction type
//                        A01F04 = reader.GetDateTime("A01F04"), // Setting transaction date
//                        A01F05 = reader.GetInt32("A01F05"), // Setting quantity
//                        A01F06 = reader.GetDecimal("A01F06") // Setting net price
//                    };
//                    transactions.Add(transaction); // Adding the transaction to the list
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("Error fetching transactions: " + ex.Message);
//        }
//    }

//    return transactions; // Returning the list of transactions
//}






