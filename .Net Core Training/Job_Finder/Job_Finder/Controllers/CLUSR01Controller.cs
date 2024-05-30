using Job_Finder.BusinessLogic;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Job_Finder.Filters;

namespace Job_Finder.Controllers
{
    /// <summary>
    /// Handel all the endpoints related to User.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLUSR01Controller : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Handler for business logic related to users.
        /// </summary>
        private BLUSR01Handler _objBLUSR01Handler;

        /// <summary>
        /// Provides helper methods for business logic operations.
        /// </summary>
        private readonly BLHelper _objBLHelper = new BLHelper();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLUSR01Controller"/> class.
        /// </summary>
        public CLUSR01Controller()
        {
            _objBLUSR01Handler = new BLUSR01Handler();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        [HttpGet]
        [AuthorizationFilter("A")]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            Response response = new Response();
            response.response = _objBLHelper.ToDataTable(_objBLUSR01Handler.GetAllUsers());

            return Ok(response);
        }

        ///// <summary>
        ///// Adds a new user.
        ///// </summary>
        ///// <param name="dtoUSR01">The DTO containing user details.</param>
        ///// <returns>The response after adding the user.</returns>
        //[HttpPost]
        //[Route("AddUser")]
        //public IActionResult AddUser(DtoUSR01 dtoUSR01)
        //{
        //    _objBLUSR01Handler.objOperation = Enum.enmOperationType.I;

        //    _objBLUSR01Handler.PreSave(dtoUSR01);

        //    Response response = _objBLUSR01Handler.Validation();
        //    if (!response.isError)
        //    {
        //        response = _objBLUSR01Handler.Save();
        //    }
        //    return Ok(response);
        //}

        /// <summary>
        /// Updates the details of an existing user.
        /// </summary>
        /// <param name="dtoUSR01">The DTO containing updated user details.</param>
        /// <returns>The response after updating the user.</returns>
        [HttpPut]
        [AuthorizationFilter("A")]
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
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>The response after deleting the user.</returns>
        [HttpDelete]
        [AuthorizationFilter("A")]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _objBLUSR01Handler.objOperation = Enum.enmOperationType.D;

            Response response = _objBLUSR01Handler.ValidationDelete(id);
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Delete(id);
            }
            return Ok(response);
        }

        #endregion
    }
}
