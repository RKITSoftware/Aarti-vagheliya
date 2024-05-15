using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;

namespace Job_Finder.BusinessLogic
{
    public class BLJOL01Handler
    {
        private Response _objResponse;

        private JOL01 _objJOL01 = new JOL01();

        private readonly BLHelper _objBLHelper = new BLHelper();

        public enmOperationType OperationType { get; set; }

        public ICRUDService<JOL01> objCRUDJOL01;

        public BLJOL01Handler(ICRUDService<JOL01> objCRUDJOL01)
        {
            this.objCRUDJOL01 = objCRUDJOL01;
        }


        public void PreSave(DtoJOL01 objDtoJOL01)
        {
            _objJOL01 = _objBLHelper.Map<DtoJOL01, JOL01>(objDtoJOL01);
            objCRUDJOL01.obj = _objJOL01;
            objCRUDJOL01.objOperation = OperationType;
        }

        public Response Validation()
        {
            _objResponse = new Response();

            if (OperationType == enmOperationType.I)
            {
                if (_objJOL01.L01F04 <= 9999 && _objJOL01 == null )
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Enter valid data.";
                }
            }
            else if (OperationType == enmOperationType.U)
            {
                if (!objCRUDJOL01.IsExists(_objJOL01.L01F01))
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

            if (!objCRUDJOL01.IsExists(id))
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not found.";
            }
            return _objResponse;
        }

    }
}
