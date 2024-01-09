using System;

namespace PartialClass
{
    /// <summary>
    /// Partial class representing a Student.
    /// </summary>
    partial class Student
    {
        string FirstName = "Arti";
        string LastName = "Vagheliya";

        public void Method1()
        {
            Console.WriteLine("Hello from method -1 ");
            
        }

        /// <summary>
        /// Method to display personal data.
        /// </summary>
        public void DisplayData()
        {
            Console.WriteLine($"FirstName = {FirstName}");
            Console.WriteLine($"LastName = {LastName}");
        }
    }
}
