using Authorization.BasicAuthentication;
using Authorization.BL;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Authorization.Controllers
{
    /// <summary>
    /// Controller responsible for managing student details with basic authentication and authorization.
    /// </summary>

    [RoutePrefix("api/Student")]
    [BasicAuthenticationAttribute]
    public class CLStudentController : ApiController
    {
        //Private Object for BLStudent class.
        private BLStudent _objBLStudent = new BLStudent();


        #region OneStudentDetails
        /// <summary>
        /// Gets details of a single student based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>HTTP response with the student details if found, otherwise returns NotFound.</returns>
        [HttpGet]
        [Route("OneStudentDetails/{id}")]
        [BasicAuthorizationAttribute(Roles = "Principal,Teacher,Student")]
        public HttpResponseMessage OneStudentDetails(int id)
        {
            // Gets the student by ID.
            return Request.CreateResponse(HttpStatusCode.OK, _objBLStudent.StudentsDetail().FirstOrDefault(s => s.Id == id));
           
        }
        #endregion

        #region FewStudentsDetails

        /// <summary>
        /// Gets details of a few students, intended for authorized users with roles Principal or Teacher.
        /// </summary>
        /// <returns>HTTP response with details of selected students.</returns>
        [HttpGet]
        [Route("FewStudentsDetails")]
        [BasicAuthorizationAttribute(Roles = "Principal,Teacher")]
        public HttpResponseMessage FewStudentsDetails()
        {
            // Retrieves details of students with ID less than 5.
            return Request.CreateResponse(HttpStatusCode.OK, _objBLStudent.StudentsDetail().Where(s => s.Id < 5));
        }

        #endregion

        #region AllStudentsDetails

        /// <summary>
        /// Gets details of all students, intended for authorized users with the role Principal.
        /// </summary>
        /// <returns>HTTP response with details of all students.</returns>
        [HttpGet]
        [Route("AllStudentsDetails")]
        [BasicAuthorizationAttribute(Roles = "Principal")]
        public HttpResponseMessage AllStudentsDetails()
        {
            // Retrieves details of all students.
            return Request.CreateResponse(HttpStatusCode.OK, _objBLStudent.StudentsDetail());
        }
        #endregion

    }
}
