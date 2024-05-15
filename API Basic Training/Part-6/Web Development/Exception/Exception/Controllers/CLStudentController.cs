using Exception.BL;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exception.Controllers
{
    /// <summary>
    /// Controller for handling exceptions in the context of student data.
    /// </summary>
    public class CLStudentController : ApiController
    {
        /// <summary>
        /// Private object of BLStudent class.
        /// </summary>
        private BLStudent _objBLStudent = new BLStudent();

        #region Constructor for Handler Exception

        /// <summary>
        /// Constructor throwing an exception for demonstration purposes
        /// </summary>
        /// <exception cref="HttpListenerException"></exception>
        //public CLStudentController()
        //{
        //    throw new HttpListenerException();
        //}
        #endregion



        #region HTTPError type Exception
        /// <summary>
        /// Retrieves student data by ID using HTTPError type exception handling.
        /// </summary>
        //HTTPError type Exception
        [HttpGet]
        [Route("api/Student/Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            // Retrieve student data by ID
            var data = _objBLStudent.student.FirstOrDefault(obj => obj.Id == id);

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
            var data = _objBLStudent.student.FirstOrDefault(obj => obj.Id == id);

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
            var data = _objBLStudent.studentException.FirstOrDefault(obj => obj.Id == id);

            // Return response with student data (null for demonstration)
            return Ok(data);
        }
        #endregion

        #region Exception Handler

        /// <summary>
        /// Throws a DivideByZeroException for demonstration purposes.
        /// </summary>
        // any exception can handle by handler 
        [HttpGet]
        [Route("api/cef")]
        public IHttpActionResult Get()
        {
            throw new DivideByZeroException();
        }
        #endregion
    }
}
