using System;

namespace PartialClass
{
    /// <summary>
    /// Second part of the partial class representing a Student.
    /// </summary>
    partial class Student
    {
        /// <summary>
        /// Represents the age of a person, typically expressed in years.
        /// </summary>
        int age = 20;
        /// <summary>
        /// Represents the roll number assigned to a student.
        /// </summary>
        int rollNo = 101;

        /// <summary>
        /// This method prints a greeting message to the console.
        /// </summary>
        public static void Method2()
        {
            Console.WriteLine("Hello from Method -2 ");
        }

        /// <summary>
        /// Method to display personal data.
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"Age = {age}");
            Console.WriteLine($"RollNo = {rollNo}");
        }
    }
}
