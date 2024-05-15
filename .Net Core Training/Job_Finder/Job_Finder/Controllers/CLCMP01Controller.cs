using Job_Finder.BusinessLogic;
using Job_Finder.DataBase;
using Job_Finder.Filters;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Web.Http.Filters;

namespace Job_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLCMP01Controller : ControllerBase
    {
        private BLCMP01Handler _objBLCMP01Handler;

        public CLCMP01Controller(ICRUDService<CMP01> objCRUDCMP01)
        {
            _objBLCMP01Handler = new BLCMP01Handler(objCRUDCMP01);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAllCompanies")]
        public IActionResult GetAllCompanies()
        {
            Response response = _objBLCMP01Handler.objCRUDCMP01.Select();

            return Ok(response);
        }

        [HttpPost]
        [AuthorizationFilter("A")]
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

        [HttpPut]
        [AuthorizationFilter("A")]
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

        [HttpGet]
        [Route("GetComapanyWiseJobListing")]
        public IActionResult GetComapanyWiseJobListing(int comapanyId)
        {
            Response response = _objBLCMP01Handler.GetCompanyWiseJobListing(comapanyId);

            return Ok(response);
        }

        [HttpGet]
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

        [HttpGet]
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
    }
}
