using System;
using System.Collections.Generic;


namespace Authorization.Models
{
    /// <summary>
    /// Represents a student entity with basic information.
    /// </summary>
    public class Student
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unique identifier for the student.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the student.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the mobile number of the student.
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// Gets or sets the email address of the student.
        /// </summary>
        public string Email { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves a list of student details for demonstration purposes.
        /// </summary>
        /// <returns>A list of student objects.</returns>
        public static List<Student> StudentsDetail()
        {
           List<Student> student = new List<Student>()
           {
               new Student { Id = 1,  FirstName = "Arti", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 2,  FirstName = "Krinsi", LastName = "Kayada", DateOfBirth = new DateTime(2003,08,17), MobileNo = "+91 9852563215", Email = "krinsi@gmail.com" },
               new Student { Id = 3,   FirstName = "Ishika", LastName = "Jethwa", DateOfBirth = new DateTime(2002,07,18), MobileNo = "+91 9874565215", Email = "ishika@gmail.com" },
               new Student { Id = 4,   FirstName = "Dimple", LastName = "Mithiya", DateOfBirth = new DateTime(2003,06,05), MobileNo = "+91 9874598215", Email = "dimple@gmail.com" },
               new Student { Id = 5,   FirstName = "Yashvi", LastName = "Shah", DateOfBirth = new DateTime(2001,05,15), MobileNo = "+91 4274563215", Email = "yashvi@gmail.com" },
               new Student { Id = 6,  FirstName = "Arti1", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 7,  FirstName = "Arti2", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 8,  FirstName = "Arti3", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 9,  FirstName = "Arti4", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
           };
            return student;
        }
        #endregion

    }
}