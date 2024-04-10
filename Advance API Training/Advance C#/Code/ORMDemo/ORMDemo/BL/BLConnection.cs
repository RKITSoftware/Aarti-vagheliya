using ServiceStack.OrmLite;
using System.Configuration;

namespace ORMDemo.BL
{
    /// <summary>
    /// Handles database connection and OrmLite configuration.
    /// </summary>
    public class BLConnection
    {
        /// <summary>
        /// Gets the connection string from the configuration file.
        /// </summary>
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        /// <summary>
        /// Creates a new instance of OrmLiteConnectionFactory using the connection string and MySQL dialect.
        /// </summary>
        public static OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(ConnectionString, MySqlDialect.Provider);
    }
}