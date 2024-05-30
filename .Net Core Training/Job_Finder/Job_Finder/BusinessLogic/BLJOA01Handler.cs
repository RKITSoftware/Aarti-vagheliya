using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Handles business logic operations related to JOA01 entity.
    /// </summary>
    public class BLJOA01Handler
    {
        #region Private Members

        /// <summary>
        /// Instance of Response class.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        ///  Instance of JOA01 class.
        /// </summary>
        private JOA01 _objJOA01 = new JOA01();

        /// <summary>
        ///  Instance of BLHelper class.
        /// </summary>
        private readonly BLHelper _objBLHelper = new BLHelper();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        public enmOperationType OperationType { get; set; }

        /// <summary>
        /// Gets or sets the CRUD service for JOA01.
        /// </summary>
        public ICRUDService<JOA01> objCRUDJOA01;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the BLJOA01Handler class.
        /// </summary>
        public BLJOA01Handler(ICRUDService<JOA01> objCRUDJOA01)
        {
            this.objCRUDJOA01 = objCRUDJOA01;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Pre-saves data before performing an operation.
        /// </summary>
        public void PreSave(DtoJOA01 objDtoJOA01)
        {
            _objJOA01 = _objBLHelper.Map<DtoJOA01, JOA01>(objDtoJOA01);
            objCRUDJOA01.obj = _objJOA01;
            objCRUDJOA01.objOperation = OperationType;
        }

        /// <summary>
        /// Validates data before performing an operation.
        /// </summary>
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

        /// <summary>
        /// Validates data before deleting a record.
        /// </summary>
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

        #endregion
    }
}
