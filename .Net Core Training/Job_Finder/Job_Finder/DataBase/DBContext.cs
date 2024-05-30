using Job_Finder.BusinessLogic;
using Job_Finder.Enum;
using Job_Finder.Model.POCO;
using MySql.Data.MySqlClient;
using System.Data;

namespace Job_Finder.DataBase
{
    /// <summary>
    /// Provides methods to interact with the database for common operations.
    /// </summary>
    public class DBContext
    {
        #region Private Member

        /// <summary>
        /// Helper class for performing business logic operations.
        /// </summary>
        private BLHelper _objBLHelper = new BLHelper();

        /// <summary>
        /// Gets the connection string used to connect to the database.
        /// </summary>
        private readonly string _connectionString;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DBContext"/> class.
        /// </summary>
        public DBContext()
        {
            _connectionString = _objBLHelper.GetConnectionString();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves job listings for a specific company from the database.
        /// </summary>
        /// <param name="companyId">The ID of the company to retrieve job listings for.</param>
        /// <returns>A <see cref="DataTable"/> containing the job listings for the specified company.</returns>
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

        /// <summary>
        /// Retrieves job application data from the database.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> containing the job application data.</returns>
        public DataTable GetJobApplicationData()
        {
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM ApplicationData;"; // Select data from the view

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

        /// <summary>
        /// Searches for companies by city name in the database.
        /// </summary>
        /// <param name="cityName">The name of the city to search for.</param>
        /// <returns>A list of <see cref="CMP01"/> objects representing the companies found.</returns>
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

        /// <summary>
        /// Searches for companies by name or city name in the database.
        /// </summary>
        /// <param name="companyName">The name of the company to search for.</param>
        /// <param name="cityName">The name of the city to search for.</param>
        /// <returns>A list of <see cref="CMP01"/> objects representing the companies found.</returns>
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

        /// <summary>
        /// Retrieves a list of job listings based on the specified criteria.
        /// </summary>
        /// <param name="location">The location to filter job listings by.</param>
        /// <param name="type">The job type to filter job listings by.</param>
        /// <param name="companyId">The company ID to filter job listings by.</param>
        /// <returns>A list of job listings matching the specified criteria.</returns>
        public dynamic GetJobListings(string location, string type, int companyId)
        {
            List<object> lstJobListings = new List<object>();

            using (MySqlConnection connection = new(_connectionString))
            {
                string query = string.Format(@"SELECT 
	                                                l01.L01F01 AS JobId, 
                                                    l01.L01F02 AS Title, 
                                                    p01.P01F04 AS Location, 
	                                                l01.L01F04 AS Salary, 
                                                    l01.L01F05 AS Type,
                                                    p01.P01F02 AS CompanyName
                                                FROM 
	                                                jol01 l01
                                                JOIN
	                                                cmp01 p01 ON l01.L01F03 = p01.P01F01
                                                WHERE 
	                                                (@Location IS NULL OR  p01.P01F04 LIKE @Location)
                                                AND (@Type IS NULL OR l01.L01F05 LIKE @Type)
                                                AND (@CompanyId IS NULL OR l01.L01F03 = @CompanyId)");

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Location", "%" + location + "%");
                    command.Parameters.AddWithValue("@Type", "%" + type + "%");
                    command.Parameters.AddWithValue("@CompanyId", companyId);

                    try
                    {
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            lstJobListings.Add(new
                            {
                                JobId = reader.GetInt32("JobId"),
                                Title = reader.GetString("Title"),
                                Location = reader.GetString("Location"),
                                Salary = reader.GetDecimal("Salary"),
                                Type = reader.GetString("Type"),
                                CompanyName = reader.GetString("CompanyName")
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                return lstJobListings;
            }
        }

        /// <summary>
        /// Retrieves the status of job applications for a specific job seeker.
        /// </summary>
        /// <param name="jobSeekerId">The ID of the job seeker.</param>
        /// <returns>A list of job application statuses for the specified job seeker.</returns>
        public dynamic GetStatus(int jobSeekerId)
        {
            List<object> lstApplicationStatus = new List<object>();

            using (MySqlConnection connection = new(_connectionString))
            {
                string query = string.Format(@"SELECT 
	                                                a01.A01F01 AS ApplicationId, 
	                                                l01.L01F02 AS JobTitle, 
	                                                p01.P01F02 AS CompanyName, 
                                                CASE 
	                                                a01.A01F04 
		                                                WHEN 'Ap' THEN 'Applied' 
		                                                WHEN 'Sh' THEN 'Shortlisted' 
		                                                WHEN 'Is' THEN 'Interview Scheduled' 
                                                        WHEN 'Pd' THEN 'Pending' 
                                                        WHEN 'Sl' THEN 'Selected' 
                                                        WHEN 'Rj' THEN 'Rejected' 
                                                END AS Status
                                                FROM 
	                                                joa01 a01
                                                JOIN jol01 l01 ON a01.A01F02 = l01.L01F01
                                                JOIN cmp01 p01 ON l01.L01F03 = p01.P01F01
                                                WHERE a01.A01F03 = @UserId");

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", jobSeekerId);

                    try
                    {
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            lstApplicationStatus.Add(new
                            {
                                ApplicationId = reader.GetInt32("ApplicationId"),
                                JobTitle = reader.GetString("JobTitle"),
                                CompanyName = reader.GetString("CompanyName"),
                                Status = reader.GetString("Status")
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                return lstApplicationStatus;
            }
        }

        /// <summary>
        /// Updates the status of a job application.
        /// </summary>
        /// <param name="applicationId">The ID of the application to update.</param>
        /// <param name="newStatus">The new status to set for the application.</param>
        /// <returns>A message indicating the result of the update operation.</returns>
        public string UpdateJobApplicationStatus(int applicationId, enmJobApplicationStatus newStatus)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = string.Format(@"UPDATE joa01 SET A01F04 = '{0}' WHERE A01F01 = {1}" , newStatus.ToString(), applicationId);

                using (MySqlCommand command = new MySqlCommand(query, connection))
                { 
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                            return "Success";
                        else
                            return "Failed to update status.";
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        throw new Exception("Error: " + ex.Message);
                    }
                }
            }
        }


        #endregion
    }
}









