using System;
using System.IO;


namespace BasicFileOperation
{
    /// <summary>
    /// This program demonstrate basic file operation in C#.
    /// </summary>
     class Program
    {
        #region Create  File
        /// <summary>
        /// Demonstrates creating a new file.
        /// </summary>
        static void CreateFileDemo()
        {
            Console.WriteLine("Create File Demo:");

            string filePath = "demo.txt";

            // Check if the file already exists
            if (File.Exists(filePath))
            {
                Console.WriteLine("File already exists.");
                return;
            }

            // Attempt to create the file
            try
            {
                File.Create(filePath);
                Console.WriteLine("File created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating the file: {ex.Message}");
            }

            Console.WriteLine();
        }
        #endregion

        #region Write to File
        /// <summary>
        /// Demonstrates writing content to a file.
        /// </summary>
        static void WriteToFileDemo()
        {
            Console.WriteLine("Write to File Demo:");

            string filePath = "demo.txt";

            // Check if the file exists before writing
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist. Cannot write.");
                return;
            }

            // Attempt to write content to the file
            try
            {
                File.WriteAllText(filePath, "Hello, File!");
                Console.WriteLine("Content written to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to the file: {ex.Message}");
            }

            Console.WriteLine();
        }
        #endregion

        #region Read from File
        /// <summary>
        /// Demonstrates reading content from a file.
        /// </summary>
        static void ReadFromFileDemo()
        {
            Console.WriteLine("Read from File Demo:");

            string filePath = "demo.txt";

            // Check if the file exists before reading
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist. Cannot read.");
                return;
            }

            // Attempt to read content from the file
            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine($"File content: {content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from the file: {ex.Message}");
            }

            Console.WriteLine();
        }
        #endregion

        #region Append to File
        /// <summary>
        /// Demonstrates appending content to a file.
        /// </summary>
        static void AppendToFileDemo()
        {
            Console.WriteLine("Append to File Demo:");

            string filePath = "demo.txt";

            // Check if the file exists before appending
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist. Cannot append.");
                return;
            }

            // Attempt to append content to the file
            try
            {
                File.AppendAllText(filePath, "\nAppended Content.");
                Console.WriteLine("Content appended to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to the file: {ex.Message}");
            }

            Console.WriteLine();
        }
        #endregion

        #region Delete File
        /// <summary>
        /// Demonstrates deleting a file.
        /// </summary>
        static void DeleteFileDemo()
        {
            Console.WriteLine("Delete File Demo:");

            string filePath = "demo.txt";

            // Check if the file exists before deleting
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist. Cannot delete.");
                return;
            }

            // Attempt to delete the file
            try
            {
                File.Delete(filePath);
                Console.WriteLine("File deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting the file: {ex.Message}");
            }

            Console.WriteLine();
        }
        #endregion

        /// <summary>
        /// This main method call all the file operation custome method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            #region Create File Demo
            // Create a new file
            CreateFileDemo();
            #endregion

            #region Write to File Demo
            // Write content to the file
            WriteToFileDemo();
            #endregion

            #region Read from File Demo
            // Read content from the file
            ReadFromFileDemo();
            #endregion

            #region Append to File Demo
            // Append content to the file
            AppendToFileDemo();
            #endregion

            #region Delete File Demo
            // Delete the file
            DeleteFileDemo();
            #endregion
        }
    }
}
