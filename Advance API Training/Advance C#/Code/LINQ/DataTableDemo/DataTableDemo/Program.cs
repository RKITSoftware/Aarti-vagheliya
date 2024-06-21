using System.Data;

namespace DataTableDemo
{
    /// <summary>
    /// The main class of the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method of the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DataTableMethods objDataTableMethods = new DataTableMethods();

            // Create a DataTable with columns for City, Country, and State
            DataTable citiesTable = objDataTableMethods.CreateCitiesDataTable();

            // Populate the DataTable with sample data
            objDataTableMethods.PopulateCitiesDataTable(citiesTable);

            // Perform different LINQ queries on the DataTable
            objDataTableMethods.QueryCities(citiesTable);
            objDataTableMethods.OrderCitiesByName(citiesTable);
            objDataTableMethods.GroupCitiesByCountry(citiesTable);
        }
    }
}

