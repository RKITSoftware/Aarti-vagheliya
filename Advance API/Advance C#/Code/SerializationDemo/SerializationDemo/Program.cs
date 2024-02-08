using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace SerializationDemo
{
    /// <summary>
  /// Represents a program for demonstrating serialization and deserialization.
  /// </summary>
    public class Program
    {
        // List of employee objects
        public static List<Employee> objEmployeeList = new List<Employee>
        {
            new Employee { Id = 101, FirstName = "ABC", LastName = "abc", City = "Rajkot"},
            new Employee { Id = 102, FirstName = "PQR", LastName = "pqr", City = "Jamnagar"},
            new Employee { Id = 103, FirstName = "XYZ", LastName = "xyz", City = "Morbi"},
        };


        // File path for JSON serialization
        static string filePath = @"F:\Arti-368\New folder\Advance API\Advance C#\Code\SerializationDemo\SerializationDemo\serialization.json";

        // File path for XML serialization
        static string FilePath = @"F:\Arti-368\New folder\Advance API\Advance C#\Code\SerializationDemo\SerializationDemo\XML_demo.xml";

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {

            JSONSerialization();

            JSONDeserialization();

            XMLSerialization();

            XMLDeserialization();

        }

        #region JSON Serialization

        /// <summary>
        /// Performs JSON serialization.
        /// </summary>
        static void JSONSerialization()
        {
            // Serialize the employee list to JSON and write it to a file
            string json = JsonSerializer.Serialize(objEmployeeList);
            File.WriteAllText(filePath, json);
            Console.WriteLine("json File created");
        }

        #endregion

        #region JSON Deserialization

        /// <summary>
        /// Performs JSON deserialization.
        /// </summary>
        static void JSONDeserialization()
        {
            if (File.Exists(filePath))
            {
                // Read the JSON file and deserialize it to a list of employees
                string jsonstring = File.ReadAllText(filePath);
                var employeeList = JsonSerializer.Deserialize<List<Employee>>(jsonstring);
                Console.WriteLine("List to JSON file");

                if (employeeList != null)
                {
                    // Display the deserialized employee data
                    foreach (var emp in employeeList)
                    {
                        if (emp != null)
                        {
                            Console.WriteLine("ID = {0} FirstName = {1} LastName = {2} City = {3}", emp.Id, emp.FirstName, emp.LastName, emp.City);
                        }
                    }
                }
            }
        }

        #endregion

        #region XML Serialization

        /// <summary>
        /// Performs XML serialization.
        /// </summary>
        static void XMLSerialization()
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                // Create an XML serializer and serialize the employee list to XML
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
                xmlSerializer.Serialize(sw, objEmployeeList);
                Console.WriteLine("XML File created");
            }
        }

        #endregion

        #region XML Deserialization

        /// <summary>
        /// Performs XML deserialization.
        /// </summary>
        static void XMLDeserialization()
        {
            if(File.Exists(FilePath))
            {
                using(StreamReader sr = new StreamReader(FilePath))
                {
                    // Create an XML serializer and deserialize the XML file to a list of employees
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
                    List<Employee> employee = (List<Employee>)xmlSerializer.Deserialize(sr);
                    Console.WriteLine("List to XML file");

                    if(employee != null)
                    {
                        // Display the deserialized employee data
                        foreach (Employee emp in employee)
                        {
                            Console.WriteLine("ID = {0} FirstName = {1} LastName = {2} City = {3}", emp.Id, emp.FirstName, emp.LastName, emp.City);
                        }
                       
                    }
                }
            }
            
        }

        #endregion
    }
}
