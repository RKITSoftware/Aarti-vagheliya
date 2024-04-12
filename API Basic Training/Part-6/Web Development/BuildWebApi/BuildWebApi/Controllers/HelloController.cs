using System.Web.Http;

namespace BuildWebApi.Controllers
{
    /// <summary>
    /// Simple demo class 
    /// </summary>
    public class HelloController : ApiController
    {
        /// <summary>
        /// Simple get method
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            return "Hello RKITians.....!";
        }
    }
}
