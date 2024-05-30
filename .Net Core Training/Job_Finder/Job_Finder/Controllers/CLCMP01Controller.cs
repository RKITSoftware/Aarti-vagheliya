using Job_Finder.BusinessLogic;
using Job_Finder.Enum;
using Job_Finder.Filters;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Filters;

namespace Job_Finder.Controllers
{
    /// <summary>
    /// CLCMP01 controller manages all methods.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLCMP01Controller : ControllerBase
    {
        #region Private Member

        /// <summary>
        /// Instance of BLCMP01Handler class.
        /// </summary>
        private BLCMP01Handler _objBLCMP01Handler;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to initialize BLCMP01Handler with ICRUDService.
        /// </summary>
        /// <param name="objCRUDCMP01">CRUD service for CMP01 operations.</param>
        public CLCMP01Controller(ICRUDService<CMP01> objCRUDCMP01)
        {
            _objBLCMP01Handler = new BLCMP01Handler(objCRUDCMP01);
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves all companies.
        /// </summary>
        /// <returns>List of all companies.</returns>
        [HttpGet]
        [AuthorizationFilter("A")]
        [Route("GetAllCompanies")]
        public IActionResult GetAllCompanies()
        {
            Response response = _objBLCMP01Handler.objCRUDCMP01.Select();

            return Ok(response);
        }

        /// <summary>
        /// Adds a new company.
        /// </summary>
        /// <param name="dtoCMP01">DTO containing company data.</param>
        /// <returns>Response indicating success or failure.</returns>
        [HttpPost]
        [AuthorizationFilter("R")]
        [Route("AddCompany")]
        public IActionResult AddCompany(DtoCMP01 dtoCMP01)
        {
            _objBLCMP01Handler.OperationType = Enum.enmOperationType.I;

            _objBLCMP01Handler.PreSave(dtoCMP01);

            Response response = _objBLCMP01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLCMP01Handler.objCRUDCMP01.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Adds a new company.
        /// </summary>
        /// <param name="dtoCMP01">DTO containing company data.</param>
        /// <returns>Response indicating success or failure.</returns>
        [HttpPut]
        [AuthorizationFilter("R,A")]
        [Route("UpdateCompany")]
        public IActionResult UpdateCompany(DtoCMP01 dtoCMP01)
        {
            _objBLCMP01Handler.OperationType = Enum.enmOperationType.U;

            _objBLCMP01Handler.PreSave(dtoCMP01);

            Response response = _objBLCMP01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLCMP01Handler.objCRUDCMP01.Save();
            }
            return Ok(response);
        }

        /// <summary>
        /// Deletes a company by its ID.
        /// </summary>
        /// <param name="id">ID of the company to delete.</param>
        /// <returns>Response indicating success or failure.</returns>
        [HttpDelete]
        [AuthorizationFilter("A")]
        [Route("DeleteCompany")]
        public IActionResult DeleteCompany(int id)
        {
            _objBLCMP01Handler.OperationType = Enum.enmOperationType.D;

            Response response =  _objBLCMP01Handler.ValidationDelete(id);
            if (!response.isError)
            {
                response = _objBLCMP01Handler.objCRUDCMP01.Delete(id);
            }
            return Ok(response);
        }

        /// <summary>
        /// Retrieves job listings for a specific company.
        /// </summary>
        /// <param name="companyId">ID of the company.</param>
        /// <returns>List of job listings for the company.</returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetComapanyWiseJobListing")]
        public IActionResult GetComapanyWiseJobListing(int comapanyId)
        {
            Response response = _objBLCMP01Handler.GetCompanyWiseJobListing(comapanyId);

            return Ok(response);
        }

        /// <summary>
        /// Exports job listings of a specific company to an Excel file.
        /// </summary>
        /// <param name="companyId">ID of the company.</param>
        /// <returns>Excel file containing job listings.</returns>
        [HttpGet]
        [AuthorizationFilter("R")]
        [Route("ExportCompanyWiseJobListingToExcel")]
        public async Task<IActionResult> ExportCompanyWiseJobListingToExcel(int companyId)
        {
            try
            {
                string filePath = await _objBLCMP01Handler.ExportDataTableToExcel(companyId);
                return File(System.IO.File.ReadAllBytes(filePath), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return StatusCode(500, "An error occurred while exporting the data to Excel.");
            }
        }


        /// <summary>
        /// Exports job application data to an Excel file.
        /// </summary>
        /// <returns>Excel file containing job application data.</returns>
        [HttpGet]
        [AuthorizationFilter("R")]
        [Route("GetJobApplication")]
        public async Task<IActionResult> GetJobApplication()
        {
            try
            {
                string filePath = await _objBLCMP01Handler.GetJobApplicationData();
                return File(System.IO.File.ReadAllBytes(filePath), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return StatusCode(500, "An error occurred while exporting the data to Excel.");
            }
        }


        /// <summary>
        /// Updates the status of a job application.
        /// </summary>
        /// <param name="applicationId">The ID of the application to update.</param>
        /// <param name="newStatus">The new status to set for the application.</param>
        /// <returns>An IActionResult containing the response message.</returns>
        [HttpPatch]
        [AuthorizationFilter("R")]
        [Route("UpdateJobApplicationStatus")]
        public IActionResult UpdateJobApplicationStatus(int applicationId, enmJobApplicationStatus newStatus)
        {
            Response response = _objBLCMP01Handler.UpdateStatus(applicationId, newStatus);

            return Ok(response);
        }


        #endregion
    }
}
