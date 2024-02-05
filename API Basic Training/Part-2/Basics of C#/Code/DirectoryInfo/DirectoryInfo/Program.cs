using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryInfo
{
    internal class Program
    {
        static void AccessDemo()
        {
            string filePath = "F:\\Arti-368\\New folder\\API Basic Training\\Part-2\\Basics of C#\\Code\\FileDemo\\SubDirectory\\example.tx";

            try
            {
                // Create a FileStream with different file access rights
                using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    // Create a StreamWriter using the FileStream
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        // Write some content to the file
                        streamWriter.WriteLine("Hello, StreamWriter with FileAccessRights!");

                        Console.WriteLine("Content has been written to the file.");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            // Specify the directory path
            string baseDirectoryPath = @"F:\Arti-368\New folder\API Basic Training\Part-2\Basics of C#\Code\FileNewDemo";

                // Create a DirectoryInfo object for the base directory
                System.IO.DirectoryInfo baseDirectory = new System.IO.DirectoryInfo(baseDirectoryPath);

                // Check if the base directory exists
                if (!baseDirectory.Exists)
                {
                    // If the directory doesn't exist, create it
                    baseDirectory.Create();
                    Console.WriteLine($"Base Directory Created: {baseDirectory.FullName}");
                }

                // Create a subdirectory within the base directory
                string subdirectoryName = "SubDirectory";
            System.IO.DirectoryInfo subDirectory = baseDirectory.CreateSubdirectory(subdirectoryName);
                Console.WriteLine($"Subdirectory Created: {subDirectory.FullName}");

                // Move the subdirectory to a new location
                string newDirectoryPath = @"F:\Arti-368\New folder\API Basic Training\Part-2\Basics of C#\Code\HelloWorld";
                subDirectory.MoveTo(Path.Combine(newDirectoryPath, subdirectoryName));
                Console.WriteLine($"Subdirectory Moved to: {subDirectory.FullName}");

            // Display information about the new directory
            System.IO.DirectoryInfo newDirectory = new System.IO.DirectoryInfo(Path.Combine(newDirectoryPath, subdirectoryName));
                Console.WriteLine($"New Directory Name: {newDirectory.Name}");
                Console.WriteLine($"Number of Files: {newDirectory.GetFiles().Length}");
                Console.WriteLine($"Number of Subdirectories: {newDirectory.GetDirectories().Length}");

                // Delete the new directory
                newDirectory.Delete();
                Console.WriteLine($"New Directory Deleted: {newDirectory.FullName}");

                Console.ReadLine();


            AccessDemo();
        }


    }
}



