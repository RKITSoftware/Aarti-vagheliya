using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model.POCO;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using NLog;
using NLog.Web;
using ServiceStack;
using Job_Finder.DataBase;

namespace Job_Finder.BusinessLogic
{
    public class BLJOS01Handler
    {
        private Response _objResponse;

        private JOS01 _objJOS01 = new JOS01();

        private readonly BLHelper _objBLHelper = new BLHelper();

        private readonly IFileService _fileService;

        private readonly Logger _logger;

        private DBContext _objDBContext = new DBContext();

        public enmOperationType OperationType { get; set; }

        public ICRUDService<JOS01> objCRUDJOS01;



        public BLJOS01Handler(ICRUDService<JOS01> objCRUDJOS01, IFileService fileService)
        {
            this.objCRUDJOS01 = objCRUDJOS01;
            _fileService = fileService;
            _logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        public void PreSave(DtoJOS01 objDtoJOS01)
        {
            //_objJOS01 = _objBLHelper.Map<DtoJOS01, JOS01>(objDtoJOS01);
            //objCRUDJOS01.obj = _objJOS01;
            //objCRUDJOS01.objOperation = OperationType;

            //// Extract file name from the IFormFile object and store it in the JOS01 object
            //if (objDtoJOS01.S01F05 != null && objDtoJOS01.S01F05.Length > 0)
            //{
            //    _objJOS01.S01F05 = Path.GetFileName(objDtoJOS01.S01F05.FileName);
            //}
            _objJOS01 = _objBLHelper.Map<DtoJOS01, JOS01>(objDtoJOS01);

            // Handle file upload separately
            //if (objDtoJOS01.S01F05 != null)
            //{
            //    // Save the file and get the saved file
            //    dynamic savedFile = SaveFile(objDtoJOS01.S01F05);

            //    // Set the saved file to the POCO property
            //    _objJOS01.S01F05 = savedFile;
            //}

            SaveFile(objDtoJOS01.S01F05);
            objCRUDJOS01.obj = _objJOS01;
            objCRUDJOS01.objOperation = OperationType;
        }

        public Response Validation()
        {
            _objResponse = new Response();

            if (OperationType == enmOperationType.I)
            {
                if (_objJOS01 == null && _objJOS01.S01F06.Length != 14)
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Enter valid data.";
                }
            }
            else if (OperationType == enmOperationType.U)
            {
                if (!objCRUDJOS01.IsExists(_objJOS01.S01F01))
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

            if (!objCRUDJOS01.IsExists(id))
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not found.";
            }
            return _objResponse;
        }


        private void SaveFile(IFormFile file)
        {
            string uploadFolder = "ResumeUploads";
            string fileName = Guid.NewGuid().ToString().ToUpper().Substring(4,2) + Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadFolder, fileName);

            // Create the directory if it doesn't exist
            string directory = Path.Combine(Directory.GetCurrentDirectory(), uploadFolder);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            else if (!File.Exists(filePath)) // Check if file exists
            {
                // File doesn't exist, generate a new file name
                fileName = Guid.NewGuid().ToString().ToUpper().Substring(4, 2) + Path.GetFileName(file.FileName);
                filePath = Path.Combine(uploadFolder, fileName);
            }

            // Save the file to the specified path
            _fileService.UploadFile(file, filePath); 
             
            // Create a new instance of FormFile with the saved file
            //var savedFile = new FormFile(new FileStream(filePath, FileMode.Open), 0, file.Length, file.Name, fileName);

            // Return the saved file
            //return filePath;
        }


        public Response SearchByCityName(string cityName)
        {
            _objResponse = new Response();

            _objResponse.response = _objDBContext.SearchByCityName(cityName);

            return _objResponse;
        }



    }
}
