using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenBasedAuthentication.Data;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.Controllers
{
    
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/Student/OneStudent/{id}")]
        [Authorize(Roles = ("Student,Teacher"))]
       public HttpResponseMessage OneStudent(int id)
        {
           var student = StudentData.StudentsDetail().FirstOrDefault(stu => stu.Id ==  id);  
            return Request.CreateResponse(HttpStatusCode.OK,student);
        }

        [Authorize(Roles = ("Teacher"))]
        [Route("api/Student/FewStudents")]
        public HttpResponseMessage FewStudents()
        {
            var student = StudentData.StudentsDetail().Where(stu => stu.Id < 6);
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        [Authorize(Roles = ("Principal"))]
        [Route("api/Student/AllStudents")]
        public HttpResponseMessage AllStudents()
        {
            var student = StudentData.StudentsDetail().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, student);
        }
    }
}
