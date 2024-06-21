using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace FinalDemo_Advance_C_.DataBase
{
    /// <summary>
    /// Provides methods to interact with the STK01 table in the database.
    /// </summary>
    public class DBSTK01Context
    {
        #region Private members

        /// <summary>
        /// Connection string for accessing the database
        /// </summary>
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion

        #region Public Methods

        ///// <summary>
        ///// Retrieves all stock entries from the STK01 table.
        ///// </summary>
        ///// <returns>List of stock entries.</returns>
        //public List<STK01> GetAllStockEntries()
        //{
        //    List<STK01> stockEntries = new List<STK01>();

        //    // Establishing a connection to the database
        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        string query = string.Format(@"SELECT 
        //                                            K01F01,
        //                                            K01F02, 
        //                                            K01F03 
        //                                       FROM 
        //                                            STK01");
        //        MySqlCommand command = new MySqlCommand(query, connection);

        //        try
        //        {
        //            connection.Open();
        //            // Executing the query to fetch stock entries
        //            using (MySqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    // Creating stock entry objects from the retrieved data
        //                    STK01 stockEntry = new STK01
        //                    {
        //                        K01F01 = reader.GetInt32("K01F01"), // StockId
        //                        K01F02 = reader.GetInt32("K01F02"), // ProductId
        //                        K01F03 = reader.GetInt32("K01F03") // Quantity
        //                    };
        //                    stockEntries.Add(stockEntry); // Adding stock entry to the list
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error fetching stock entries: " + ex.Message);
        //        }
        //    }

        //    return stockEntries;
        //}


        /// <summary>
        /// Retrieves all stock entries from the database.
        /// </summary>
        /// <returns>A DataTable containing the retrieved stock entries.</returns>
        public DataTable GetAllStockEntries()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // SQL query to fetch stock entries
                string query = @"SELECT 
                                    K01F01 AS StockId,
                                    K01F02 AS ProductId,
                                    K01F03 AS Quantity
                                FROM 
                                    STK01";

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
                    throw new Exception("Error fetching stock entries: " + ex.Message);
                }
            }

            return dataTable;
        }


        #endregion
    }
}