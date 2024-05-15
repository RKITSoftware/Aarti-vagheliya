using Microsoft.AspNetCore;
using NLog.Web;

namespace Job_Finder
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method responsible for starting the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Info("Hello"); // Log an informational message
                Builder(args).Run(); // Create and run the web host
            }
            catch (Exception ex)
            {
                logger.Fatal(ex); // Log a fatal error if an exception occurs
            }
        }

        /// <summary>
        /// Builds the web host for the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>The configured web host.</returns>
        public static IWebHost Builder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<StartUp>()
            .ConfigureLogging(log => log.SetMinimumLevel(LogLevel.Trace)) // Configure logging level
            .UseNLog() // Use NLog for logging
            .Build();
    }
}