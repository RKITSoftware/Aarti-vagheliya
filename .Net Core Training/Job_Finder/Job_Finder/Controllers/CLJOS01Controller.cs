using Job_Finder.BusinessLogic;
using Job_Finder.Filters;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;

namespace Job_Finder.Controllers
{
    /// <summary>
    /// Handel all the endpoints related to JobSeeker.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLJOS01Controller : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Handler for business logic related to Job Seekers.
        /// </summary>
        private BLJOS01Handler _objBLJOS01Handler;

        /// <summary>
        /// Logger instance for logging.
        /// </summary>
        private Logger _logger;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLJOS01Controller"/> class.
        /// </summary>
        /// <param name="objCRUDJOS01">The CRUD service for JOS01.</param>
        /// <param name="fileservice">The file service for handling file operations.</param>
        public CLJOS01Controller(ICRUDService<JOS01> objCRUDJOS01, IFileService fileservice)
        {
            _objBLJOS01Handler = new BLJOS01Handler(objCRUDJOS01, fileservice);
            _logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Gets all job seekers.
        /// </summary>
        /// <returns>A list of all job seekers.</returns>
        [HttpGet]
        [AuthorizationFilter("A")]
        [Route("GetAllJobSeeker")]
        public IActionResult GetAllJobSeeker()
        {
            Response response = _objBLJOS01Handler.objCRUDJOS01.Select();

            return Ok(response);
        }

        /// <summary>
        /// Adds a new job seeker.
        /// </summary>
        /// <param name="dtoJOS01">The DTO containing job seeker details.</param>
        /// <returns>The response after adding the job seeker.</returns>
        [HttpPost]
        [AuthorizationFilter("J")]
        [Route("AddJobSeeker")]
        public IActionResult AddJobSeeker([FromForm] DtoJOS01 dtoJOS01)
        {
            _logger.Info("AddJobeeker Method Called.");

            _objBLJOS01Handler.OperationType = Enum.enmOperationType.I;

          
            _objBLJOS01Handler.PreSave(dtoJOS01);

            Response response = _objBLJOS01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLJOS01Handler.objCRUDJOS01.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates the details of an existing job seeker.
        /// </summary>
        /// <param name="dtoJOS01">The DTO containing updated job seeker details.</param>
        /// <returns>The response after updating the job seeker.</returns>
        [HttpPut]
        [AuthorizationFilter("J")]
        [Route("UpdateDetails")]
        public IActionResult UpdateDetails(DtoJOS01 dtoJOS01)
        {
            _objBLJOS01Handler.OperationType = Enum.enmOperationType.U;

            _objBLJOS01Handler.PreSave(dtoJOS01);

            Response response = _objBLJOS01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLJOS01Handler.objCRUDJOS01.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Deletes a job seeker by their ID.
        /// </summary>
        /// <param name="id">The ID of the job seeker to delete.</param>
        /// <returns>The response after deleting the job seeker.</returns>
        [HttpDelete]
        [AuthorizationFilter("J")]
        [Route("DeleteJobSeeker")]
        public IActionResult DeleteJobSeeker(int id)
        {
            _objBLJOS01Handler.OperationType = Enum.enmOperationType.D;

            Response response = _objBLJOS01Handler.ValidationDelete(id);
            if (!response.isError)
            {
                response = _objBLJOS01Handler.objCRUDJOS01.Delete(id);
            }
            return Ok(response);
        }

        /// <summary>
        /// Searches for job seekers by city name.
        /// </summary>
        /// <param name="cityName">The name of the city to search for job seekers.</param>
        /// <returns>A list of job seekers in the specified city.</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("SearchByCityName")]
        public IActionResult SearchByCityName(string cityName)
        {
            Response response = _objBLJOS01Handler.SearchByCityName(cityName);

            return Ok(response);
        }

        /// <summary>
        /// Retrieves the application status for a given job seeker.
        /// </summary>
        /// <param name="jobSeekerId">The ID of the job seeker whose application status is to be retrieved.</param>
        /// <returns>An IActionResult containing the response with the application status.</returns>
        [HttpGet]
        [AuthorizationFilter("J,R")]
        [Route("GetStatus")]
        public IActionResult GetStatus(int jobSeekerId)
        {
            Response response = _objBLJOS01Handler.GetStatus(jobSeekerId);

            return Ok(response);
        }



        #endregion
    }

}

