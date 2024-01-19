using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CORS.Controllers
{
    // Enable CORS for the entire controller allowing all origins, headers, and methods.
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    /// <summary>
    /// Controller responsible for handling test-related HTTP requests.
    /// </summary>
    public class TestController : ApiController
    {
        /// <summary>
        /// Handles HTTP GET requests to the endpoint 'api/Test/get'.
        /// </summary>
        /// <returns>HTTP response message with a GET-specific test message.</returns>
        [HttpGet]
        [Route("api/Test/get")]
        public HttpResponseMessage Get()
        {
            // Create a response message with a GET-specific test message.
            return new HttpResponseMessage()
            {
                Content = new StringContent("GET: Test message")
            };
        }


        /// <summary>
        /// Handles HTTP POST requests to the endpoint 'api/Test/post'.
        /// </summary>
        /// <returns>HTTP response message with a POST-specific test message.</returns>
        [Route("api/Test/post")]
        [DisableCors] // This specific action is exempted from CORS policy
        public HttpResponseMessage Post()
        {
            // Create a response message with a POST-specific test message.
            return new HttpResponseMessage()
            {
                Content = new StringContent("POST: Test message")
            };
        }



        /// <summary>
        /// Handles HTTP PUT requests to the endpoint 'api/Test/put'.
        /// </summary>
        /// <returns>HTTP response message with a PUT-specific test message.</returns>
        [Route("api/Test/put")]
        [DisableCors] // This specific action is exempted from CORS policy
        public HttpResponseMessage Put()
        {
            // Create a response message with a PUT-specific test message.
            return new HttpResponseMessage()
            {
                Content = new StringContent("PUT: Test message")
            };
        }
    }
}

