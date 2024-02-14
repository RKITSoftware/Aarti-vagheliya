using System;
using System.IO;
using System.Text;

namespace FileSystemDemo
{
    /// <summary>
    /// This code demonstrate Filesystem in depth
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method to execute the file system operations demo.
        /// </summary>
        static void Main()
        {
            // File and directory paths
            string filePath = "demo.txt";
            string destinationFilePath = "demo_copy.txt";
            string newFilePath = "renamed_demo.txt";
            string directoryPath = "DemoDirectory";

            while (true)
            {
                // Display menu options
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Create and write to file");
                Console.WriteLine("2. Read file");
                Console.WriteLine("3. Append to file");
                Console.WriteLine("4. Copy file");
                Console.WriteLine("5. Move/rename file");
                Console.WriteLine("6. Delete file");
                Console.WriteLine("7. Create directory");
                Console.WriteLine("8. List directory contents");
                Console.WriteLine("9. Delete directory");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");

                // Input choice from user
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        CreateAndWriteFile(filePath);
                        break;
                    case 2:
                        ReadFile(filePath);
                        break;
                    case 3:
                        AppendToFile(filePath);
                        break;
                    case 4:
                        CopyFile(filePath, destinationFilePath);
                        break;
                    case 5:
                        MoveFile(destinationFilePath, newFilePath);
                        break;
                    case 6:
                        DeleteFile(filePath);
                        break;
                    case 7:
                        CreateDirectory(directoryPath);
                        break;
                    case 8:
                        ListDirectoryContents(directoryPath);
                        break;
                    case 9:
                        DeleteDirectory(directoryPath);
                        break;
                    case 10:
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 10.");
                        break;
                }

                Console.WriteLine(); // Add a newline for readability
            }
        }

        #region CreateAndWriteFile

        /// <summary>
        /// Creates a file and writes content to it.
        /// </summary>
        /// <param name="filePath">The path of the file to be created and written to.</param>
        static void CreateAndWriteFile(string filePath)
        {
            Console.Write("Enter content to write to file: ");
            string content = Console.ReadLine();


            try
            {
                // Open or create the file and write content to it using FileStream
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = Encoding.UTF8.GetBytes(content);
                    fs.Write(data, 0, data.Length);
                }
                Console.WriteLine($"Content written successfully to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        #endregion

        #region ReadFile

        /// <summary>
        /// Reads content from a file.
        /// </summary>
        /// <param name="filePath">The path of the file to be read.</param>
        static void ReadFile(string filePath)
        {
            try
            {
                // Open the file and read its content using FileStream
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                    string content = Encoding.UTF8.GetString(data);
                    Console.WriteLine($"File content:\n{content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        #endregion

        #region AppendToFile

        /// <summary>
        /// Appends content to an existing file.
        /// </summary>
        /// <param name="filePath">The path of the file to which content will be appended.</param>
        static void AppendToFile(string filePath)
        {
            Console.Write("Enter content to append to file: ");
            string content = Console.ReadLine();

            // Append a newline character if the file is not empty
            if (new FileInfo(filePath).Length > 0)
            {
                content = "\n" + content;
            }

            try
            {
                // Open the file and append content to it using FileStream
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    byte[] data = Encoding.UTF8.GetBytes(content);
                    fs.Write(data, 0, data.Length);
                }
                Console.WriteLine($"Content appended successfully to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to file: {ex.Message}");
            }
        }

        #endregion

        #region CopyFile

        /// <summary>
        /// Copies a file to a new location.
        /// </summary>
        /// <param name="sourceFilePath">The path of the source file to be copied.</param>
        /// <param name="destinationFilePath">The path where the file will be copied.</param>
        static void CopyFile(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                // Open source file for reading and destination file for writing
                using (StreamReader reader = new StreamReader(sourceFilePath))
                using (StreamWriter writer = new StreamWriter(destinationFilePath))
                {
                    // Read each line from source file and write to destination file
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"File copied from {sourceFilePath} to {destinationFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying file: {ex.Message}");
            }
        }

        #endregion

        #region MoveFile


        /// <summary>
        /// Moves or renames a file.
        /// </summary>
        /// <param name="sourceFilePath">The path of the source file.</param>
        /// <param name="destinationFilePath">The path where the file will be moved or renamed.</param>
        static void MoveFile(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                // Move the file from the source path to the destination path
                File.Move(sourceFilePath, destinationFilePath);
                Console.WriteLine($"File moved/renamed from {sourceFilePath} to {destinationFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving/renaming file: {ex.Message}");
            }
        }

        #endregion

        #region DeleteFile

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="filePath">The path of the file to be deleted.</param>
        static void DeleteFile(string filePath)
        {
            try
            {
                // Delete the file
                File.Delete(filePath);
                Console.WriteLine($"File {filePath} deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }

        #endregion

        #region CreateDirectory

        /// <summary>
        /// Creates a directory at the specified path.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to be created.</param>
        static void CreateDirectory(string directoryPath)
        {
            try
            {
                // Create the directory
                DirectoryInfo directoryInfo = Directory.CreateDirectory(directoryPath);
                Console.WriteLine($"Directory {directoryInfo.FullName} created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
        }

        #endregion

        #region ListDirectoryContents

        /// <summary>
        /// Lists the contents of a directory.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to list contents from.</param>
        static void ListDirectoryContents(string directoryPath)
        {
            try
            {
                // Get files and directories within the specified directory
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                FileInfo[] files = directoryInfo.GetFiles();
                DirectoryInfo[] directories = directoryInfo.GetDirectories();

                // Create a file inside the directory
                string filePath = Path.Combine(directoryInfo.FullName, "newFile.txt");
                File.WriteAllText(filePath, "This is a new file created inside the directory.");

                // Create a subdirectory inside the directory
                string subDirectoryPath = Path.Combine(directoryInfo.FullName, "Subdirectory");
                DirectoryInfo subDirectoryInfo = Directory.CreateDirectory(subDirectoryPath);

                foreach (DirectoryInfo dir in directories)
                {
                    Console.WriteLine(dir.Name);

                    
                }

                Console.WriteLine($"Files in directory {directoryPath}:");
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.Name);
                }

                Console.WriteLine($"Directories in directory {directoryPath}:");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error listing directory contents: {ex.Message}");
            }
        }

        #endregion

        #region DeleteDirectory

        /// <summary>
        /// Deletes a directory and its contents recursively.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to be deleted.</param>
        static void DeleteDirectory(string directoryPath)
        {
            try
            {
                // Delete the directory and its contents recursively
                Directory.Delete(directoryPath, true); // Recursive deletion
                Console.WriteLine($"Directory {directoryPath} deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting directory: {ex.Message}");
            }

         
        }

        #endregion
    }
}
