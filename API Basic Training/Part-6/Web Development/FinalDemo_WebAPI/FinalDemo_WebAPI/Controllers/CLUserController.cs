using FinalDemo_WebAPI.Models;
using FinalDemo_WebAPI.UserRepository;
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
        private BLUser _objUser = new BLUser();
        #endregion

        #region Public methods

        #region GetAllUsers

        /// <summary>
        /// Gets all users.
        /// </summary>
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            // Retrieve all users from BLUser and return as IHttpActionResult
            return Ok(_objUser.GetAllUsers());
        }

        #endregion

        #region GetUserById

        /// <summary>
        /// Gets a user by their ID.
        /// </summary>
        [HttpGet]
        [Route("GetUserById/{userId}")]
        public IHttpActionResult GetUserById(int userId)
        {
            // Retrieve a user by ID from BLUser and return as IHttpActionResult
            var user = _objUser.GetUserById(userId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region AddUser

        /// <summary>
        /// Adds a new user.
        /// </summary>
        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser(User user)
        {
            // Add a new user using BLUser and return the added user details
            var addedUser = _objUser.AddUser(user);
            return Created(Request.RequestUri + "/" + addedUser.UserId, addedUser);
        }

        #endregion

        #region UpdateUser

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        [HttpPut]
        [Route("UpdateUser/{userId}")]
        public IHttpActionResult UpdateUser(int userId, User updatedUser)
        {
            // Update an existing user using BLUser and return the updated user details
            var user = _objUser.UpdateUser(userId, updatedUser);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region DeleteUser

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public IHttpActionResult DeleteUser(int userId)
        {
            // Delete a user by ID using BLUser and return the deleted user details
            var user = _objUser.DeleteUser(userId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #endregion
    }
}
