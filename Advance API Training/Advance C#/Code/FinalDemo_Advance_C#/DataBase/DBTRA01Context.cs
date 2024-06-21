using FinalDemo_Advance_C_.Enums;
using FinalDemo_Advance_C_.Models.POCO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FinalDemo_Advance_C_.DataBase
{
    /// <summary>
    /// Provides methods to interact with the TRA01 table in the database.
    /// </summary>
    public class DBTRA01Context
    {
        #region Private Member

        /// <summary>
        ///  Connection string to the database
        /// </summary>
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all transactions from the database.
        /// </summary>
        /// <returns>A list of all transactions.</returns>
        public List<TRA01> GetAllTransactions()
        {
            List<TRA01> transactions = new List<TRA01>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"SELECT 
                                                   A01F01 AS TransactionID,
                                                   A01F02 AS ProductID, 
                                                   A01F03 AS StockID, 
                                                   A01F04 AS TransactionDate, 
                                                   A01F05 AS TransactionType, 
                                                   A01F06 AS ContactID,
                                                   A01F07 AS Quantity, 
                                                   A01F08 AS NetPrice, 
                                                   A01F09 AS Description 
                                               FROM 
                                                    TRA01");
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
        /// Generates a bill with transaction details.
        /// </summary>
        /// <returns>A list containing transaction details for the bill.</returns>
        public dynamic GetTransactionBill()
        {
            List<object> transaction = new List<object>();

            // Establish database connection
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Define SQL query
                string query = string.Format(@"SELECT 
                                                    A01.A01F01 AS TransactionID, 
                                                    D01.D01F02 AS ProductName, 
                                                    A01.A01F04 AS TransactionDate, 
                                                    A01.A01F05 AS TransactionType, 
                                                    N01.N01F02 AS PartyName, 
                                                    A01.A01F07 AS Quantity, 
                                                    A01.A01F08 AS NetPrice, 
                                                    A01.A01F09 AS Description 
                                                FROM 
                                                     TRA01 AS A01 
                                                JOIN 
                                                     PRD01 AS D01 ON A01.A01F02 = D01.D01F01
                                                JOIN 
                                                     CON01 AS N01 ON A01.A01F06 = N01.N01F01
                                                ORDER BY 
                                                     A01.A01F04");

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
                        // Add transaction details to the list
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

                    // Close the data reader
                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    // Throw an exception if an error occurs
                    throw new Exception("Error Generate in bill: " + ex.Message);
                }

                // Return the list of transactions
                return transaction;
            }
        }

        /// <summary>
        /// Generates a transaction-wise bill.
        /// </summary>
        /// <returns>A list containing transaction-wise details for the bill.</returns>
        public dynamic TransactionWiseBill()
        {
            List<object> transaction = new List<object>();

            // Establish database connection
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Define SQL query
                string query = string.Format(@"SELECT 
                                                    D01F02 AS Product,
                                                    A01F05 AS Tr_Type,
                                                    A01F07 AS Quantity,
                                                    K01F03 AS Stock,
                                                    SUM(TRA01.A01F08) AS TotalAmount
                                                FROM 
                                                    TRA01
                                                JOIN 
                                                    PRD01 ON PRD01.D01F01 = TRA01.A01F02
                                                JOIN 
                                                    STK01 ON STK01.K01F02 = TRA01.A01F03  
                                                GROUP BY 
                                                    TRA01.A01F05,A01F02
                                                ");

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
                        // Add transaction details to the list
                        transaction.Add(new
                        {
                            Product = dataReader[0],
                            Tr_Type = dataReader[1],
                            Quantity = dataReader[2],
                            Stock = dataReader[3],
                            TotalAmount = dataReader[4]
                        });
                    }

                    // Close the data reader
                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    // Throw an exception if an error occurs
                    throw new Exception("Error Generate in bill: " + ex.Message);
                }

                // Return the list of transactions
                return transaction;
            }
        }

        /// <summary>
        /// Adds a new transaction to the database.
        /// </summary>
        /// <param name="objTRA01">The transaction object to add.</param>
        /// <returns>Success or error message.</returns>
        public string AddTransaction(TRA01 objTRA01)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Open the connection before beginning the transaction

                // Begin a transaction
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    string query = string.Format(@"INSERT INTO 
                                                            TRA01
                                                               (A01F02, 
                                                                A01F03, 
                                                                A01F04, 
                                                                A01F05, 
                                                                A01F06, 
                                                                A01F07, 
                                                                A01F08, 
                                                                A01F09) 
                                                            VALUES 
                                                                ({0}, 
                                                                 {1}, 
                                                                '{2}',
                                                                '{3}',
                                                                 {4}, 
                                                                 {5},
                                                                 {6},
                                                                '{7}')",
                                                                objTRA01.A01F02,
                                                                objTRA01.A01F03,
                                                                objTRA01.A01F04.ToString("yyyy-MM-dd HH:mm:ss"),
                                                                objTRA01.A01F05.ToString(),
                                                                objTRA01.A01F06,
                                                                objTRA01.A01F07,
                                                                objTRA01.A01F08,
                                                                objTRA01.A01F09);
                    MySqlCommand command = new MySqlCommand(query, connection);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update product quantity in PRD01 table
                            if (UpdateStockQuantity(connection, objTRA01.A01F03, objTRA01.A01F07, objTRA01.A01F05, transaction))
                            {
                                transaction.Commit(); // Commit the transaction if both inserts succeed
                                return "Success";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error adding transaction: " + ex.Message);
                    }
                }
            }
            return "Fail to Add new transaction.";
        }

        /// <summary>
        /// Retrieves the unit price of a product based on its ID and transaction type.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="transactionType">The type of transaction (Purchase or Sale).</param>
        /// <returns>The unit price of the product.</returns>
        public decimal GetUnitPrice(int productId, enmTransactionType transactionType)
        {
            decimal unitPrice = 0;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"SELECT 
                                                   {0} 
                                               FROM 
                                                   PRD01 
                                               WHERE 
                                                   D01F01 = {1}",
                                             transactionType == enmTransactionType.P ? "D01F05" : "D01F06",productId);

                MySqlCommand command = new MySqlCommand(query, connection);

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

        

        #endregion

        #region private Methods

        /// <summary>
        /// Updates the stock quantity based on the transaction type.
        /// </summary>
        /// <param name="connection">The MySqlConnection object.</param>
        /// <param name="stockId">The ID of the stock.</param>
        /// <param name="quantity">The quantity to update.</param>
        /// <param name="transactionType">The type of transaction (Purchase or Sale).</param>
        /// <param name="transaction">The MySqlTransaction object.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
        private bool UpdateStockQuantity(MySqlConnection connection, int stockId, int quantity, enmTransactionType transactionType, MySqlTransaction transaction)
        {
            string updateQuery = "";
            if (transactionType == enmTransactionType.S)
            {
                // For sale transactions, decrease the product quantity
                updateQuery = string.Format(@"UPDATE
                                                STK01 
                                              SET 
                                                K01F03 = K01F03 - {0} 
                                              WHERE 
                                                K01F01 = {1} AND K01F03 >= {2}", quantity, stockId, quantity);
            }
            else if (transactionType == enmTransactionType.P)
            {
                // For purchase transactions, increase the product quantity
                updateQuery = string.Format(@"UPDATE 
                                                STK01 
                                              SET 
                                                K01F03 = K01F03 + {0} 
                                              WHERE 
                                                K01F01 = {1}", quantity, stockId);
            }

            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection, transaction);

            try
            {
                int rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
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