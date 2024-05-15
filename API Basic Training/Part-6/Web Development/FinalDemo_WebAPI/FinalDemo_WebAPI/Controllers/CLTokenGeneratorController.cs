using FinalDemo_WebAPI.BL;
using FinalDemo_WebAPI.Models;
using FinalDemo_WebAPI.ServiceProvider;
using System;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace FinalDemo_WebAPI.Controllers
{
    /// <summary>
    /// Controller that generates Token for user
    /// </summary>
    public class CLTokenGeneratorController : ApiController
    {
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
            // Extracts the authentication token from the request header
            string authToken = Request.Headers.Authorization.Parameter;

            // Decodes the base64-encoded token
            byte[] authByte = Convert.FromBase64String(authToken); 
            authToken = Encoding.UTF8.GetString(authByte); // Converts the byte array to a string
           
            string[] usernamepassword = authToken.Split(':'); // Splits the username and password
            string username = usernamepassword[0]; // Retrieves the username
            string password = usernamepassword[1]; // Retrieves the password

            // Retrieves the user from the database based on the provided credentials
            User user = BLUser.lstUsers.FirstOrDefault(u => u.UserName == username && u.PassWord == password);

            if (user != null) // Checks if the user exists
            {
                return Ok(BLTokenManager.GenerateToken(username)); // Returns the generated token
            }
            return BadRequest("Enter valid user details."); // Returns a bad request response for invalid user details
        }

        #endregion
    }
}
