using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableDemo
{
    

    /// <summary>
    /// The main class of the program.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a DataTable with columns for City, Country, and State
            DataTable citiesTable = CreateCitiesDataTable();

            // Populate the DataTable with sample data
            PopulateCitiesDataTable(citiesTable);

            // Perform different LINQ queries on the DataTable
            QueryCities(citiesTable);
        }

        #region DataTable Operations

        #region CreateCitiesDataTable

        /// <summary>
        /// Creates a DataTable with columns for City, Country, and State.
        /// </summary>
        /// <returns>The created DataTable.</returns>
        static DataTable CreateCitiesDataTable()
        {
            DataTable citiesTable = new DataTable("Cities");
            citiesTable.Columns.Add("City", typeof(string));
            citiesTable.Columns.Add("Country", typeof(string));
            citiesTable.Columns.Add("State", typeof(string));
            return citiesTable;
        }

        #endregion

        #region PopulateCitiesDataTable

        /// <summary>
        /// Populates the DataTable with sample data.
        /// </summary>
        /// <param name="citiesTable">The DataTable to populate.</param>
        static void PopulateCitiesDataTable(DataTable citiesTable)
        {
            citiesTable.Rows.Add("New York", "USA", "New York");
            citiesTable.Rows.Add("Los Angeles", "USA", "California");
            citiesTable.Rows.Add("London", "UK", "England");
            citiesTable.Rows.Add("Paris", "France", "Île-de-France");
            citiesTable.Rows.Add("Tokyo", "Japan", "Tokyo");
        }

        #endregion

        #endregion

        #region Query Methods

        /// <summary>
        /// Perform LINQ queries on the DataTable containing cities.
        /// </summary>
        /// <param name="citiesTable">DataTable containing city data.</param>
        static void QueryCities(DataTable citiesTable)
        {
            #region DisplayDataTable

            // Display the DataTable
            Console.WriteLine("Cities Table:");
            DisplayDataTable(citiesTable);

            #endregion

            #region Select all cities

            // Query: Select all cities
            var allCities = from city in citiesTable.AsEnumerable()
                            select city;
            Console.WriteLine("\nAll Cities:");
            DisplayDataTable(allCities.CopyToDataTable());

            #endregion

            #region Select cities in USA

            // Query: Select cities in USA
            var citiesInUSA = from city in citiesTable.AsEnumerable()
                              where city.Field<string>("Country") == "USA"
                              select city;
            Console.WriteLine("\nCities in USA:");
            DisplayDataTable(citiesInUSA.CopyToDataTable());

            #endregion

            #region Select cities in France

            // Query: Select cities in France
            var citiesInFrance = from city in citiesTable.AsEnumerable()
                                 where city.Field<string>("Country") == "France"
                                 select city;
            Console.WriteLine("\nCities in France:");
            DisplayDataTable(citiesInFrance.CopyToDataTable());

            #endregion

            #region Select cities in New York state

            // Query: Select cities in New York state
            var citiesInNewYorkState = from city in citiesTable.AsEnumerable()
                                       where city.Field<string>("State") == "New York"
                                       select city;
            Console.WriteLine("\nCities in New York State:");
            DisplayDataTable(citiesInNewYorkState.CopyToDataTable());

            #endregion
        }

        #endregion

        #region DisplayDataTable

        /// <summary>
        /// Displays the contents of a DataTable.
        /// </summary>
        /// <param name="dataTable">The DataTable to display.</param>
        static void DisplayDataTable(DataTable dataTable)
        {
            // Display column names
            foreach (DataColumn column in dataTable.Columns)
            {
                Console.Write(column.ColumnName+ "\t");
            }
            Console.WriteLine();

            // Display data rows
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item +"\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------");
        }

        #endregion

       
    }
}

