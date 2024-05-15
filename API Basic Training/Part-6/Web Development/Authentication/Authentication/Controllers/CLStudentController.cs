using Authentication.BasicAuthentication;
using Authentication.BL;
using System.Web.Http;

namespace Authentication.Controllers
{
    /// <summary>
    /// Controller for handling student-related operations.
    /// </summary>
    [BasicAuthenticationAttribute]
    [RoutePrefix("api/CLStudent")]
    public class CLStudentController : ApiController
    {
        /// <summary>
        /// Private object of BLStudent class.
        /// </summary>
        private BLStudent _objBLStudent = new BLStudent();

        /// <summary>
        /// Retrieves details of all students.
        /// </summary>
        /// <returns>An IHttpActionResult containing the details of all students.</returns>
        [HttpGet]
        [Route("StudentsDetail")]
        public IHttpActionResult StudentsDetail()
        {
            return Ok(_objBLStudent.GetStudents());
        }

    }
}
