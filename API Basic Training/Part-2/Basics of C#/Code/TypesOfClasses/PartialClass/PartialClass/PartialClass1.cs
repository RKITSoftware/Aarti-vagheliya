using System;

namespace PartialClass
{
    /// <summary>
    /// Partial class representing a Student.
    /// </summary>
    partial class Student
    {
        /// <summary>
        /// Represents the first name of  a student.
        /// </summary>
        string firstName = "Arti";
        /// <summary>
        /// Represents the last name of  a student.
        /// </summary>
        string lastName = "Vagheliya";

        /// <summary>
        /// This method prints a greeting message to the console.
        /// </summary>
        public void Method1()
        {
            Console.WriteLine("Hello from method -1 ");
            
        }

        /// <summary>
        /// Method to display personal data.
        /// </summary>
        public void DisplayData()
        {
            Console.WriteLine($"FirstName = {firstName}");
            Console.WriteLine($"LastName = {lastName}");
        }
    }
}
