using System;
using System.IO;
using System.Web.Http.Filters;

namespace FinalDemo_Advance_C_.Exception_Filter
{
    /// <summary>
    /// Global exception filter attribute to log exceptions.
    /// </summary>
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Private member

        // A lock object to ensure thread safety when writing to the file
        private static readonly object lockObject = new object();

        #endregion

        #region Public Method

        /// <summary>
        /// Overrides the OnException method to handle exceptions globally.
        /// </summary>
        /// <param name="actionExecutedContext">The context for the HTTP action that throws the exception.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is Exception ex)
            {
                // Log the exception to a file using the actual logging logic
                lock (lockObject)
                {
                    try
                    {
                        // Get the application's root directory
                        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

                        // Create the Log directory path
                        string logDirectoryPath = Path.Combine(appDirectory, "Log");

                        // Ensure the Log directory exists
                        if (!Directory.Exists(logDirectoryPath))
                        {
                            Directory.CreateDirectory(logDirectoryPath);
                        }

                        // Generate a log file name with the current date
                        string fileName = $"error_{DateTime.Now:dd-MM-yyyy}.log"; // Use date in the file name

                        // Combine the directory path and the file name to get the full log file path
                        string logFilePath = Path.Combine(logDirectoryPath, fileName);

                        // Append the exception details to the log file
                        using (StreamWriter writer = File.AppendText(logFilePath))
                        {
                            // Write the exception details along with a timestamp
                            writer.WriteLine($"[DateTime: {DateTime.Now}] Exception Details:");
                            writer.WriteLine($"Exception Type: {ex.GetType().FullName}");
                            writer.WriteLine($"Exception Message: {ex.Message}");
                            writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                            writer.WriteLine("----------------------------------------------------------------");
                            writer.WriteLine();
                        }
                    }
                    catch (IOException ioEx)
                    {
                        // Log the IOException if encountered while writing to the log file
                        Console.WriteLine($"Error writing to log file: {ioEx.Message}");
                    }
                }
            }
        }

        #endregion


    }


}
