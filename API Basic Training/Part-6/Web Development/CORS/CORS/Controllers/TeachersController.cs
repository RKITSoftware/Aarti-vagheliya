using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CORS.Controllers
{
    // Enable CORS for the entire controller allowing all origins, headers, and methods.
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    /// <summary>
    /// Controller responsible for handling teacher-related HTTP requests.
    /// </summary>
    public class TeachersController : ApiController
    {
        // Static list to store teacher names.
        private static List<String> _objTeacher = new List<String>
        {
            "Arti vagheliya",
            "Ishika Jethwa",
            "Krinsi Kayada"
        };


        /// <summary>
        /// Handles HTTP GET requests to the endpoint 'api/Teachers'.
        /// </summary>
        /// <returns>HTTP response with the list of teachers.</returns>
        // GET api/Teachers
        [HttpGet]
        //[DisableCors]
        public IHttpActionResult Get()
        {
            return Ok(_objTeacher);
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
            _objTeacher.Add(teacher);
            return Ok($"Added: {teacher}");
        }
    }
}
