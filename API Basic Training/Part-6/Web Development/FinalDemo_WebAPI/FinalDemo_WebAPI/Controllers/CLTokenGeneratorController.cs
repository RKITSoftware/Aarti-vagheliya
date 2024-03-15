using FinalDemo_WebAPI.DAL;
using FinalDemo_WebAPI.ServiceProvider;
using FinalDemo_WebAPI.UserRepository;
using System;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace FinalDemo_WebAPI.Controllers
{
    public class CLTokenGeneratorController : ApiController
    {
        #region Private member

        // Instance of the user business logic class
        private BLUser _objBLUser = new BLUser();

        #endregion

        #region Public Method

        /// <summary>
        /// Generates an authentication token for the specified user credentials.
        /// </summary>
        /// <returns>The authentication token.</returns>
        [HttpGet]
        [Route("api/TokenGenerator/token")]
        [BasicAuthentication]
        public IHttpActionResult GetToken()
        {
            string authToken = Request.Headers.Authorization.Parameter; // Extracts the authentication token from the request header
            byte[] authByte = Convert.FromBase64String(authToken); // Decodes the base64-encoded token
            authToken = Encoding.UTF8.GetString(authByte); // Converts the byte array to a string
            string[] usernamepassword = authToken.Split(':'); // Splits the username and password
            string username = usernamepassword[0]; // Retrieves the username
            string password = usernamepassword[1]; // Retrieves the password
            var user = _objBLUser.GetAllUsers().FirstOrDefault(u => u.UserName == username && u.PassWord == password); // Retrieves the user from the database based on the provided credentials

            if (user != null) // Checks if the user exists
            {
                return Ok(BLTokenManager.GenerateToken(username)); // Returns the generated token
            }
            return BadRequest("Enter valid user details."); // Returns a bad request response for invalid user details
        }

        #endregion
    }
}
