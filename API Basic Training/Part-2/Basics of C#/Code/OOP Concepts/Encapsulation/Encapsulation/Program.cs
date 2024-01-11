﻿using System;

namespace Encapsulation
{
    /// <summary>
    /// Represents a student with encapsulated properties for name, email, and age.
    /// </summary>
    public class Student
    {
        #region Private Members
        private string _name;
        private string _email;  
        private int _age;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the email of the student.
        /// </summary>
        public string Email
        {
            get { return _email; }

            set { _email = value; }
        }

        /// <summary>
        /// Gets or sets the age of the student.
        /// </summary>
        public int Age
        {
            get { return _age; } 

            set {  _age = value; } 
        }
        #endregion
    }

    /// <summary>
    /// Main program class.
    /// </summary>
    class Program
    {
        #region Main method
        static void Main(string[] args)
        {
            // Creating an instance of the Student class
            Student student = new Student();

            // Taking input from the user
            Console.Write("Enter student's Name : ");
            student.Name = Console.ReadLine();
            Console.Write("Enter student's Email : ");
            student.Email = Console.ReadLine();
            Console.Write("Enter student's Age : ");
            student.Age = Convert.ToInt32(Console.ReadLine());

            // Displaying student information
            Console.WriteLine();
            Console.WriteLine($"Name : {student.Name}");
            Console.WriteLine($"Email : {student.Email}");
            Console.WriteLine($"Age : {student.Age}");
        }
        #endregion
    }
}