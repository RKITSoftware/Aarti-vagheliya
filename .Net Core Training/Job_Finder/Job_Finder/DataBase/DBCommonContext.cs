using Job_Finder.BusinessLogic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;

namespace Job_Finder.DataBase
{
    /// <summary>
    /// Provides a generic interface for interacting with the database for entities of type T.
    /// </summary>
    /// <typeparam name="T">The type of entity to interact with.</typeparam>
    public class DBCommonContext<T> where T : class
    {
        #region Private members

        /// <summary>
        /// Helper class for performing business logic operations.
        /// </summary>
        private BLHelper _objBLHelper = new BLHelper();

        /// <summary>
        /// The connection string used to connect to the database.
        /// </summary>
        private readonly string _connectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DBCommonContext{T}"/> class.
        /// </summary>
        public DBCommonContext()
        {
            _connectionString = _objBLHelper.GetConnectionString();
        }

        #endregion

        #region Public Method

        ///// <summary>
        ///// Retrieves all records for the specified entity type from the database.
        ///// </summary>
        ///// <returns>A list of objects of type T representing the retrieved records.</returns>
        //public List<T> Select()
        //{
        //    List<T> resultList = new List<T>();

        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        PropertyInfo[] properties = typeof(T).GetProperties();

        //        string columns = string.Join(",", properties.Select(p => p.Name));

        //        string query = string.Format(@"SELECT
        //                                    {0}
        //                               FROM
        //                                    {1}",
        //                                        columns, typeof(T).Name);

        //        MySqlCommand command = new MySqlCommand(query, connection);

        //        try
        //        {
        //            connection.Open();

        //            MySqlDataReader dataReader = command.ExecuteReader();

        //            while (dataReader.Read())
        //            {
        //                T item = Activator.CreateInstance<T>();

        //                foreach (PropertyInfo property in properties)
        //                {
        //                    if (!dataReader.IsDBNull(dataReader.GetOrdinal(property.Name)))
        //                    {
        //                        if (property.PropertyType.IsEnum)
        //                        {
        //                            //Enum to String
        //                            object enumValue = System.Enum.Parse(property.PropertyType, dataReader[property.Name].ToString());
        //                            property.SetValue(item, enumValue);
        //                        }
        //                        else
        //                        {
        //                            // Set other property values
        //                            property.SetValue(item, dataReader[property.Name]);
        //                        }
        //                    }
        //                }

        //                resultList.Add(item);
        //            }

        //            dataReader.Close();

        //            return resultList;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        /// <summary>
        /// Selects all records from the database table corresponding to the type T.
        /// </summary>
        /// <returns>A DataTable containing all the records.</returns>
        public DataTable GetData()
        {
            // Create a new DataTable to hold the data
            DataTable dataTable = new DataTable();

            // Establish a connection to the MySQL database using the connection string
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                // Get all the properties of the type T
                PropertyInfo[] properties = typeof(T).GetProperties();

                // Create a comma-separated list of column names from the properties of the type T
                string columns = string.Join(",", properties.Select(p => p.Name));

                // Build the SQL query to select all columns from the table corresponding to the type T
                string query = string.Format(@"SELECT
                                            {0}
                                       FROM
                                            {1}",
                                                    columns, typeof(T).Name);

                // Create a MySqlCommand with the query and the connection
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    // Open the database connection
                    connection.Open();

                    // Execute the query and get a MySqlDataReader
                    MySqlDataReader dataReader = command.ExecuteReader();

                    // Load the data from the MySqlDataReader into the DataTable
                    dataTable.Load(dataReader);

                    // Close the data reader
                    dataReader.Close();

                    // Return the populated DataTable
                    return dataTable;
                }
                catch (Exception ex)
                {
                    // If an error occurs, throw an exception with the error message
                    throw ex;
                }
            }
        }

        #endregion
    }
}
