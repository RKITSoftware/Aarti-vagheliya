using System;
using System.IO;

namespace FinalDemo_Advance_C_.Bussiness_Logic
{
    /// <summary>
    /// Provides functionality to log exceptions to a file.
    /// </summary>
    public class BLFileLogger
    {
        #region Private member

        // Specify the directory path where log files will be stored
        private static readonly string logDirectoryPath = @"F:\Arti-368\New folder\Advance API Training\Advance C#\Code\FinalDemo_Advance_C#\App_Data";

        // The path of the current log file
        private static string logFilePath;

        // A lock object to ensure thread safety when writing to the file
        private static readonly object lockObject = new object();

        #endregion

        #region Public methods

        /// <summary>
        /// Logs an exception to the specified log file.
        /// </summary>
        /// <param name="ex">The exception to log.</param>
        public static void LogException(Exception ex)
        {
            // Lock the operation to ensure thread safety when writing to the file
            lock (lockObject)
            {
                try
                {
                    // Generate a log file name with the current date
                    string fileName = $"error_{DateTime.Now:ddd MMM dd yyyy}.log"; // Include date in the file name

                    // Combine the directory path and the file name to get the full log file path
                    logFilePath = Path.Combine(logDirectoryPath, fileName);

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

        #endregion
    }
}