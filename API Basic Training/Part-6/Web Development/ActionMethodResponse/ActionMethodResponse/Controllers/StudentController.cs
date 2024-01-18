using ActionMethodResponse.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ActionMethodResponse.Controllers
{
    /// <summary>
    /// API controller for managing student data.
    /// </summary>
    public class StudentController : ApiController
    {
        #region Privete Student List
        // Static list to store student data.
        private static List<Student> _student = new List<Student>
       {
           new Student { Id = 1,  FirstName = "Arti", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
           new Student { Id = 2,  FirstName = "Krinsi", LastName = "Kayada", DateOfBirth = new DateTime(2003,08,17), MobileNo = "+91 9852563215", Email = "krinsi@gmail.com" },
           new Student { Id = 3,   FirstName = "Ishika", LastName = "Jethwa", DateOfBirth = new DateTime(2002,07,18), MobileNo = "+91 9874565215", Email = "ishika@gmail.com" },
           new Student { Id = 4,   FirstName = "Dimple", LastName = "Mithiya", DateOfBirth = new DateTime(2003,06,05), MobileNo = "+91 9874598215", Email = "dimple@gmail.com" },
           new Student { Id = 5,   FirstName = "Yashvi", LastName = "Shah", DateOfBirth = new DateTime(2001,05,15), MobileNo = "+91 4274563215", Email = "yashvi@gmail.com" },
       };
        #endregion


        #region Get
        /// <summary>
        /// Retrieves all students.
        /// </summary>
        [HttpGet]
        public IHttpActionResult Get()
        {
            // Returns an HTTP 200 OK response with the list of students.
            return Ok(_student);
        }
        #endregion

        #region GetById
        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            // Gets the student by ID.
            var student = GetStudentById(id);

            // Returns either the student or a "Not Found" response.
            return Ok(student);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            // Gets the student by ID.
            var student = GetStudentById(id);

            // If the student exists, removes it and returns an "OK" response.
            // Otherwise, returns a "Not Found" response.
            if (student == null)
            {
                return NotFound();
            }
            _student.Remove(student);

            return Ok(student);
        }
        #endregion

        #region Post
        /// <summary>
        /// Adds a new student.
        /// </summary>
        [HttpPost]
        public IHttpActionResult Post(Student student)
        {
            // If the incoming student is not null, assigns a new ID and adds it to the list.
            // Returns either the added student or a "Not Found" response.
            student.Id = GetNextStudentId();
            if(student == null)
            {
                return NotFound();
            }
            _student.Add(student);
            return Ok(student);

        }
        #endregion

        #region Put
        /// <summary>
        /// Updates a student by ID.
        /// </summary>
        [HttpPut]
        public IHttpActionResult Put(int id, Student updatedStudent)
        {
            // Gets the existing student by ID.
            var existStudent = GetStudentById(id);

            // If the student exists, updates its properties and returns an "OK" response.
            // Otherwise, returns a "Not Found" response.
            if (existStudent == null)
            {
                return NotFound();
            }

            existStudent.FirstName = updatedStudent.FirstName;
            existStudent.LastName = updatedStudent.LastName;
            existStudent.DateOfBirth = updatedStudent.DateOfBirth;
            existStudent.Email = updatedStudent.Email;
            existStudent.MobileNo = updatedStudent.MobileNo;

            return Ok(existStudent);    

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
