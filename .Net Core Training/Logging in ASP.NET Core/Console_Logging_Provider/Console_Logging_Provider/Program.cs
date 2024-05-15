using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace Console_Logging_Provider
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a logger factory
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                // Add console logging
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            // Create a logger
            var logger = loggerFactory.CreateLogger<Program>();

            // Log a message
            logger.LogInformation("Hello, logging!");
            logger.LogInformation("Logging information.");
            logger.LogCritical("Logging critical information.");
            logger.LogDebug("Logging debug information.");
            logger.LogError("Logging error information.");
            logger.LogTrace("Logging trace");
            logger.LogWarning("Logging warning.");

        }
    }
}
