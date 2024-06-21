using Job_Finder.BusinessLogic;
using Job_Finder.Filters;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Job_Finder.Controllers
{
    /// <summary>
    /// CLJOL01Controller that manages methods for JobListing.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLJOL01Controller : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Instance of BLJOL01Handler class.
        /// </summary>
        private BLJOL01Handler _objBLJOL01Handler;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLJOL01Controller"/> class.
        /// </summary>
        /// <param name="objCRUDJOL01">The CRUD service for JOL01.</param>
        public CLJOL01Controller(ICRUDService<JOL01> objCRUDJOL01)
        {
            _objBLJOL01Handler = new BLJOL01Handler(objCRUDJOL01);
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Gets all job listings.
        /// </summary>
        /// <returns>A list of all jobs.</returns>
        [HttpGet("GetAllJobs")]
        [AuthorizationFilter("A")]
        public IActionResult GetAllJobs()
        {
            Response response = _objBLJOL01Handler.objCRUDJOL01.Select();

            return Ok(response);
        }

        /// <summary>
        /// Adds a new job listing.
        /// </summary>
        /// <param name="dtoJOL01">The DTO containing job details.</param>
        /// <returns>The response after adding the job.</returns>
        [HttpPost("AddJob")]
        [AuthorizationFilter("R")]
        public IActionResult AddJob(DTOJOL01 dtoJOL01)
        {
            _objBLJOL01Handler.OperationType = Enum.enmOperationType.I;

            _objBLJOL01Handler.PreSave(dtoJOL01);

            Response response = _objBLJOL01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLJOL01Handler.objCRUDJOL01.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing job listing.
        /// </summary>
        /// <param name="dtoJOL01">The DTO containing updated job details.</param>
        /// <returns>The response after updating the job.</returns>
        [HttpPut("UpdateJob")]
        [AuthorizationFilter("R")]
        public IActionResult UpdateJob(DTOJOL01 dtoJOL01)
        {
            _objBLJOL01Handler.OperationType = Enum.enmOperationType.U;

            _objBLJOL01Handler.PreSave(dtoJOL01);

            Response response = _objBLJOL01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLJOL01Handler.objCRUDJOL01.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Deletes a job listing by its ID.
        /// </summary>
        /// <param name="id">The ID of the job to delete.</param>
        /// <returns>The response after deleting the job.</returns>
        [HttpDelete("DeleteJob")]
        [AuthorizationFilter("R")]
        public IActionResult DeleteJob(int id)
        {
            _objBLJOL01Handler.OperationType = Enum.enmOperationType.D;

            Response response = _objBLJOL01Handler.ValidationDelete(id);
            if (!response.isError)
            {
                response = _objBLJOL01Handler.objCRUDJOL01.Delete(id);
            }
            return Ok(response);
        }

        /// <summary>
        /// Retrieves job listings based on the provided location, type, and company ID.
        /// </summary>
        /// <param name="P01104">The location to filter job listings.</param>
        /// <param name="L01105">The type of job to filter listings.</param>
        /// <returns>An IActionResult containing the response with the job listings.</returns>
        [HttpGet("GetJobListings")]
        [AllowAnonymous]
        public IActionResult GetJobListings(string? P01104 = null, string? L01105 = null)
        {
            Response response = _objBLJOL01Handler.GetJobListings(P01104, L01105);

            return Ok(response);
        }

        #endregion
    }
}
