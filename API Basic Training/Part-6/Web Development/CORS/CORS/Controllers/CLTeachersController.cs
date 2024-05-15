using CORS.BL;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CORS.Controllers
{
    // Enable CORS for the entire controller allowing all origins, headers, and methods.
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    /// <summary>
    /// Controller responsible for handling teacher-related HTTP requests.
    /// </summary>
    public class CLTeachersController : ApiController
    {
        //Private object of BLTeacher
        private BLTeachers _objBLTeachers = new BLTeachers();

        /// <summary>
        /// Handles HTTP GET requests to the endpoint 'api/Teachers'.
        /// </summary>
        /// <returns>HTTP response with the list of teachers.</returns>
        // GET api/Teachers
        [HttpGet]
        //[DisableCors]
        public IHttpActionResult Get()
        {
            return Ok(_objBLTeachers.GetTeachers());
        }


        /// <summary>
        /// Handles HTTP POST requests to the endpoint 'api/Teachers'.
        /// </summary>
        /// <param name="teacher">The teacher's name to be added.</param>
        /// <returns>HTTP response indicating the success of the operation.</returns>
        [DisableCors] // Disable CORS for this specific action.
        // POST api/Teachers
        public IHttpActionResult Post([FromBody] string teacher)
        {
            _objBLTeachers.Add(teacher);
            return Ok($"Added: {teacher}");
        }
    }
}
