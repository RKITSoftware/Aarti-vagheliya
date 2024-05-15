using Job_Finder.Enum;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Job_Finder.Services;
using Microsoft.OpenApi.Models;
using ServiceStack.OrmLite;

namespace Job_Finder.BusinessLogic
{
    public class BLUSR01Handler : CRUDImplementation<USR01>
    {
        private Response _objResponse;

        private USR01 _objUSR01 = new USR01();

        private readonly BLHelper _objBLHelper = new BLHelper();

        public void PreSave(DtoUSR01 objDtoUSR01)
        {
            _objUSR01 = _objBLHelper.Map<DtoUSR01, USR01>(objDtoUSR01);
            _objUSR01.R01F03 = _objBLHelper.Encrypt(_objUSR01.R01F03);
            obj = _objUSR01;
        }

        public Response Validation()
        {
            _objResponse = new Response();

            if (objOperation == enmOperationType.I)
            {
                if (_objUSR01.R01F03.Length < 3 || _objUSR01 == null)
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Enter valid data.";
                }
            }
            else if (objOperation == enmOperationType.U)
            {
                if (!IsExists(_objUSR01.R01F01))
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

            if (!IsExists(id))
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not found.";
            }
            return _objResponse;
        }

        public List<USR01> GetAllUsers()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                if (!db.TableExists<USR01>())
                {
                    return null; // Table does not exist
                }

                // Retrieve all users
                var users = db.Select<USR01>();

                // Decrypt the password for each user
                foreach (var user in users)
                {
                    user.R01F03 = _objBLHelper.Decrypt(user.R01F03);
                }
                return users;
            }

        }
    }
}