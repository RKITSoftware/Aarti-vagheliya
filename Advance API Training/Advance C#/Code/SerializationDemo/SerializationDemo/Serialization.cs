using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace SerializationDemo
{
    public class Serialization
    {
        #region Private Member

        // List of employee objects
        private static List<Employee> _lstEmployeeList = new List<Employee>
        {
            new Employee { Id = 101, FirstName = "ABC", LastName = "abc", City = "Rajkot"},
            new Employee { Id = 102, FirstName = "PQR", LastName = "pqr", City = "Jamnagar"},
            new Employee { Id = 103, FirstName = "XYZ", LastName = "xyz", City = "Morbi"},
        };

        // File path for JSON serialization
        private static string _filePath = @"F:\Arti-368\New folder\Advance API\Advance C#\Code\SerializationDemo\SerializationDemo\serialization.json";

        // File path for XML serialization
        private static string _FilePath = @"F:\Arti-368\New folder\Advance API\Advance C#\Code\SerializationDemo\SerializationDemo\XML_demo.xml";
        #endregion

        #region JSON Serialization

        /// <summary>
        /// Performs JSON serialization.
        /// </summary>
        public void JSONSerialization()
        {
            // Serialize the employee list to JSON and write it to a file
            string json = JsonSerializer.Serialize(_lstEmployeeList);
            File.WriteAllText(_filePath, json);
            Console.WriteLine("json File created");
        }

        #endregion

        #region JSON Deserialization

        /// <summary>
        /// Performs JSON deserialization.
        /// </summary>
        public void JSONDeserialization()
        {
            if (File.Exists(_filePath))
            {
                // Read the JSON file and deserialize it to a list of employees
                string jsonstring = File.ReadAllText(_filePath);
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
        public void XMLSerialization()
        {
            using (StreamWriter sw = new StreamWriter(_FilePath))
            {
                // Create an XML serializer and serialize the employee list to XML
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
                xmlSerializer.Serialize(sw, _lstEmployeeList);
                Console.WriteLine("XML File created");
            }
        }

        #endregion

        #region XML Deserialization

        /// <summary>
        /// Performs XML deserialization.
        /// </summary>
        public void XMLDeserialization()
        {
            if (File.Exists(_FilePath))
            {
                using (StreamReader sr = new StreamReader(_FilePath))
                {
                    // Create an XML serializer and deserialize the XML file to a list of employees
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
                    List<Employee> employee = (List<Employee>)xmlSerializer.Deserialize(sr);
                    Console.WriteLine("List to XML file");

                    if (employee != null)
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
