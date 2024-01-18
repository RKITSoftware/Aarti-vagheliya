using Build_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Build_Web_API.Controllers
{
    /// <summary>
    /// API controller for managing student data.
    /// </summary>
    public class StudentController : ApiController
    {
        #region List of Student
        // Static list to store student data.
        private static List<Student> _student = new List<Student>
       {
           new Student { Id = 1, FirstName = "Arti", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
           new Student { Id = 2, FirstName = "Krinsi", LastName = "Kayada", DateOfBirth = new DateTime(2003,08,17), MobileNo = "+91 9852563215", Email = "krinsi@gmail.com" },
           new Student { Id = 3, FirstName = "Ishika", LastName = "Jethwa", DateOfBirth = new DateTime(2002,07,18), MobileNo = "+91 9874565215", Email = "ishika@gmail.com" },
           new Student { Id = 4, FirstName = "Dimple", LastName = "Mithiya", DateOfBirth = new DateTime(2003,06,05), MobileNo = "+91 9874598215", Email = "dimple@gmail.com" },
           new Student { Id = 5, FirstName = "Yashvi", LastName = "Shah", DateOfBirth = new DateTime(2001,05,15), MobileNo = "+91 4274563215", Email = "yashvi@gmail.com" },
       };
        #endregion

        #region Get
        /// <summary>
        /// Retrieves all students.
        /// </summary>
        public List<Student> Get()
        {
            return _student;
        }
        #endregion

        #region GetById
        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        public Student GetById(int id)
        {
            // Gets the student by ID.
            var Student = GetStudentById(id);
            return Student;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        public void Delete(int id)
        {
            // Gets the student by ID.
            var student = GetStudentById(id);

            // If the student exists, removes it.
            if (student != null)
            {
                _student.Remove(student);
            }

        }
        #endregion

        #region Post
        /// <summary>
        /// Adds a new student.
        /// </summary>
        public void Post(Student student)
        {
            // If the incoming student is not null, assigns a new ID and adds it to the list.
           
            if (student != null)
            {
                student.Id = GetNextStudentId();
                _student.Add(student);
            }

        }
        #endregion

        #region Put
        /// <summary>
        /// Updates a student by ID.
        /// </summary>
        public void Put(int id, Student updatedStudent)
        {
            // Gets the existing student by ID.
            var existStudent = GetStudentById(id);

            // If the student exists, updates its properties.
            if (existStudent != null)
            {
                existStudent.FirstName = updatedStudent.FirstName;
                existStudent.LastName = updatedStudent.LastName;
                existStudent.DateOfBirth = updatedStudent.DateOfBirth;
                existStudent.Email = updatedStudent.Email;
                existStudent.MobileNo = updatedStudent.MobileNo;
            }
        }
        #endregion

        #region GetStudentById
        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        private Student GetStudentById(int id)
        {
            return _student.Find(s => s.Id == id);
        }
        #endregion

        #region GetNextStudentId
        /// <summary>
        /// Gets the next available student ID.
        /// </summary>
        private int GetNextStudentId()
        {
            return _student.Count + 1;
        }
        #endregion
    }
}
