using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenBasedAuthentication.BL;


namespace TokenBasedAuthentication.Controllers
{
    /// <summary>
    /// Controller for managing student-related operations with token-based authentication.
    /// </summary>   
    public class CLStudentController : ApiController
    {
        /// <summary>
        /// Private object of BLStudent class.
        /// </summary>
        private BLStudent _objBLStudent = new BLStudent();

        #region getOneStudent

        /// <summary>
        /// Retrieves details of a specific student by ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>HTTP response message containing student details.</returns>

        [HttpGet]
        [Route("api/Student/OneStudent/{id}")]
        [Authorize(Roles = ("Student,Teacher,Principal"))]
       public HttpResponseMessage OneStudent(int id)
        {
            // Retrieve the student details based on the provided ID
            var student = _objBLStudent.StudentsDetail().FirstOrDefault(stu => stu.Id ==  id);

            // Return an HTTP response with the student details
            return Request.CreateResponse(HttpStatusCode.OK,student);
        }
        #endregion

        #region getFewStudents

        /// <summary>
        /// Retrieves information for a few students based on predefined criteria.
        /// </summary>
        /// <returns>HTTP response containing details of selected students.</returns>

        [HttpGet]
        [Authorize(Roles = ("Teacher,Principal"))]
        [Route("api/Student/FewStudents")]
        public HttpResponseMessage FewStudents()
        {
            // Retrieve information for students with IDs less than 6
            var student = _objBLStudent.StudentsDetail().Where(stu => stu.Id < 6);

            // Return an HTTP response with the selected student details
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }
        #endregion

        #region getAllStudents

        /// <summary>
        /// Retrieves information for all students. Accessible only to users with the "Principal" role.
        /// </summary>
        /// <returns>HTTP response containing details of all students.</returns>

        [HttpGet]
        [Authorize(Roles = ("Principal"))]
        [Route("api/Student/AllStudents")]
        public HttpResponseMessage AllStudents()
        {
            // Retrieve information for all students
            var student = _objBLStudent.StudentsDetail().ToList();

            // Return an HTTP response with the details of all students
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }
        #endregion

    }
}
