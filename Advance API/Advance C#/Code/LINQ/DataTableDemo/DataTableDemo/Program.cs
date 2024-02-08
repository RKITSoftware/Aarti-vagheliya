using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableDemo
{
    /// <summary>
    /// Represents a city with properties for name, country, and state.
    /// </summary>
    class City
    {/// <summary>
     /// Gets or sets the name of the city.
     /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the country where the city is located.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state or region where the city is located.
        /// </summary>
        public string State { get; set; }
    }

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

        #region Query Methods

        /// <summary>
        /// Perform LINQ queries on the DataTable containing cities.
        /// </summary>
        /// <param name="citiesTable">DataTable containing city data.</param>
        static void QueryCities(DataTable citiesTable)
        {
            // Display the DataTable
            Console.WriteLine("Cities Table:");
            DisplayDataTable(citiesTable);

            // Query: Select all cities
            var allCities = from city in citiesTable.AsEnumerable()
                            select city;
            Console.WriteLine("\nAll Cities:");
            DisplayDataTable(allCities.CopyToDataTable());

            // Query: Select cities in USA
            var citiesInUSA = from city in citiesTable.AsEnumerable()
                              where city.Field<string>("Country") == "USA"
                              select city;
            Console.WriteLine("\nCities in USA:");
            DisplayDataTable(citiesInUSA.CopyToDataTable());

            // Query: Select cities in France
            var citiesInFrance = from city in citiesTable.AsEnumerable()
                                 where city.Field<string>("Country") == "France"
                                 select city;
            Console.WriteLine("\nCities in France:");
            DisplayDataTable(citiesInFrance.CopyToDataTable());

            // Query: Select cities in New York state
            var citiesInNewYorkState = from city in citiesTable.AsEnumerable()
                                       where city.Field<string>("State") == "New York"
                                       select city;
            Console.WriteLine("\nCities in New York State:");
            DisplayDataTable(citiesInNewYorkState.CopyToDataTable());
        }

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

