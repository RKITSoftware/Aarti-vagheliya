using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Helper class providing methods for mapping objects and converting lists to DataTables.
    /// </summary>
    public static class BLHelper
    {
        #region Public Methods

        /// <summary>
        /// Maps properties from a source object to a new instance of the target object type.
        /// </summary>
        /// <typeparam name="Tdto">Type of the source object.</typeparam>
        /// <typeparam name="Tpoco">Type of the target object.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>A new instance of the target object with mapped properties.</returns>
        public static Tpoco Map<Tdto, Tpoco>(this Tdto source) where Tpoco : new()
        {
            var target = new Tpoco();

            // Iterate over properties of the source object
            foreach (var sourceProperty in typeof(Tdto).GetProperties())
            {
                // Find corresponding property in the target object
                var targetProperty = typeof(Tpoco).GetProperty(sourceProperty.Name);
                if (targetProperty != null && targetProperty.CanWrite)
                {
                    var value = sourceProperty.GetValue(source);
                    if (value != null)
                    {
                        // Check if the property types are compatible or assignable
                        if (targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                        {
                            targetProperty.SetValue(target, value);
                        }
                        else
                        {
                            // Try converting the value to the target property type
                            var convertedValue = Convert.ChangeType(value, targetProperty.PropertyType);
                            targetProperty.SetValue(target, convertedValue);
                        }
                    }
                }
            }

            return target;
        }

        /// <summary>
        /// Converts a list of objects to a DataTable.
        /// </summary>
        /// <typeparam name="T">Type of objects in the list.</typeparam>
        /// <param name="list">List of objects to convert.</param>
        /// <returns>A DataTable containing the data from the list.</returns>
        public static DataTable ToDataTable<T>( List<T> list) where T : class
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
        /// Converts a list of objects to a DataTable.
        /// </summary>
        /// <typeparam name="T">Type of objects in the list.</typeparam>
        /// <param name="list">List of objects to convert.</param>
        /// <returns>A DataTable containing the data from the list.</returns>
        public static DataTable ConvertListToDataTable(List<object> list)
        {
            DataTable table = new DataTable();

            // If the list is empty, return an empty DataTable
            if (list.Count == 0)
            {
                return table;
            }

            // Get the properties of the first object in the list
            PropertyInfo[] properties = list[0].GetType().GetProperties();

            // Create columns in the DataTable for each property
            foreach (PropertyInfo property in properties)
            {
                table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Add rows to the DataTable from the list
            foreach (object item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        #endregion
    }
}