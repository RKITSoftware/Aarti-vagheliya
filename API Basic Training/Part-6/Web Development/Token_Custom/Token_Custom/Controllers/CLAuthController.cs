using System;
using System.Linq;
using System.Text;
using System.Web.Http;
using Token_Custom.Auth;
using Token_Custom.BL;
using Token_Custom.Filters;
using Token_Custom.Services; 

namespace Token_Custom.Controllers
{
    /// <summary>
    /// Controller for handling authentication-related operations.
    /// </summary>

    [RoutePrefix("api/auth")]
    public class CLAuthController : ApiController
    {
        /// <summary>
        /// Private instance of BLStateData class.
        /// </summary>
        private BLStateData _objBLStateData = new BLStateData();

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
            string parameter = Request.Headers.Authorization.Parameter;

            byte[] authByte = Convert.FromBase64String(parameter); // Decodes the base64-encoded token
            string authToken = Encoding.UTF8.GetString(authByte); // Converts the byte array to a string
           
            string[] usernamepassword = authToken.Split(':');
            string username = usernamepassword[0];
            string password = usernamepassword[1];

            // Validates user credentials
            var userDetails = BLUser.users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (userDetails != null)
            {
                // Generates and returns a JWT token for the authenticated user
                return Ok(TokenService.GenerateToken(username));
            }

            // Returns BadRequest if user details are invalid
            return BadRequest("Enter valid user details");
        }


        /// <summary>
        /// Retrieves some state data and requires Bearer token authentication with the "User" and "Admin" role.
        /// </summary>
        /// <returns>Some state data if authenticated and authorized, Unauthorized otherwise.</returns>
        [HttpGet]
        [Route("GetSomeState")]
        [BearerAuthentication]
        [Authorize(Roles = "User,Admin")]
        public IHttpActionResult GetSomeState()
        {
            // logic to fetch some state data (filtered by Key)
            var someState = _objBLStateData.RetriveStateData().Where(u => u.Key <= 3 );
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
            var state = _objBLStateData.RetriveStateData();
            return Ok(state);
        }
    }
}

