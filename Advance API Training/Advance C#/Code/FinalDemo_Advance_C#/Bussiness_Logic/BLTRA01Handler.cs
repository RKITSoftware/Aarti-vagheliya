using FinalDemo_Advance_C_.DataBase;
using FinalDemo_Advance_C_.Models;
using FinalDemo_Advance_C_.Models.DTO;
using FinalDemo_Advance_C_.Models.POCO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Class containing methods for managing transactions.
    /// </summary>
    public class BLTRA01Handler
    {
        #region Private member

        /// <summary>
        /// App data folder path
        /// </summary>
        private static string appDataFolderPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

        /// <summary>
        ///  Path to save the JSON file
        /// </summary>
        private string filePath = Path.Combine(appDataFolderPath, "transactions.json");

        /// <summary>
        ///  Path to save the JSON file
        /// </summary>
        private string filePathBill = Path.Combine(appDataFolderPath, "Bill.json");

        /// <summary>
        /// Instance of TRA01 class.
        /// </summary>
        private TRA01 _objTRA01 = new TRA01();

        /// <summary>
        /// Private instance of Response class.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Private instance of DBTRA01Context class.
        /// </summary>
        private DBTRA01Context _objDBTRA01Context = new DBTRA01Context();

        #endregion

        #region Public Methods 

        /// <summary>
        /// Prepare transaction data from DTO to POCO.
        /// </summary>
        /// <param name="objDtoTRA01">The data transfer object for transactions.</param>
        public void PreSave(DtoTRA01 objDtoTRA01)
        {
            _objTRA01 = objDtoTRA01.Map<DtoTRA01, TRA01>();
            // Calculate net price
            decimal unitPrice = _objDBTRA01Context.GetUnitPrice(_objTRA01.A01F02, _objTRA01.A01F05); // Getting the unit price of the product
            int productCount = _objTRA01.A01F07; // Getting the quantity of the product
            decimal netPrice = CalculateNetPrice(unitPrice, productCount); // Calculating the net price
            _objTRA01.A01F08 = netPrice;
        }

        /// <summary>
        /// Validate transaction data.
        /// </summary>
        /// <returns>A response indicating whether the data is valid.</returns>
        public Response Validation()
        {
            _objResponse = new Response();

            if (_objTRA01.A01F07 > 0)
            {
                _objResponse.isError = false;
                _objResponse.Message = "Validated.";
                return _objResponse;
            }
            _objResponse.isError = true;
            _objResponse.Message = "Invalid Data.";
            return _objResponse;
        }

        /// <summary>
        /// Save transaction data to the database.
        /// </summary>
        /// <returns>A response indicating the result of the save operation.</returns>
        public Response Save()
        {
            _objResponse = new Response();

            string result = _objDBTRA01Context.AddTransaction(_objTRA01);

            if (result == "Success")
            {
                _objResponse.isError = false;
                _objResponse.Message = result;
                return _objResponse;
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = result;
                return _objResponse;
            }
        }

        /// <summary>
        /// Retrieve all transactions from the database.
        /// </summary>
        /// <returns>A response containing all transaction data.</returns>
        public Response Select()
        {
            _objResponse = new Response();

            int result = _objDBTRA01Context.GetAllTransactions().Count;

            if (result > 0)
            {
                _objResponse.isError = false;
                _objResponse.Message = "Ok";
                _objResponse.response = BLHelper.ToDataTable(_objDBTRA01Context.GetAllTransactions());
                return _objResponse;
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
                return _objResponse;
            }
        }

        /// <summary>
        /// Generate a JSON file containing transaction bill data.
        /// </summary>
        public void GenerateTransactionJsonFile()
        {
            List<object> transactions = _objDBTRA01Context.GetTransactionBill();

            // Serialize transactions to JSON
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);

            // Write JSON to file
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Retrieve the transaction bill.
        /// </summary>
        /// <returns>A response containing the transaction bill data.</returns>
        public Response GetTransactionBill()
        {
            _objResponse = new Response();

            _objResponse.isError = false;
            _objResponse.Message = "Transaction Bill.";
            _objResponse.response = BLHelper.ConvertListToDataTable(_objDBTRA01Context.GetTransactionBill());

            return _objResponse;



        }

        /// <summary>
        /// Retrieve transaction-wise bill data and generate a JSON file.
        /// </summary>
        /// <returns>A response containing the transaction-wise bill data.</returns>
        public Response TransactionWiseBill()
        {
            _objResponse = new Response();

            List<object> transaction = _objDBTRA01Context.TransactionWiseBill();

            // Serialize transactions to JSON
            string json = JsonConvert.SerializeObject(transaction, Formatting.Indented);

            // Write JSON to file
            File.WriteAllText(filePathBill, json);

            _objResponse.isError = false;
            _objResponse.Message = "Transaction wise Bill";
            _objResponse.response = BLHelper.ConvertListToDataTable(transaction);
            return _objResponse;

        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Calculates the net price based on the unit price and product count.
        /// </summary>
        /// <param name="unitPrice">The unit price of the product.</param>
        /// <param name="productCount">The count of the product.</param>
        /// <returns>The calculated net price.</returns>
        private decimal CalculateNetPrice(decimal unitPrice, int productCount)
        {
            // Implement logic to calculate net price using the unit price and transaction count
            decimal netPrice = unitPrice * productCount;

            return netPrice;
        }

        #endregion
    }

}
