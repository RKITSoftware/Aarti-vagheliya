using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace ORMDemo.BL
{
    /// <summary>
    /// Provides methods for converting objects and collections to DataTables.
    /// </summary>
    public class BLConvertor
    {
        /// <summary>
        /// Converts a single object to a DataTable.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <returns>A DataTable containing the properties of the object.</returns>
        public DataTable ObjectToDataTable<T>(T obj) where T : class
        {
            DataTable dataTable = new DataTable();
            if (obj == null)
                return dataTable;

            Type objectType = typeof(T);
            PropertyInfo[] properties = objectType.GetProperties();

            // Create columns in DataTable based on object properties
            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Create a new row and set values for each property
            DataRow row = dataTable.NewRow();
            foreach (PropertyInfo property in properties)
            {
                row[property.Name] = property.GetValue(obj) ?? DBNull.Value;
            }
            dataTable.Rows.Add(row);

            return dataTable;
        }


        /// <summary>
        /// Converts a list of objects to a DataTable.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="list">The list of objects to convert.</param>
        /// <returns>A DataTable containing the properties of the objects in the list.</returns>
        public DataTable ListToDataTable<T>(List<T> list) where T : class
        {
            DataTable dataTable = new DataTable();
            if (list == null || list.Count == 0)
                return dataTable;

            string json = JsonConvert.SerializeObject(list);
            dataTable = JsonConvert.DeserializeObject<DataTable>(json);

            return dataTable;
        }

        /// <summary>
        /// Converts a dictionary to a DataTable.
        /// </summary>
        /// <param name="lookupResults">The dictionary to convert.</param>
        /// <returns>A DataTable containing the keys and values from the dictionary.</returns>
        public DataTable ListToDataTable(Dictionary<int, List<string>> lookupResults)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Key", typeof(int));
            dataTable.Columns.Add("Value", typeof(string));

            foreach (var kvp in lookupResults)
            {
                int key = kvp.Key;
                foreach (var value in kvp.Value)
                {
                    dataTable.Rows.Add(key, value);
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Converts a dictionary to a DataTable.
        /// </summary>
        /// <param name="dictionary">The dictionary to convert.</param>
        /// <returns>A DataTable containing the keys and values from the dictionary.</returns>
        public DataTable DictionaryToDataTable(Dictionary<string, List<string>> dictionary)
        {
            DataTable dataTable = new DataTable();

            // Add columns to DataTable based on dictionary keys
            foreach (string key in dictionary.Keys)
            {
                dataTable.Columns.Add(key, typeof(string));
            }

            // Add rows to DataTable based on dictionary values
            int maxRowCount = dictionary.Values.Max(list => list.Count);
            for (int i = 0; i < maxRowCount; i++)
            {
                DataRow row = dataTable.NewRow();
                foreach (var kvp in dictionary)
                {
                    if (i < kvp.Value.Count)
                    {
                        row[kvp.Key] = kvp.Value[i];
                    }
                    else
                    {
                        row[kvp.Key] = DBNull.Value; // Fill missing values with DBNull
                    }
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}