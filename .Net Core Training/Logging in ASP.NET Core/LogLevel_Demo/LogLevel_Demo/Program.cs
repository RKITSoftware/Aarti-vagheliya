using Microsoft.AspNetCore;
using NLog.Web;

namespace LogLevel_Demo
{
    /// <summary>
    /// Main class responsible for application startup.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Info("Hello"); // Log an informational message
                Builder(args).Run(); // Run the application
            }
            catch (Exception ex)
            {
                logger.Fatal(ex); // Log a fatal error if an exception occurs
            }
        }

        /// <summary>
        /// Builds the web host for the application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        /// <returns>The configured web host instance.</returns>
        public static IWebHost Builder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<StartUp>() // Specify the startup class
            .ConfigureLogging(log => log.SetMinimumLevel(LogLevel.Trace)) // Configure logging level
            .UseNLog() // Use NLog for logging
            .Build();
    }
}