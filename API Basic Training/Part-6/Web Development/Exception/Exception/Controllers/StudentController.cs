using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exception.Models;

namespace Exception.Controllers
{
    /// <summary>
    /// Controller for handling exceptions in the context of student data.
    /// </summary>
    public class StudentController : ApiController
    {
        #region Constructor for Handler Exception
        // Constructor throwing an exception for demonstration purposes
        public StudentController() 
        { 
            throw new HttpListenerException();
        }
        #endregion

        #region Student Data
        // Student data collection
        public static List<Student> student =  new List<Student>
        {
            new Student { Id = 1, Name = "ABC", Department = "CE"},
            new Student { Id = 2, Name = "PQR", Department = "ME"},
            new Student { Id = 3, Name = "XYZ", Department = "Pharmacy" },
        };
        #endregion

        #region Null student data
        // for Exception filter
        // Exception collection for demonstration purposes
        public static List<Student> studentException = null;
        #endregion

        #region HTTPError type Exception
        /// <summary>
        /// Retrieves student data by ID using HTTPError type exception handling.
        /// </summary>
        //HTTPError type Exception
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            // Retrieve student data by ID
            var data = student.FirstOrDefault(obj => obj.Id == id);

            // Check if data is not found and return appropriate response
            if (data == null)
            {
                var errorMsg = string.Format($"data is not found for id {id}");
                return Request.CreateResponse(HttpStatusCode.NotFound, errorMsg);
            }

            // Return success response with student data
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        #endregion

        #region HttpResponse Exception

        /// <summary>
        /// Retrieves student data by ID using HttpResponseException type exception handling.
        /// </summary>
        //HttpResponse Exception
        [Route("api/Student/GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            // Retrieve student data by ID
            var data = student.FirstOrDefault(obj => obj.Id == id);

            // Check if data is not found and throw HttpResponseException
            if (data == null)
            {
                var errorMsg = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format($"data is not found for id {id} by HttpResponseException ")),
                    ReasonPhrase = "data not found"
                };
                throw new HttpResponseException(errorMsg);
            }

            // Return success response with student data
            return Ok(data);
        }
        #endregion

        #region Exception Filter 

        /// <summary>
        /// Demonstrates exception handling using a custom exception filter.
        /// </summary>
        // Exception Filter 
        // when data is null then it will throw this error
        [HttpGet]
        [CustomException.CustomExceptionFilter]
        [Route("api/Student/FilterException/{id}")]
        public IHttpActionResult FilterException(int id)
        {
            // Retrieve student data by ID (using null collection for demonstration)
            var data = studentException.FirstOrDefault(obj => obj.Id == id);

            // Return response with student data (null for demonstration)
            return Ok(data);
        }
        #endregion

        #region Exception Handler

        /// <summary>
        /// Throws a DivideByZeroException for demonstration purposes.
        /// </summary>
        // any exception can handle by hamdler 
        [Route("api/cef")]
        public IHttpActionResult Get()
        {
            throw new DivideByZeroException();
        }
        #endregion
    }
}
