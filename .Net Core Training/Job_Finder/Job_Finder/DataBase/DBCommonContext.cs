using Job_Finder.BusinessLogic;
using Job_Finder.Enum;
using Job_Finder.Model;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;

namespace Job_Finder.DataBase
{
    public class DBCommonContext<T> where T : class
    {
        private BLHelper _objBLHelper = new BLHelper();

        private readonly string _connectionString;

        public DBCommonContext()
        {
            _connectionString = _objBLHelper.GetConnectionString();
        }

        public List<T> Select()
        {
            List<T> resultList = new List<T>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                PropertyInfo[] properties = typeof(T).GetProperties();

                string columns = string.Join(",", properties.Select(p => p.Name));

                string query = string.Format(@"SELECT
                                            {0}
                                       FROM
                                            {1}",
                                                columns, typeof(T).Name);

                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();

                    MySqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        T item = Activator.CreateInstance<T>();

                        foreach (PropertyInfo property in properties)
                        {
                            if (!dataReader.IsDBNull(dataReader.GetOrdinal(property.Name)))
                            {
                                if (property.PropertyType.IsEnum)
                                {
                                    //Enum to String
                                    object enumValue = System.Enum.Parse(property.PropertyType, dataReader[property.Name].ToString());
                                    property.SetValue(item, enumValue);
                                }
                                else
                                {
                                    // Set other property values
                                    property.SetValue(item, dataReader[property.Name]);
                                }
                            }
                        }

                        resultList.Add(item);
                    }

                    dataReader.Close();

                    return resultList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        //public DataTable Select()
        //{
        //    DataTable dataTable = new DataTable();

        //    using (MySqlConnection connection = new MySqlConnection(_connectionString))
        //    {
        //        PropertyInfo[] properties = typeof(T).GetProperties();

        //        string columns = string.Join(",", properties.Select(p => p.Name));

        //        string query = string.Format(@"SELECT
        //                                            {0}
        //                                       FROM
        //                                            {1}",
        //                                            columns, typeof(T).Name);

        //        MySqlCommand command = new MySqlCommand(query, connection);

        //        try
        //        {
        //            connection.Open();

        //            MySqlDataReader dataReader = command.ExecuteReader();

        //            dataTable.Load(dataReader);

        //            dataReader.Close();

        //            return dataTable;

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

       
    }



}
