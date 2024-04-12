using ActionMethodResponse.BL;
using ActionMethodResponse.Models;
using System.Web.Http;

namespace ActionMethodResponse.Controllers
{
    /// <summary>
    /// API controller for managing student data.
    /// </summary>
    [RoutePrefix("api/CLStudent")]
    public class CLStudentController : ApiController
    {
        #region Private Member
        //Private object of BLStudent class.
        private BLStudent _objBlStudent = new BLStudent();
        #endregion

        #region public Methods

        #region Get
        /// <summary>
        /// Retrieves all students.
        /// </summary>
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            // Returns an HTTP 200 OK response with the list of students.
            return Ok(_objBlStudent.GetList());
        }
        #endregion

        #region GetById
        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetById([FromBody] int id)
        {
            // Gets the student by ID.
            var student = _objBlStudent.GetStudentById(id);

            // Returns either the student or a "Not Found" response.
            return Ok(student);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            // Gets the student by ID.
            var student = _objBlStudent.Delete(id);

            // If the student exists, returns an "OK" response.
            // Otherwise, returns a "Not Found" response.
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }
        #endregion

        #region Post
        /// <summary>
        /// Adds a new student.
        /// </summary>
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(Student student)
        {
            //Add new Student
            var newStudent = _objBlStudent.AddStudent(student);

            // Returns either the added student or a "Not Found" response.
            if(newStudent == null)
            {
                return NotFound();
            }
          
            return Ok(newStudent);

        }
        #endregion

        #region Put
        /// <summary>
        /// Updates a student by ID.
        /// </summary>
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put(int id, Student updatedStudent)
        {
            //Update Student
            var existStudent = _objBlStudent.UpdateStudent(id, updatedStudent);

            // If the student exists, returns an "OK" response.
            // Otherwise, returns a "Not Found" response.
            if (existStudent == null)
            {
                return NotFound();
            }

            return Ok(existStudent);    

        }
        #endregion

        #endregion
    }
}
