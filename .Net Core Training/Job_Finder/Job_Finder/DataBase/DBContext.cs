using Job_Finder.BusinessLogic;
using Job_Finder.Model.POCO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Job_Finder.DataBase
{
    public class DBContext
    {
        private BLHelper _objBLHelper = new BLHelper();

        private readonly string _connectionString;

        public DBContext()
        {
            _connectionString = _objBLHelper.GetConnectionString();
        }
        public DataTable GetCompanyWiseJobListing(int companyId)
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetCompanyWiseJobListing";

                    // Add input parameter
                    command.Parameters.AddWithValue("@company_id", companyId);

                    try
                    {
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();
                        dataTable.Load(reader);
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        throw ex;
                    }
                }
            }

            return dataTable;
        }

        public DataTable GetJobApplicationData()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"CREATE OR REPLACE VIEW 
                                    ApplicationData
                                AS 
                                SELECT
                                    s01.S01F02 AS 'Name',
                                    s01.S01F03 AS 'Qualification',
                                    s01.S01F04 AS 'Experience',
                                    s01.S01F07 AS 'Gender',
                                    s01.S01F08 AS 'EmailID',
                                    s01.S01F06 AS 'Contact',
                                    s01.S01F05 AS 'Resume',
                                    l01.L01F02 AS 'JobTitle',
                                    CASE 
                                        WHEN a01.A01F04 = 'Ap' THEN 'Applied'
                                        WHEN a01.A01F04 = 'Sh' THEN 'Shortlisted'
                                        WHEN a01.A01F04 = 'Is' THEN 'Interview Scheduled'
                                        WHEN a01.A01F04 = 'Pd' THEN 'Pending'
                                        WHEN a01.A01F04 = 'Sl' THEN 'Selected'
                                        WHEN a01.A01F04 = 'Rj' THEN 'Rejected'
                                        ELSE 'Unknown'
                                    END AS 'Status'
                                FROM
                                    joa01 a01
                                JOIN 
                                    jol01 l01 ON l01.L01F01 = a01.A01F02
                                JOIN 
                                    jos01 s01 ON s01.S01F01 = a01.A01F03;


                                    SELECT * FROM ApplicationData;"; // Select data from the view

                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    dataTable.Load(reader);
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    throw ex;
                }
            }

            return dataTable;
        }

        public List<CMP01> SearchByCityName(string cityName)
        {
            List<CMP01> results = new List<CMP01>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM cmp01 WHERE P01F04 LIKE @CityName";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CityName", "%" + cityName + "%");

                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CMP01 company = new CMP01
                                {
                                    P01F02 = reader.GetString("P01F02"),
                                    P01F03 = reader.GetString("P01F03"),
                                    P01F04 = reader.GetString("P01F04"),
                                    P01F05 = reader.GetInt32("P01F05"),
                                    P01F06 = reader.GetDecimal("P01F06")
                                };

                                // Add the model to the list
                                results.Add(company);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return results;
        }

        public List<CMP01> SearchByNameOrCity(string companyName, string cityName)
        {
            List<CMP01> results = new List<CMP01>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM cmp01 WHERE ";
                string whereClause = "";

                if (!string.IsNullOrEmpty(companyName))
                {
                    whereClause += "P01F02 LIKE @CompanyName OR ";
                }

                if (!string.IsNullOrEmpty(cityName))
                {
                    whereClause += "P01F04 LIKE @CityName OR ";
                }

                if (!string.IsNullOrEmpty(whereClause))
                {
                    // Remove the last "OR" from the where clause
                    whereClause = whereClause.Remove(whereClause.Length - 4);
                    query += whereClause;

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(companyName))
                        {
                            command.Parameters.AddWithValue("@CompanyName", "%" + companyName + "%");
                        }

                        if (!string.IsNullOrEmpty(cityName))
                        {
                            command.Parameters.AddWithValue("@CityName", "%" + cityName + "%");
                        }

                        try
                        {
                            connection.Open();
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    CMP01 company = new CMP01
                                    {
                                        P01F02 = reader.GetString("P01F02"),
                                        P01F03 = reader.GetString("P01F03"),
                                        P01F04 = reader.GetString("P01F04"),
                                        P01F05 = reader.GetInt32("P01F05"),
                                        P01F06 = reader.GetDecimal("P01F06")
                                    };

                                    // Add the model to the list
                                    results.Add(company);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }

            return results;
        }

    }
}
