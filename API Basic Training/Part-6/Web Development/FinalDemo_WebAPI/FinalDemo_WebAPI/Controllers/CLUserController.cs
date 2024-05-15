using FinalDemo_WebAPI.BL;
using FinalDemo_WebAPI.Models;
using System.Web.Http;

namespace FinalDemo_WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing users.
    /// </summary>
    [RoutePrefix("api/CLUser")]
    public class CLUserController : ApiController
    {
        #region Private member

        //Private instance of BLUser.
        private BLUser _objBLUser = new BLUser();

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>An IHttpActionResult containing the response with all users.</returns>
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            Response response = _objBLUser.GetAllUsers();
          
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>An IHttpActionResult containing the response with the user if found.</returns>
        [HttpGet]
        [Route("GetUserById/{userId}")]
        public IHttpActionResult GetUserById(int userId)
        {
            return Ok(_objBLUser.GetUserById(userId));
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The User object to add.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the user addition.</returns>
        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser(User user)
        {
            return Ok(_objBLUser.AddUser(user));
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="updatedUser">The updated User object.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the user update.</returns>
        [HttpPut]
        [Route("UpdateUser/{userId}")]
        public IHttpActionResult UpdateUser(int userId, User updatedUser)
        {
            return Ok(_objBLUser.UpdateUser(userId, updatedUser));
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>An IHttpActionResult containing the response with the result of the user deletion.</returns>
        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public IHttpActionResult DeleteUser(int userId)
        {
            return Ok(_objBLUser.DeleteUser(userId));
        }

        #endregion
    }
}
