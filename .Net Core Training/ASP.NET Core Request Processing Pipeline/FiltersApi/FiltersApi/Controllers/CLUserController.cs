using FiltersApi.BusinessLogic;
using FiltersApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FiltersApi.Controllers
{
    /// <summary>
    /// Controller class for managing users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLUserController : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Instance of BLUser Class
        /// </summary>
        private BLUser _objBLUser;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for CLUserController.
        /// </summary>
        public CLUserController()
        {
            _objBLUser = new BLUser();
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser()
        {
            return Ok(_objBLUser.GetUsers());
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="objUser">The user object to add.</param>
        /// <returns>The added user object if successful; otherwise, a 204 No Content response.</returns>
        [HttpPost]
        [Route("AddNewUser")]
        public IActionResult AddUser(USR01 objUser)
        {
            if (_objBLUser.Validation(objUser))
            {
                _objBLUser.AddUser(objUser);
                return Ok(objUser);
            }
            else
            {
                return NoContent();
            }
        }

        #endregion
    }
}
