using HttpResponseMethod.Models;
using System;
using System.Collections.Generic;

namespace HttpResponseMethod.BL
{
    /// <summary>
    /// Business logic class for managing student data.
    /// </summary>
    public class BLStudent
    {
        #region Private Member
        // Static list to store student data.
        private static List<Student> _lstStudents = new List<Student>
        {
            // Initialize with some sample student data.
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Arti", LastName = "Vagheliya", DateOfBirth = new DateTime(2002, 09, 25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Krinsi", LastName = "Kayada", DateOfBirth = new DateTime(2003, 08, 17), MobileNo = "+91 9852563215", Email = "krinsi@gmail.com" },
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Ishika", LastName = "Jethwa", DateOfBirth = new DateTime(2002, 07, 18), MobileNo = "+91 9874565215", Email = "ishika@gmail.com" },
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Dimple", LastName = "Mithiya", DateOfBirth = new DateTime(2003, 06, 05), MobileNo = "+91 9874598215", Email = "dimple@gmail.com" },
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Yashvi", LastName = "Shah", DateOfBirth = new DateTime(2001, 05, 15), MobileNo = "+91 4274563215", Email = "yashvi@gmail.com" },
        };
        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all students.
        /// </summary>
        /// <returns>List of students.</returns>
        public List<Student> GetStudents()
        {
            return _lstStudents;
        }

        /// <summary>
        /// Retrieves a single student by ID.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve.</param>
        /// <returns>The student if found, otherwise null.</returns>
        public Student GetOneStudent(int id)
        {
            // Gets the student by ID.
            var student = GetStudentById(id);

            return student != null ? student : null;

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

            if (student != null)
            {
                _lstStudents.Remove(student);
                return student;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Adds a new student.
        /// </summary>
        /// <param name="objStudent">The student object to add.</param>
        /// <returns>The added student if successful, otherwise null.</returns>
        public Student AddNewStudent(Student objStudent)
        {
            if (objStudent != null)
            {
                objStudent.Id = Generator.GetNextStudentId();
                _lstStudents.Add(objStudent);
                return objStudent;
            }
            else
            {
                return null;
            }
            
        }

        /// <summary>
        /// Updates student details.
        /// </summary>
        /// <param name="id">The ID of the student to update.</param>
        /// <param name="objStudent">The updated student object.</param>
        /// <returns>The updated student if successful, otherwise null.</returns>
        public Student UpdateDetails(int id, Student objStudent)
        {
            var findStudent = GetStudentById(id);

            if (findStudent != null)
            {
                findStudent.FirstName = objStudent.FirstName;
                findStudent.LastName = objStudent.LastName;
                findStudent.DateOfBirth = objStudent.DateOfBirth;
                findStudent.Email = objStudent.Email;
                findStudent.MobileNo = objStudent.MobileNo;
                return findStudent;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        private Student GetStudentById(int id)
        {
            return _lstStudents.Find(s => s.Id == id);
        }
        #endregion
    }

    /// <summary>
    /// Helper class for generating student IDs.
    /// </summary>
    public class Generator
    {
        // Static variable to track the next student ID.
        private static int count = 0;

        #region GetNextStudentId

        /// <summary>
        /// Gets the next available student ID.
        /// </summary>
        public static int GetNextStudentId()
        {
            // Increments and returns the count.
            return count++;
        }
        #endregion
    }
}