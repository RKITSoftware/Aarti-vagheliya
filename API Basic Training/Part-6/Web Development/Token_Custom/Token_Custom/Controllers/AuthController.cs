using System.Linq;
using System.Web.Http;
using Token_Custom.Auth;
using Token_Custom.Filters;
using Token_Custom.Models;
using Token_Custom.Services;

namespace Token_Custom.Controllers
{


    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {

        [HttpPost]
        [Route("GetToken")]
        [JwtAuthenticationFilter]
        public IHttpActionResult GetToken()
        {
            string authToken = Request.Headers.Authorization.Parameter;

            string[] usernamepassword = authToken.Split(':');
            string username = usernamepassword[0];
            string password = usernamepassword[1];
            var userDetails = UserRepository.users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (userDetails != null)
            {
                return Ok(TokenService.GenerateToken(username));
            }
            return BadRequest("Enter valid user details");
        }

        [HttpGet]
        [Route("GetSomeState")]
        [BearerAuthentication]
        [Authorize(Roles = "User")]
        public IHttpActionResult GetSomeState()
        {
            // Your logic to fetch products
            var someState = StateDate.RetriveStateData().Where(u=>u.Key <=3 );
            return Ok(someState);
        }

        [HttpGet]
        [Route("GetStates")]
        [BearerAuthentication]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetStates()
        {
            // Your logic to fetch States
            var state = StateDate.RetriveStateData();
            return Ok(state);
        }
    }
}

