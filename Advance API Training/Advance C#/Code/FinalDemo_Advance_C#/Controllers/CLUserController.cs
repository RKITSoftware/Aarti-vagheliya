using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using FinalDemo_Advance_C_.Models.DTO;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Controller for managing user operations
    /// </summary>
    [RoutePrefix("api/user")]
    [BearerAuthentication] // Performs bearer token authentication
    public class CLUserController : ApiController
    {
        #region Private member

        /// <summary>
        /// Private instance of BLUSR01Handler
        /// </summary>
        private readonly BLUSR01Handler _objBLUSR01Handler;

        /// <summary>
        /// Private instance of Response.
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLUserController"/> class.
        /// </summary>
        public CLUserController()
        {
            _objBLUSR01Handler = new BLUSR01Handler();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>HTTP response containing user data.</returns>
        [HttpGet]
        [Route("getAll")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult GetAllUsers()
        {
            _objResponse = new Response();
            _objResponse = _objBLUSR01Handler.GetAllUsers();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user to add.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPost]
        [Route("add")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult AddUser(DtoUSR01 user)
        {
            _objBLUSR01Handler.objOperation = Enums.enmOperationType.I;

            _objBLUSR01Handler.PreSave(user);
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
        /// <param name="user">The user to update.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPut]
        [Route("update")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult UpdateUser(DtoUSR01 user)
        {
            _objBLUSR01Handler.objOperation = Enums.enmOperationType.U;

            _objBLUSR01Handler.PreSave(user);
            Response response = _objBLUSR01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Save();
            }

            return Ok(response);
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult DeleteUser(int id)
        {
            _objResponse = _objBLUSR01Handler.Delete(id);

            return Ok(_objResponse);
        }

        #endregion
    }
}
