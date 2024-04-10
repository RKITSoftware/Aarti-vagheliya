using ORMDemo.BL;
using ORMDemo.Models;
using System.Web.Http;

namespace ORMDemo.Controllers
{
    /// <summary>
    /// Controller for handling CRUD operations related to students.
    /// </summary>
    [RoutePrefix("api/Student")]
    public class CLSTD01Controller : ApiController
    {
        //Create instance of BLStudent class
        private readonly BLSTD01 objBLStudent;

        /// <summary>
        /// Initialize object of BLSTD01
        /// </summary>
        public CLSTD01Controller()
        {
            objBLStudent = new BLSTD01();
        }

        #region GetAll

        /// <summary>
        /// Gets all data of students
        /// </summary>
        /// <returns>List of students</returns>
        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(objBLStudent.Select());
        }

        #endregion

        #region AddStudent

        /// <summary>
        /// Adds student into the list
        /// </summary>
        /// <param name="objSTD01">Object of class STD01 to be added</param>
        /// <returns>Appropriate message</returns>
        [HttpPost]
        [Route("AddStudent")]
        public IHttpActionResult AddStudent(STD01 objSTD01)
        {
            return Ok(objBLStudent.Insert(objSTD01));
        }

        #endregion

        #region EditStudent

        /// <summary>
        /// Edits student in the list
        /// </summary>
        /// <param name="objSTD01">Object of class STD01 to be edited</param>
        /// <returns>Appropriate message</returns>
        [HttpPut]
        [Route("EditStudent")]
        public IHttpActionResult EditStudent(STD01 objSTD01)
        {
            return Ok(objBLStudent.Update(objSTD01));
        }

        #endregion

        #region DeleteStudent

        /// <summary>
        /// Deletes student from the list
        /// </summary>
        /// <param name="id">ID of student to be deleted</param>
        /// <returns>Appropriate message</returns>
        [HttpDelete]
        [Route("DeleteStudent")]
        public IHttpActionResult DeleteStudent(int id)
        {
            return Ok(objBLStudent.Delete(id));
        }

        #endregion
    }
}
