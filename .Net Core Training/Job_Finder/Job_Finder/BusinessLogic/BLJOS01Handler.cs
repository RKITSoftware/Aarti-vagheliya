using Job_Finder.DataBase;
using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using NLog;
using NLog.Web;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Handles business logic operations related to JOS01 entity.
    /// </summary>
    public class BLJOS01Handler
    {
        #region Private Members

        /// <summary>
        /// Stores the response object for operations.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Stores the response object for operations.
        /// </summary>
        private JOS01 _objJOS01 = new JOS01();

        /// <summary>
        /// Provides helper methods for business logic operations.
        /// </summary>
        private readonly BLHelper _objBLHelper = new BLHelper();

        /// <summary>
        /// Provides file service operations.
        /// </summary>
        private readonly IFileService _fileService;

        /// <summary>
        /// Provides logging functionality.
        /// </summary>
        private readonly Logger _logger;

        /// <summary>
        /// Provides database context for database operations.
        /// </summary>
        private DBContext _objDBContext = new DBContext();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        public enmOperationType OperationType { get; set; }

        /// <summary>
        /// Gets or sets the CRUD service for JOS01.
        /// </summary>
        public ICRUDService<JOS01> objCRUDJOS01;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the BLJOS01Handler class.
        /// </summary>
        /// <param name="objCRUDJOS01">The CRUD service for JOS01.</param>
        /// <param name="fileService">The file service for handling file operations.</param>
        public BLJOS01Handler(ICRUDService<JOS01> objCRUDJOS01, IFileService fileService)
        {
            this.objCRUDJOS01 = objCRUDJOS01;
            _fileService = fileService;
            _logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Prepares data before performing an operation.
        /// </summary>
        /// <param name="objDtoJOS01">The DTO object for JOS01.</param>
        public void PreSave(DtoJOS01 objDtoJOS01)
        {
            _objJOS01 = _objBLHelper.Map<DtoJOS01, JOS01>(objDtoJOS01);
            SaveFile(objDtoJOS01.S01F05);
            objCRUDJOS01.obj = _objJOS01;
            objCRUDJOS01.objOperation = OperationType;
        }

        /// <summary>
        /// Validates data before performing an operation.
        /// </summary>
        /// <returns>The response object indicating the validation result.</returns>
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

        /// <summary>
        /// Validates data before deleting a record.
        /// </summary>
        /// <param name="id">The ID of the record to be deleted.</param>
        /// <returns>The response object indicating the validation result.</returns>
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

        /// <summary>
        /// Searches records by city name.
        /// </summary>
        /// <param name="cityName">The city name to search by.</param>
        /// <returns>The response object containing the search results.</returns>
        public Response SearchByCityName(string cityName)
        {
            _objResponse = new Response();

            _objResponse.response = _objBLHelper.ToDataTable(_objDBContext.SearchByCityName(cityName)); //_objDBContext.SearchByCityName(cityName);

            return _objResponse;
        }

        /// <summary>
        /// Retrieves the application status for a specific job seeker.
        /// </summary>
        /// <param name="jobSeekerId">The ID of the job seeker to retrieve the application status for.</param>
        /// <returns>A response object containing the application status for the specified job seeker.</returns>
        public Response GetStatus(int jobSeekerId)
        {
            _objResponse = new Response();

            _objResponse.response = _objDBContext.GetStatus(jobSeekerId);

            return _objResponse;
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Saves the uploaded file to the specified location.
        /// </summary>
        /// <param name="file">The file to be saved.</param>
        private void SaveFile(IFormFile file)
        {
            string uploadFolder = "ResumeUploads";
            string fileName = Guid.NewGuid().ToString().ToUpper().Substring(4, 2) + Path.GetFileName(file.FileName);
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

        #endregion
    }
}
