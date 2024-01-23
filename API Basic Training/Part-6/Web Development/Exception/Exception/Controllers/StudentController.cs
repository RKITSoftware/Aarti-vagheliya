using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exception.Models;

namespace Exception.Controllers
{
    public class StudentController : ApiController
    {
        public static List<Student> student = new List<Student>
        {
            new Student { Id = 1, Name = "ABC", Department = "CE"},
            new Student { Id = 2, Name = "PQR", Department = "ME"},
            new Student { Id = 3, Name = "XYZ", Department = "Pharmacy"},
        };


        //HTTPError type Exception
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = student.FirstOrDefault(obj => obj.Id == id);
            if (data == null)
            {
                var errorMsg = string.Format($"data is not found for id {id}");
                return Request.CreateResponse(HttpStatusCode.NotFound, errorMsg);
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //HttpResponse Exception
        [Route("api/Student/GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var data = student.FirstOrDefault(obj => obj.Id == id);
            if(data == null)
            {
                var errorMsg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"data is not found for id {id} by HttpResponseException ")),
                    ReasonPhrase = "data not found"
                };
                throw new HttpResponseException(errorMsg);
            }
            return Ok(data);
        }
    }
}
