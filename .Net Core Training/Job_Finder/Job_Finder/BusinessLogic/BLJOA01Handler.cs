using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using System.Drawing.Text;

namespace Job_Finder.BusinessLogic
{
    public class BLJOA01Handler
    {
        private Response _objResponse;

        private JOA01 _objJOA01 = new JOA01();

        private readonly BLHelper _objBLHelper = new BLHelper();

        public enmOperationType OperationType { get; set; }

        public ICRUDService<JOA01> objCRUDJOA01;

        public BLJOA01Handler(ICRUDService<JOA01> objCRUDJOA01)
        {
            this.objCRUDJOA01 = objCRUDJOA01;
        }

        public void PreSave(DtoJOA01 objDtoJOA01)
        {
            _objJOA01 = _objBLHelper.Map<DtoJOA01, JOA01>(objDtoJOA01);
            objCRUDJOA01.obj = _objJOA01;
            objCRUDJOA01.objOperation = OperationType;
        }

        public Response Validation()
        {
            _objResponse = new Response();

            if (OperationType == enmOperationType.I)
            {
                if (_objJOA01 == null)
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Enter valid data.";
                }
            }
            else if (OperationType == enmOperationType.U)
            {
                if (!objCRUDJOA01.IsExists(_objJOA01.A01F01))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "No matching data found.";
                }
            }
            return _objResponse;
        }


        public Response ValidationDelete(int id)
        {
            _objResponse = new Response();

            if (!objCRUDJOA01.IsExists(id))
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not found.";
            }
            return _objResponse;
        }
    }
}
