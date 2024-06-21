using ServiceStack.OrmLite;
using System.Data;

namespace Middleware_Filter_Integration.BusinessLogic
{
    /// <summary>
    /// Provides a method to open a database connection using OrmLite.
    /// </summary>
    public class BLConnection
    {
        #region Private Member

        /// <summary>
        /// The configuration interface to access application settings.
        /// </summary>
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BLConnection"/> class with the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration interface to access application settings.</param>
        public BLConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Opens a new database connection using the connection string from the configuration.
        /// </summary>
        /// <returns>An open <see cref="IDbConnection"/>.</returns>
        public IDbConnection OpenConnection()
        {
            string connectionString = _configuration.GetConnectionString("Connection");
            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);
            return dbFactory.Open();
        }

        #endregion
    }
}
