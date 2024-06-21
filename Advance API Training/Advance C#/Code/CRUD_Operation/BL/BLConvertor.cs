using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace CRUD_Operation.BL
{
    /// <summary>
    /// Represent convertor logic
    /// </summary>
    public class BLConvertor
    {
        #region Public Methods

        /// <summary>
        /// Converts list into datatable
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="obj">List of type T</param>
        /// <returns>Datatable</returns>
        public DataTable ToDataTable<T>(List<T> obj) where T : class
        {
            string json = JsonConvert.SerializeObject(obj);
            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(json);

            return dataTable;
        }

        #endregion

    }
}