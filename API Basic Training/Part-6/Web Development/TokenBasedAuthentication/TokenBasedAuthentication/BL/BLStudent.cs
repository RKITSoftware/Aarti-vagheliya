using System;
using System.Collections.Generic;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.BL
{
    /// <summary>
    /// Represents a class for managing student data.
    /// </summary>
    public class BLStudent
    {
        
        /// <summary>
        /// Retrieves a list of student details.
        /// </summary>
        /// <returns>List of student details.</returns>
        public List<Student> StudentsDetail()
        {
            // Sample student data
            List<Student> student = new List<Student>()
           {
               new Student { Id = 1,  FirstName = "Arti", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 2,  FirstName = "Krinsi", LastName = "Kayada", DateOfBirth = new DateTime(2003,08,17), MobileNo = "+91 9852563215", Email = "krinsi@gmail.com" },
               new Student { Id = 3,  FirstName = "Ishika", LastName = "Jethwa", DateOfBirth = new DateTime(2002,07,18), MobileNo = "+91 9874565215", Email = "ishika@gmail.com" },
               new Student { Id = 4,  FirstName = "Dimple", LastName = "Mithiya", DateOfBirth = new DateTime(2003,06,05), MobileNo = "+91 9874598215", Email = "dimple@gmail.com" },
               new Student { Id = 5,  FirstName = "Yashvi", LastName = "Shah", DateOfBirth = new DateTime(2001,05,15), MobileNo = "+91 4274563215", Email = "yashvi@gmail.com" },
               new Student { Id = 6,  FirstName = "Arti1", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 7,  FirstName = "Arti2", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 8,  FirstName = "Arti3", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 9,  FirstName = "Arti4", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
           };
            return student;
        }
    
    }
}