using Job_Finder.DataBase;
using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Handles business logic operations related to JOL01 entity.
    /// </summary>
    public class BLJOL01Handler
    {
        #region Private Members

        /// <summary>
        /// Instance of Response class.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Instance of JOL01 class.
        /// </summary>
        private JOL01 _objJOL01 = new JOL01();

        /// <summary>
        /// Instance of BLHelper class.
        /// </summary>
        private readonly BLHelper _objBLHelper = new BLHelper();

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
        /// Gets or sets the CRUD service for JOL01.
        /// </summary>
        public ICRUDService<JOL01> objCRUDJOL01;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the BLJOL01Handler class.
        /// </summary>
        public BLJOL01Handler(ICRUDService<JOL01> objCRUDJOL01)
        {
            this.objCRUDJOL01 = objCRUDJOL01;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Pre-saves data before performing an operation.
        /// </summary>
        public void PreSave(DTOJOL01 objDtoJOL01)
        {
            _objJOL01 = _objBLHelper.Map<DTOJOL01, JOL01>(objDtoJOL01);
            objCRUDJOL01.obj = _objJOL01;
            objCRUDJOL01.objOperation = OperationType;
        }

        /// <summary>
        /// Validates data before performing an operation.
        /// </summary>
        public Response Validation()
        {
            _objResponse = new Response();

            if (OperationType == enmOperationType.I)
            {
                if (_objJOL01.L01F04 <= 9999)
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

        /// <summary>
        /// Validates data before deleting a record.
        /// </summary>
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

        /// <summary>
        /// Retrieves job listings based on the specified location, job type, and company ID.
        /// </summary>
        /// <param name="P01F04">The location to filter job listings by.</param>
        /// <param name="L01F05">The job type to filter job listings by.</param>
        /// <returns>A response object containing the list of job listings that match the specified criteria.</returns>
        public Response GetJobListings(string? P01F04 = null, string? L01F05 = null)
        {
            _objResponse = new Response();

            _objResponse.response = _objBLHelper.ConvertListOfObjectToDataTable(_objDBContext.GetJobListings(P01F04, L01F05));

            return _objResponse;
        }

        #endregion
    }
}
