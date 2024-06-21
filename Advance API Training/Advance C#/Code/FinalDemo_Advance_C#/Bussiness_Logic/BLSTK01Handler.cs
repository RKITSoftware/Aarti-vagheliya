using FinalDemo_Advance_C_.DataBase;
using FinalDemo_Advance_C_.Models;
using System.Data;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Business logic class for managing stock.
    /// </summary>
    public class BLSTK01Handler
    {
        #region Private members

        /// <summary>
        /// Instance of Response.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Private instance of DBSTK01Context class.
        /// </summary>
        private DBSTK01Context _objDBSTK01Context = new DBSTK01Context();

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all stock entries from the database.
        /// </summary>
        /// <returns>A response containing the retrieved stock entries.</returns>
        public Response Select()
        {
            _objResponse = new Response();

            // Retrieve the DataTable directly from GetAllStockEntries
            DataTable dataTable = _objDBSTK01Context.GetAllStockEntries();

            if (dataTable.Rows.Count > 0)
            {
                _objResponse.isError = false;
                _objResponse.Message = "Ok";
                _objResponse.response = dataTable; // Directly assign the DataTable
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }

            return _objResponse;
        }

        #endregion


    }
}