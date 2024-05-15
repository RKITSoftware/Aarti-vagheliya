using Job_Finder.BusinessLogic;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_Finder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLUSR01Controller : ControllerBase
    {
        private BLUSR01Handler _objBLUSR01Handler;

        public CLUSR01Controller()
        {
            _objBLUSR01Handler = new BLUSR01Handler();
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            Response response = new Response();
            response.response = _objBLUSR01Handler.GetAllUsers();

            return Ok(response);
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(DtoUSR01 dtoUSR01)
        {
            _objBLUSR01Handler.objOperation = Enum.enmOperationType.I;

            _objBLUSR01Handler.PreSave(dtoUSR01);

            Response response = _objBLUSR01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Save();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(DtoUSR01 dtoUSR01)
        {
            _objBLUSR01Handler.objOperation = Enum.enmOperationType.U;

            _objBLUSR01Handler.PreSave(dtoUSR01);

            Response response = _objBLUSR01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Save();
            }
            return Ok(response);
        }


        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _objBLUSR01Handler.objOperation = Enum.enmOperationType.D;

            Response response = _objBLUSR01Handler.ValidationDelete(id);
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Delete(id);
            }
            return Ok(response);
        }
    }
}
