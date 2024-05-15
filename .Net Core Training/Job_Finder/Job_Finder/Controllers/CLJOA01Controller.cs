using Job_Finder.BusinessLogic;
using Job_Finder.Interface;
using Job_Finder.Model.DTO;
using Job_Finder.Model;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Job_Finder.Filters;

namespace Job_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLJOA01Controller : ControllerBase
    {
        private BLJOA01Handler _objBLJOA01Handler;

        public CLJOA01Controller(ICRUDService<JOA01> objCRUDJOA01)
        {
            _objBLJOA01Handler = new BLJOA01Handler(objCRUDJOA01);
        }

        [HttpGet]
        [AuthorizationFilter("A,R")]
        [Route("GetAllJobApplication")]
        public IActionResult GetAllJobApplication()
        {
            Response response = _objBLJOA01Handler.objCRUDJOA01.Select();

            return Ok(response);
        }

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
    }
}
