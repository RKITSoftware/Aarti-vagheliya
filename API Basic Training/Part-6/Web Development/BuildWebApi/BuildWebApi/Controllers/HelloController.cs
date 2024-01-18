using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
