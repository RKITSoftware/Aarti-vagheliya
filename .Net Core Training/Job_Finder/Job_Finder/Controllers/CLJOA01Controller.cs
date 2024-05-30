using Job_Finder.BusinessLogic;
using Job_Finder.Filters;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Mvc;

namespace Job_Finder.Controllers
{
    /// <summary>
    /// CLJOA01Controller that manages methods to handel JobApplication
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLJOA01Controller : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Instance of BLJOA01Handler class.
        /// </summary>
        private BLJOA01Handler _objBLJOA01Handler;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialize BLJOA01Handler with ICRUDService.
        /// </summary>
        /// <param name="objCRUDJOA01">CRUD service for JOA01 operations.</param>
        public CLJOA01Controller(ICRUDService<JOA01> objCRUDJOA01)
        {
            _objBLJOA01Handler = new BLJOA01Handler(objCRUDJOA01);
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves all job applications.
        /// </summary>
        /// <returns>List of all job applications.</returns>
        [HttpGet]
        [AuthorizationFilter("A")]
        [Route("GetAllJobApplication")]
        public IActionResult GetAllJobApplication()
        {
            Response response = _objBLJOA01Handler.objCRUDJOA01.Select();

            return Ok(response);
        }

        /// <summary>
        /// Adds a new job application.
        /// </summary>
        /// <param name="dtoJOA01">DTO containing job application data.</param>
        /// <returns>Response indicating success or failure.</returns>
        [HttpPost]
        [AuthorizationFilter("J")]
        [Route("AddJobApplication")]
        public IActionResult AddJobApplication(DtoJOA01 dtoJOA01)
        {
            _objBLJOA01Handler.OperationType = Enum.enmOperationType.I;

            _objBLJOA01Handler.PreSave(dtoJOA01);

            Response response = _objBLJOA01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLJOA01Handler.objCRUDJOA01.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates details of an existing job application.
        /// </summary>
        /// <param name="dtoJOA01">DTO containing updated job application data.</param>
        /// <returns>Response indicating success or failure.</returns>
        [HttpPut]
        [AuthorizationFilter("J")]
        [Route("UpdateDetails")]
        public IActionResult UpdateDetails(DtoJOA01 dtoJOA01)
        {
            _objBLJOA01Handler.OperationType = Enum.enmOperationType.U;

            _objBLJOA01Handler.PreSave(dtoJOA01);

            Response response = _objBLJOA01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLJOA01Handler.objCRUDJOA01.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Deletes a job application by its ID.
        /// </summary>
        /// <param name="id">ID of the job application to delete.</param>
        /// <returns>Response indicating success or failure.</returns>
        [HttpDelete]
        [AuthorizationFilter("J,A")]
        [Route("DeleteJobApplication")]
        public IActionResult DeleteJobApplication(int id)
        {
            _objBLJOA01Handler.OperationType = Enum.enmOperationType.D;

            Response response = _objBLJOA01Handler.ValidationDelete(id);
            if (!response.isError)
            {
                response = _objBLJOA01Handler.objCRUDJOA01.Delete(id);
            }
            return Ok(response);
        }

        #endregion
    }
}
