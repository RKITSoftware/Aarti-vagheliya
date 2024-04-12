using HttpResponseMethod.BL;
using HttpResponseMethod.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HttpResponseMethod.Controllers
{
    /// <summary>
    /// API controller for managing student data.
    /// </summary>
    [RoutePrefix("api/CLStudent")]
    public class CLStudentController : ApiController
    {
        #region Private member

        /// <summary>
        /// Private object of bLStudent class 
        /// </summary>
        private BLStudent _objBLStudent = new BLStudent();

        #endregion

        #region Public Methods
        #region Get
        /// <summary>
        /// Retrieves all students.
        /// </summary>
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            // Returns a response with the list of students.
            return Request.CreateResponse(HttpStatusCode.OK, _objBLStudent.GetStudents());
        }
        #endregion

        #region GetById
        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        [HttpGet]
        [Route("GetbyId")]
        public HttpResponseMessage GetById([FromBody] int id)
        {
            // Gets the student by ID.
            var student = _objBLStudent.GetOneStudent(id);

            // Returns either the student or a "Not Found" response.
            return student != null ? Request.CreateResponse(HttpStatusCode.OK, student) : Request.CreateResponse(HttpStatusCode.NotFound);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        [HttpDelete]
        [Route("Delete/{id}")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            // Gets the student by ID.
            var student = _objBLStudent.Delete(id);

            // If the student exists, removes it and returns an "OK" response.
            // Otherwise, returns a "Not Found" response.
            if (student != null)
            {
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
        [Route("Post")]
        public HttpResponseMessage Post([FromBody] Student student)
        {
            // If the incoming student is not null, assigns a new ID and adds it to the list.
            // Returns either the added student or a "Bad Request" response.
            var newStudent = _objBLStudent.AddNewStudent(student);
            if (newStudent != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, newStudent);
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
        [Route("Put/{id}")]
        public HttpResponseMessage Put(int id, Student updatedStudent)
        {
            // Gets the existing student by ID.
            var existingStudent = _objBLStudent.UpdateDetails(id, updatedStudent);

            // If the student exists, updates its properties and returns an "OK" response.
            // Otherwise, returns a "Not Found" response.
            if (existingStudent != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, existingStudent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        #endregion

        #endregion
    }
}
