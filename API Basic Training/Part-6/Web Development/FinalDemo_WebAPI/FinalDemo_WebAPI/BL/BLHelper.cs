using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace FinalDemo_WebAPI.BL
{
    /// <summary>
    /// Helper class for generating unique IDs.
    /// </summary>
    public class BLHelper
    {
        #region Public Methods

        /// <summary>
        /// Generates a unique ID for objects in a list.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="list">The list of objects.</param>
        /// <returns>The generated unique ID.</returns>
        public static int GenerateId<T>(List<T> list) where T : class
        {
            if (list.Count > 0)
            {
                // Assuming each object in the list has a property named "Id"
                var maxId = list.Max(x => (x.GetType().GetProperty("Id").GetValue(x)) as int? ?? 0);

                // Increment the max ID to generate a new unique ID
                return maxId + 1;
            }
            else
            {
                // If the list is empty, return 1 as the starting ID
                return 1;
            }
        }

        /// <summary>
        /// Converts a list of objects of type T to a DataTable.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="list">The list of objects to convert.</param>
        /// <returns>A DataTable containing the data from the list.</returns>
        public DataTable ToDataTable<T>(List<T> list) where T : class
        {
            DataTable dataTable = new DataTable();

            if (list.Count == 0)
                return dataTable; // Return an empty DataTable if list is empty

            // Get all properties of the type T
            var properties = typeof(T).GetProperties();

            // Create columns in DataTable based on properties of T
            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, prop.PropertyType);
            }

            // Fill DataTable with data from list
            foreach (var item in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        /// <summary>
        /// Converts an object of type T to a DataTable.
        /// </summary>
        /// <typeparam name="T">The type of the object to convert.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <returns>A DataTable containing the data from the object.</returns>
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

        #endregion
    }
}