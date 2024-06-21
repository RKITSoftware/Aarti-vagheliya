using Microsoft.AspNetCore.Mvc;
using Middleware_Filter_Integration.BusinessLogic;
using Middleware_Filter_Integration.Model;
using Middleware_Filter_Integration.Model.DTO;

namespace Middleware_Filter_Integration.Controllers
{
    /// <summary>
    /// Controller for managing user operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLUSR01Controller : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// Handler for user-related business logic operations.
        /// </summary>
        private BLUSR01Handler _objBLUSR01Handler;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLUSR01Controller"/> class.
        /// </summary>
        /// <param name="connection">The database connection factory.</param>
        public CLUSR01Controller(BLConnection connection)
        {
            _objBLUSR01Handler = new BLUSR01Handler(connection);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A response containing all user data.</returns>
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            Response response  = _objBLUSR01Handler.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A response containing the user data.</returns>
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            Response response = _objBLUSR01Handler.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="dtoUSR01">The data transfer object containing user data.</param>
        /// <returns>A response indicating the result of the add operation.</returns>
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(DtoUSR01 dtoUSR01)
        {
            _objBLUSR01Handler.objOperation = Enum.enmOperationType.I;

            _objBLUSR01Handler.PreSave(dtoUSR01);

            Response response = _objBLUSR01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="dtoUSR01">The data transfer object containing user data.</param>
        /// <returns>A response indicating the result of the update operation.</returns>
        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(DtoUSR01 dtoUSR01)
        {
            _objBLUSR01Handler.objOperation = Enum.enmOperationType.U;

            _objBLUSR01Handler.PreSave(dtoUSR01);

            Response response = _objBLUSR01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            Response response = _objBLUSR01Handler.ValidationOnDelete(id);
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Delete(id);
            }
            return Ok(response);
        }

        #endregion
    }
}
