using Job_Finder.BusinessLogic;
using Job_Finder.Interface;
using Job_Finder.Model.DTO;
using Job_Finder.Model;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Web;

namespace Job_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLJOS01Controller : ControllerBase
    {
        private BLJOS01Handler _objBLJOS01Handler;

        private Logger _logger;

        public CLJOS01Controller(ICRUDService<JOS01> objCRUDJOS01, IFileService fileservice)
        {
            _objBLJOS01Handler = new BLJOS01Handler(objCRUDJOS01, fileservice);
            _logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        [HttpGet]
        [Route("GetAllJobSeeker")]
        public IActionResult GetAllJobSeeker()
        {
            Response response = _objBLJOS01Handler.objCRUDJOS01.Select();

            return Ok(response);
        }

        [HttpPost]
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


        [HttpPut]
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

        [HttpDelete]
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

        [HttpGet]
        [Route("SearchByCityName")]
        public IActionResult SearchByCityName(string cityName)
        {
            Response response = _objBLJOS01Handler.SearchByCityName(cityName);

            return Ok(response);
        }

       
    }

}

