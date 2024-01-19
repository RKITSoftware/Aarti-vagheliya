using HttpResponseMethod.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpResponseMethod.Controllers
{
    /// <summary>
    /// API controller for managing student data.
    /// </summary>
    public class StudentController : ApiController
    {
        #region Student List
        // Static list to store student data.
        private static List<Student> _students = new List<Student>
        {
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Arti", LastName = "Vagheliya", DateOfBirth = new DateTime(2002, 09, 25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Krinsi", LastName = "Kayada", DateOfBirth = new DateTime(2003, 08, 17), MobileNo = "+91 9852563215", Email = "krinsi@gmail.com" },
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Ishika", LastName = "Jethwa", DateOfBirth = new DateTime(2002, 07, 18), MobileNo = "+91 9874565215", Email = "ishika@gmail.com" },
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Dimple", LastName = "Mithiya", DateOfBirth = new DateTime(2003, 06, 05), MobileNo = "+91 9874598215", Email = "dimple@gmail.com" },
            new Student { Id = Generator.GetNextStudentId(), FirstName = "Yashvi", LastName = "Shah", DateOfBirth = new DateTime(2001, 05, 15), MobileNo = "+91 4274563215", Email = "yashvi@gmail.com" },
        };
        #endregion

        #region Get
        /// <summary>
        /// Retrieves all students.
        /// </summary>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            // Returns a response with the list of students.
            return Request.CreateResponse(HttpStatusCode.OK, _students);
        }
        #endregion

        #region GetById
        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            // Gets the student by ID.
            var student = GetStudentById(id);
           
            // Returns either the student or a "Not Found" response.
            return student != null ? Request.CreateResponse(HttpStatusCode.OK, student) : Request.CreateResponse(HttpStatusCode.NotFound);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            // Gets the student by ID.
            var student = GetStudentById(id);

            // If the student exists, removes it and returns an "OK" response.
            // Otherwise, returns a "Not Found" response.
            if (student != null)
            {
                _students.Remove(student);
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Adds a new student.
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Post(Student student)
        {
            // If the incoming student is not null, assigns a new ID and adds it to the list.
            // Returns either the added student or a "Bad Request" response.
            if (student != null)
            {
                student.Id = Generator.GetNextStudentId();
                _students.Add(student);
                return Request.CreateResponse(HttpStatusCode.Created, student);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Put
        /// <summary>
        /// Updates a student by ID.
        /// </summary>
        [HttpPut]
        public HttpResponseMessage Put(int id, Student updatedStudent)
        {
            // Gets the existing student by ID.
            var existingStudent = GetStudentById(id);

            // If the student exists, updates its properties and returns an "OK" response.
            // Otherwise, returns a "Not Found" response.
            if (existingStudent != null)
            {
                existingStudent.FirstName = updatedStudent.FirstName;
                existingStudent.LastName = updatedStudent.LastName;
                existingStudent.DateOfBirth = updatedStudent.DateOfBirth;
                existingStudent.Email = updatedStudent.Email;
                existingStudent.MobileNo = updatedStudent.MobileNo;

                return Request.CreateResponse(HttpStatusCode.OK, existingStudent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        #endregion

        #region GetStudentById
        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        private Student GetStudentById(int id)
        {
            return _students.Find(s => s.Id == id);
        }
        #endregion

    }

    /// <summary>
    /// Helper class for generating student IDs.
    /// </summary>
    public class Generator : ApiController
    {
        // Static variable to track the next student ID.
        public static int count = 0;

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
