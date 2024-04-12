using ActionMethodResponse.Models;
using System;
using System.Collections.Generic;

namespace ActionMethodResponse.BL
{
    /// <summary>
    /// Business logic class for managing student data.
    /// </summary>
    public class BLStudent
    {
        #region Private Student List
        // Static list to store student data.
        private static List<Student> _lstStudent = new List<Student>
       {
           new Student { Id = 1,  FirstName = "Arti", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
           new Student { Id = 2,  FirstName = "Krinsi", LastName = "Kayada", DateOfBirth = new DateTime(2003,08,17), MobileNo = "+91 9852563215", Email = "krinsi@gmail.com" },
           new Student { Id = 3,  FirstName = "Ishika", LastName = "Jethwa", DateOfBirth = new DateTime(2002,07,18), MobileNo = "+91 9874565215", Email = "ishika@gmail.com" },
           new Student { Id = 4,  FirstName = "Dimple", LastName = "Mithiya", DateOfBirth = new DateTime(2003,06,05), MobileNo = "+91 9874598215", Email = "dimple@gmail.com" },
           new Student { Id = 5,  FirstName = "Yashvi", LastName = "Shah", DateOfBirth = new DateTime(2001,05,15), MobileNo = "+91 4274563215", Email = "yashvi@gmail.com" },
       };
        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves the list of students.
        /// </summary>
        /// <returns>The list of students.</returns>
        public List<Student> GetList()
        {
            return _lstStudent;
        }

        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve.</param>
        /// <returns>The student if found, otherwise null.</returns>
        public Student GetStudentById(int id)
        {
            return _lstStudent.Find(s => s.Id == id);
        }

        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        /// <param name="id">The ID of the student to delete.</param>
        /// <returns>The deleted student if found, otherwise null.</returns>
        public Student Delete(int id)
        {
            // Gets the student by ID.
            var student = GetStudentById(id);

            // If the student exists, removes it and returns it.
            // Otherwise, returns null.
            if (student == null)
            {
                return null;
            }
            _lstStudent.Remove(student);

            return student;
        }

        /// <summary>
        /// Adds a new student.
        /// </summary>
        /// <param name="objStudent">The student object to add.</param>
        /// <returns>The added student if successful, otherwise null.</returns>
        public Student AddStudent(Student objStudent)
        {
            if (objStudent != null)
            {
                objStudent.Id = GetNextStudentId();
                _lstStudent.Add(objStudent);
                return objStudent;
            }
            else
                return null;
        }

        /// <summary>
        /// Updates a student's information.
        /// </summary>
        /// <param name="id">The ID of the student to update.</param>
        /// <param name="objStudent">The updated student object.</param>
        /// <returns>The updated student if successful, otherwise null.</returns>
        public Student UpdateStudent(int id, Student objStudent)
        {
            // Gets the existing student by ID.
            var existStudent = GetStudentById(id);

            // If the student exists, updates its information and returns it.
            // Otherwise, returns null.
            if (existStudent == null)
            {
                return null;
            }

            existStudent.FirstName = objStudent.FirstName;
            existStudent.LastName = objStudent.LastName;
            existStudent.DateOfBirth = objStudent.DateOfBirth;
            existStudent.Email = objStudent.Email;
            existStudent.MobileNo = objStudent.MobileNo;

            return existStudent;
        }

        #endregion

        #region Private method
        /// <summary>
        /// Gets the next available student ID.
        /// </summary>
        private int GetNextStudentId()
        {
            return _lstStudent.Count + 1;
        }
        #endregion
    }
}