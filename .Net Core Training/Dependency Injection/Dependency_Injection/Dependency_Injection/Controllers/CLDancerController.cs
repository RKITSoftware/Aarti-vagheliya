using Dependency_Injection.Interface;
using Dependency_Injection.Model;
using Dependency_Injection.Service;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    /// <summary>
    /// Controller manages Dancer services and services lifetime
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLDancerController : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Create Instance of IDancerService interface
        /// </summary>
        private readonly IDancerService _dancerService;

        /// <summary>
        /// Create instance of Itransient interface
        /// </summary>
        private readonly ITransient _transient;

        /// <summary>
        /// Create instance of Iscoped interface.
        /// </summary>
        private readonly IScoped _scoped;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLDancerController"/> class.
        /// </summary>
        /// <param name="dancerService">The dancer service.</param>
        public CLDancerController(IDancerService dancerService, ITransient transient, IScoped scoped)
        {
            _dancerService = dancerService;
            _transient = transient;
            _scoped = scoped;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// for Testing constructor parameterized and deault.
        /// </summary>
        /// <returns></returns>
        [Route("get")]
        [HttpGet]
        public IActionResult get()
        {
            DancerService dancer = new DancerService();
            //return list of dancers.
            return Ok("Hello");

        }

        /// <summary>
        /// Retrieves the list of dancers.
        /// </summary>
        /// <returns>The list of dancers.</returns>
        [Route("GetDancerList")]
        [HttpGet]
        public IActionResult GetDancerList()
        {
            //return list of dancers.
           return Ok(_dancerService.GetDancers());

        }

        /// <summary>
        /// Adds a new dancer.
        /// </summary>
        /// <param name="objDCR01">The dancer object to add.</param>
        /// <returns>The result of the operation.</returns>
        [Route("AddNewDancer")]
        [HttpPost]
        public IActionResult AddNewDancer(DCR01 objDCR01)
        {
            //return message according to method call.
            return Ok(_dancerService.AddNewdancer(objDCR01));
             
        }

        /// <summary>
        /// Retrieves a dancer by ID.
        /// </summary>
        /// <param name="id">The ID of the dancer to retrieve.</param>
        /// <returns>The dancer object if found; otherwise, NotFound.</returns>
        [Route("GetOneDancer")]
        [HttpGet]
        public IActionResult GetOneDancer(int id)
        {
            return Ok(_dancerService.GetDancerById(id));
        }

        /// <summary>
        /// Updates dancer data by ID.
        /// </summary>
        /// <param name="id">The ID of the dancer to update.</param>
        /// <param name="objDCR01">The updated dancer object.</param>
        /// <returns>The result of the operation.</returns>
        [Route("UpdateData")]
        [HttpPut]
        public IActionResult UpdateData(int id, DCR01 objDCR01)
        {
            if (objDCR01 != null)
            {
                return Ok(_dancerService.UpdateDancer(id, objDCR01));
            }
            else
                return BadRequest();
        }

        /// <summary>
        /// Deletes a dancer by ID.
        /// </summary>
        /// <param name="id">The ID of the dancer to delete.</param>
        /// <returns>The result of the operation.</returns>
        [Route("DeleteDancer")]
        [HttpDelete]
        public IActionResult DeleteDancer(int id)
        {
            var result = _dancerService.DeleteDancer(id);
            if (result == null)
            {
                return NotFound("Invalid id.");
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Retrieves the ID of a singleton service.
        /// </summary>
        /// <param name="singleton">The singleton service.</param>
        /// <returns>The ID of the singleton service.</returns>
        [Route("GetSingleton")]
        [HttpGet]
        public IActionResult GetSingleton([FromServices] ISingleton singleton)
        {
            return Ok(singleton.GetId());
        }

        /// <summary>
        /// Retrieves the ID of a transient service.
        /// </summary>
        /// <param name="transient">The transient service.</param>
        /// <returns>The ID of the transient service.</returns>
        [Route("GetTransient")]
        [HttpGet]
        public IActionResult GetTransient([FromServices] ITransient transient)
        {
            Guid guid1 = transient.GetId();
            Guid guid2 = _transient.GetId();
            return Ok(new {Guid1 = guid1, Guid2 = guid2});
        }

        /// <summary>
        /// Retrieves the ID of a scoped service.
        /// </summary>
        /// <param name="scoped">The scoped service.</param>
        /// <returns>The ID of the scoped service.</returns>
        [Route("GetScoped")]
        [HttpGet]
        public IActionResult GetScoped([FromServices] IScoped scoped)
        {
            Guid guid1 = scoped.GetId();
            Guid guid2 = _scoped.GetId();
            return Ok(new { Guid1 = guid1, Guid2 = guid2 });
        }

        #endregion
    }
}
