using Authentication.BasicAuthentication;
using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Authentication.Controllers
{
    /// <summary>
    /// Controller for handling student-related operations.
    /// </summary>
    [BasicAuthenticationAttribute]
    public class StudentController : ApiController
    {
        /// <summary>
        /// Gets the details of all students.
        /// </summary>
        /// <returns>Returns a list of student details.</returns>
        public IHttpActionResult StudentsDetail()
        {
            List<Student> objStudent = new List<Student>()
            {
               new Student { Id = 1,  FirstName = "Arti", LastName = "Vagheliya", DateOfBirth = new DateTime(2002,09,25), MobileNo = "+91 9874563215", Email = "arti@gmail.com" },
               new Student { Id = 2,  FirstName = "Krinsi", LastName = "Kayada", DateOfBirth = new DateTime(2003,08,17), MobileNo = "+91 9852563215", Email = "krinsi@gmail.com" },
               new Student { Id = 3,   FirstName = "Ishika", LastName = "Jethwa", DateOfBirth = new DateTime(2002,07,18), MobileNo = "+91 9874565215", Email = "ishika@gmail.com" },
               new Student { Id = 4,   FirstName = "Dimple", LastName = "Mithiya", DateOfBirth = new DateTime(2003,06,05), MobileNo = "+91 9874598215", Email = "dimple@gmail.com" },
               new Student { Id = 5,   FirstName = "Yashvi", LastName = "Shah", DateOfBirth = new DateTime(2001,05,15), MobileNo = "+91 4274563215", Email = "yashvi@gmail.com" },
            };
            return Ok(objStudent);
        }

    }
}
