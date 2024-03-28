using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersApi.Filters
{
    /// <summary>
    /// Filter to handle exceptions globally and log them.
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Create instance of Ilogger interface
        /// </summary>
        private readonly ILogger<ExceptionFilter> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionFilter"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Executes when an exception occurs during the execution of an action.
        /// </summary>
        /// <param name="context">The exception context.</param>
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            // Log exception details to a file
            LogExceptionToFile(exception, context.ActionDescriptor.DisplayName);

            // Return an error response
            context.Result = new ObjectResult("An error occurred while processing your request.")
            {
                StatusCode = 500 // Internal Server Error
            };
        }

        /// <summary>
        /// Logs the exception details to a file.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="actionName">The name of the action where the exception occurred.</param>
        private void LogExceptionToFile(Exception exception, string actionName)
        {
            // Log exception details to a file
            string logDirectory = "logs";
            string logFile = $"log-{DateTime.Today:yyyy-MM-dd}.txt";
            string logPath = Path.Combine(logDirectory, logFile);

            Directory.CreateDirectory(logDirectory); // Create directory if it doesn't exist

            using (StreamWriter writer = new StreamWriter(logPath, append: true))
            {
                writer.WriteLine($"Timestamp: {DateTime.Now}");
                writer.WriteLine($"Action Name: {actionName}");
                writer.WriteLine($"Exception Type: {exception.GetType().Name}");
                writer.WriteLine($"Message: {exception.Message}");
                writer.WriteLine($"Stack Trace: {exception.StackTrace}");
                writer.WriteLine(new string('-', 50)); // Separator
            }

            // Log to console (optional)
            _logger.LogError(exception, $"Exception occurred in action '{actionName}'");
        }
    }


}
