using System;
using System.Data;
using System.Linq;

namespace DataTableDemo
{
    /// <summary>
    /// This class manages different types of methods for datatble.
    /// </summary>
    public class DataTableMethods
    {

        #region Public Methods

        /// <summary>
        /// Creates a DataTable with columns for City, Country, and State.
        /// </summary>
        /// <returns>The created DataTable.</returns>
        public DataTable CreateCitiesDataTable()
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
        public void PopulateCitiesDataTable(DataTable citiesTable)
        {
            citiesTable.Rows.Add("New York", "USA", "New York");
            citiesTable.Rows.Add("Los Angeles", "USA", "California");
            citiesTable.Rows.Add("London", "UK", "England");
            citiesTable.Rows.Add("Paris", "France", "Île-de-France");
            citiesTable.Rows.Add("Tokyo", "Japan", "Tokyo");
        }


        /// <summary>
        /// Perform LINQ queries on the DataTable containing cities.
        /// </summary>
        /// <param name="citiesTable">DataTable containing city data.</param>
        public void QueryCities(DataTable citiesTable)
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
        /// Groups cities in the provided DataTable by country and counts the number of cities in each country.
        /// </summary>
        /// <param name="citiesTable">The DataTable containing city data.</param>
        public void GroupCitiesByCountry(DataTable citiesTable)
        {
            var query = from city in citiesTable.AsEnumerable()
                        group city by city.Field<string>("Country") into g
                        select new
                        {
                            Country = g.Key,
                            CityCount = g.Count()
                        };

            Console.WriteLine("\nNumber of Cities in Each Country:");
            foreach (var item in query)
            {
                Console.WriteLine($"Country: {item.Country}, City Count: {item.CityCount}");
            }
        }


        /// <summary>
        /// Orders cities in the provided DataTable by city name.
        /// </summary>
        /// <param name="citiesTable">The DataTable containing city data.</param>
        public void OrderCitiesByName(DataTable citiesTable)
        {
            var query = from city in citiesTable.AsEnumerable()
                        orderby city.Field<string>("City")
                        select city;

            Console.WriteLine("\nCities Ordered by Name:");
            DisplayDataTable(query.CopyToDataTable());
        }

        /// <summary>
        /// Displays the contents of a DataTable.
        /// </summary>
        /// <param name="dataTable">The DataTable to display.</param>
        public void DisplayDataTable(DataTable dataTable)
        {
            // Display column names
            foreach (DataColumn column in dataTable.Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();

            // Display data rows
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------");
        }

        #endregion

    }
}
