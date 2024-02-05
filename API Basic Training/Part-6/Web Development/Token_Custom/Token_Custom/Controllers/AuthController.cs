using System.Linq;
using System.Web.Http;
using Token_Custom.Auth;
using Token_Custom.Filters;
using Token_Custom.Models;
using Token_Custom.Services;

namespace Token_Custom.Controllers
{
    /// <summary>
    /// Controller for handling authentication-related operations.
    /// </summary>

    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// Generates a JWT token based on the provided credentials.
        /// </summary>
        /// <returns>JWT token if authentication is successful, BadRequest otherwise.</returns>
        [HttpPost]
        [Route("GetToken")]
        [JwtAuthenticationFilter]
        public IHttpActionResult GetToken()
        {
            // Extracts username and password from the authorization header
            string authToken = Request.Headers.Authorization.Parameter;

            string[] usernamepassword = authToken.Split(':');
            string username = usernamepassword[0];
            string password = usernamepassword[1];

            // Validates user credentials
            var userDetails = UserRepository.users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (userDetails != null)
            {
                // Generates and returns a JWT token for the authenticated user
                return Ok(TokenService.GenerateToken(username));
            }

            // Returns BadRequest if user details are invalid
            return BadRequest("Enter valid user details");
        }


        /// <summary>
        /// Retrieves some state data and requires Bearer token authentication with the "User" role.
        /// </summary>
        /// <returns>Some state data if authenticated and authorized, Unauthorized otherwise.</returns>
        [HttpGet]
        [Route("GetSomeState")]
        [BearerAuthentication]
        [Authorize(Roles = "User")]
        public IHttpActionResult GetSomeState()
        {
            // Your logic to fetch some state data (filtered by Key)
            var someState = StateDate.RetriveStateData().Where(u=>u.Key <=3 );
            return Ok(someState);
        }



        /// <summary>
        /// Retrieves all states and requires Bearer token authentication with the "Admin" role.
        /// </summary>
        /// <returns>All states if authenticated and authorized, Unauthorized otherwise.</returns>
        [HttpGet]
        [Route("GetStates")]
        [BearerAuthentication]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetStates()
        {
            // fetch all states
            var state = StateDate.RetriveStateData();
            return Ok(state);
        }
    }
}

