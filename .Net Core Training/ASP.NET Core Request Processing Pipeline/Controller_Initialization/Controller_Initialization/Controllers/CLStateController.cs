using Controller_Initialization.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace Controller_Initialization.Controllers
{
    /// <summary>
    /// Controller class for handling state-related requests.
    /// </summary>
    [Route("api/CLState")]
    [ApiController]
    public class CLStateController : ControllerBase
    {
        /// <summary>
        /// Private Object of BLState class.
        /// </summary>
        private BLState _objBLState = new BLState();

        /// <summary>
        /// Action method to retrieve the list of states.
        /// </summary>
        /// <returns>The list of states.</returns>
        [HttpGet]
        public IActionResult GetStateList()
        {
            return Ok(_objBLState.GetList());
        }
    }
}
