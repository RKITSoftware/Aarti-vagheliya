using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Controller for managing user operations
    /// </summary>
    [RoutePrefix("api/user")]
    public class CLUserController : ApiController
    {
        #region Private member

        // Instance of the user business logic class
        private readonly BLUser _objBLUser;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialize BLUser instance
        /// </summary>
        public CLUserController()
        {
            _objBLUser = new BLUser();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet]
        [Route("getAll")]
        //[BearerAuthentication]
        //[Authorize(Roles = ("Admin"))]
        public IHttpActionResult GetAllUsers()
        {
            List<USR01> users = _objBLUser.GetAllUsers(); // Retrieves all users from the database
            return Ok(users); // Returns the list of users
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user">User object to add</param>
        /// <returns>Success message or error</returns>
        [HttpPost]
        [Route("add")]
        //[BearerAuthentication]
        //[Authorize(Roles = ("Admin"))]
        public IHttpActionResult AddUser(USR01 user)
        {
            string result = _objBLUser.Insert(user);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="id">ID of the user to update</param>
        /// <param name="user">User object with updated data</param>
        /// <returns>Success message or error</returns>
        [HttpPut]
        [Route("update")]
        //[BearerAuthentication]
        //[Authorize(Roles = ("Admin"))]
        public IHttpActionResult UpdateUser(int id, USR01 user)
        {
            user.R01F01 = id; // Ensure the correct ID is set
            string result = _objBLUser.Update(user);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a user by ID
        /// </summary>
        /// <param name="id">ID of the user to delete</param>
        /// <returns>Success message or error</returns>
        [HttpDelete]
        [Route("delete")]
        //[BearerAuthentication]
        //[Authorize(Roles = ("Admin"))]
        public IHttpActionResult DeleteUser(int id)
        {
            string result = _objBLUser.Delete(id);
            return Ok(result);
        }

        #endregion
    }
}
