using Job_Finder.BusinessLogic;
using Job_Finder.Interface;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Job_Finder.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLJOL01Controller : ControllerBase
    {
        private BLJOL01Handler _objBLJOL01Handler;

        public CLJOL01Controller(ICRUDService<JOL01> objCRUDJOL01)
        {
            _objBLJOL01Handler = new BLJOL01Handler(objCRUDJOL01);
        }

        [HttpGet]
        [Route("GetAllJobs")]
        public IActionResult GetAllJobs()
        {
            Response response = _objBLJOL01Handler.objCRUDJOL01.Select();

            return Ok(response);
        }

        [HttpPost]
        [Route("AddJob")]
        public IActionResult AddJob(DtoJOL01 dtoJOL01)
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

        [HttpPut]
        [Route("UpdateJob")]
        public IActionResult UpdateJob(DtoJOL01 dtoJOL01)
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

        [HttpDelete]
        [Route("DeleteJob")]
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
    }
}
