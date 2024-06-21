using Job_Finder.DataBase;
using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using OfficeOpenXml;
using System.Data;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Handles business logic related to CMP01 entities.
    /// </summary>
    public class BLCMP01Handler
    {
        #region Private Member

        /// <summary>
        /// Instance of DBContext class.
        /// </summary>
        private DBContext _objDBContext = new DBContext();

        /// <summary>
        /// Instance of Response class.
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Instance of CMP01 class.
        /// </summary>
        private CMP01 _objCMP01 = new CMP01();

        /// <summary>
        /// Instance of BLHelper class.
        /// </summary>
        private readonly BLHelper _objBLHelper = new BLHelper();

        #endregion

        #region Public member

        /// <summary>
        /// Gets or sets the operation type.
        /// </summary>
        public enmOperationType OperationType { get; set; }

        /// <summary>
        /// Represents the CRUD service for CMP01 entities.
        /// </summary>
        public ICRUDService<CMP01> objCRUDCMP01;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BLCMP01Handler"/> class.
        /// </summary>
        /// <param name="objCRUDCMP01">The CRUD service for CMP01 entities.</param>
        public BLCMP01Handler(ICRUDService<CMP01> objCRUDCMP01)
        {
            this.objCRUDCMP01 = objCRUDCMP01;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Sets the CMP01 object based on the DTO object.
        /// </summary>
        /// <param name="objDtoCMP01">The DTO object to map to CMP01.</param>
        public void PreSave(DTOCMP01 objDtoCMP01)
        {
            _objCMP01 = _objBLHelper.Map<DTOCMP01, CMP01>(objDtoCMP01);
            objCRUDCMP01.obj = _objCMP01;
            objCRUDCMP01.objOperation = OperationType;
        }

        /// <summary>
        /// Validates the CMP01 object based on the operation type.
        /// </summary>
        /// <returns>The validation result.</returns>
        public Response Validation()
        {
            _objResponse = new Response();

            if (OperationType == enmOperationType.I)
            {
                if (_objCMP01.P01F05 <= 10)
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "Enter valid data.";
                }
            }
            else if (OperationType == enmOperationType.U)
            {
                if (!objCRUDCMP01.IsExists(_objCMP01.P01F01))
                {
                    _objResponse.isError = true;
                    _objResponse.Message = "No matching data found.";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Validates the deletion of a CMP01 object.
        /// </summary>
        /// <param name="id">The ID of the CMP01 object to delete.</param>
        /// <returns>The validation result for deletion.</returns>
        public Response ValidationDelete(int id)
        {
            _objResponse = new Response();

            if (!objCRUDCMP01.IsExists(id))
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not found.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Retrieves job listings for a specific company.
        /// </summary>
        /// <param name="companyid">The ID of the company.</param>
        /// <returns>The response containing job listing information.</returns>
        public Response GetCompanyWiseJobListing(int companyid)
        {
            _objResponse = new Response();

            _objResponse.response = _objDBContext.GetCompanyWiseJobListing(companyid);

            return _objResponse;
        }

        /// <summary>
        /// Exports job listing data for a specific company to an Excel file.
        /// </summary>
        /// <param name="companyId">The ID of the company.</param>
        /// <returns>The file path of the exported Excel file.</returns>
        public async Task<string> ExportDataTableToExcel(int companyId)
        {
            // Retrieve the DataTable using the company ID
            DataTable dataTable = _objDBContext.GetCompanyWiseJobListing(companyId);

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                throw new ArgumentException("DataTable is empty or null.");
            }

            // Retrieve the company name from the first row of the DataTable
            string companyName = dataTable.Rows[0]["CompanyName"].ToString();

            // Create a directory to store the Excel files if it doesn't exist
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "CompanyData");
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            // Create a subdirectory named "JobListing" inside the base directory if it doesn't exist
            string jobListingDirectory = Path.Combine(baseDirectory, "JobListing");
            if (!Directory.Exists(jobListingDirectory))
            {
                Directory.CreateDirectory(jobListingDirectory);
            }

            // Generate a unique file name for the Excel file
            string fileName = $"{companyName}_JobListing_{DateTime.Now:dd-MM-yyyy}.xlsx", filePath = Path.Combine(jobListingDirectory, fileName);

            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the Excel package
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Fill the worksheet with data from the DataTable
                worksheet.Cells["B2"].LoadFromDataTable(dataTable, true);

                // Save the Excel package to the specified file path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await package.SaveAsAsync(stream);
                }
            }

            // Return the file path
            return filePath;
        }

        /// <summary>
        /// Retrieves job application data and exports it to an Excel file.
        /// </summary>
        /// <returns>The file path of the exported Excel file.</returns>
        public async Task<string> GetJobApplicationData()
        {
            // Retrieve the DataTable using the company ID
            DataTable dataTable = _objDBContext.GetJobApplicationData();

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                throw new ArgumentException("DataTable is empty or null.");
            }

            // Create a directory to store the Excel files if it doesn't exist
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "CompanyData");
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            // Create a subdirectory named "JobApplication" inside the base directory if it doesn't exist
            string jobApplicationDirectory = Path.Combine(baseDirectory, "JobApplication");
            if (!Directory.Exists(jobApplicationDirectory))
            {
                Directory.CreateDirectory(jobApplicationDirectory);
            }

            // Generate a unique file name for the Excel file
            string fileName = $"JobApplication_{DateTime.Now:dd-MM-yyyy}.xlsx";
            string filePath = Path.Combine(jobApplicationDirectory, fileName);

            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the Excel package
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Fill the worksheet with data from the DataTable
                worksheet.Cells["B2"].LoadFromDataTable(dataTable, true);

                // Save the Excel package to the specified file path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await package.SaveAsAsync(stream);
                }
            }

            // Return the file path
            return filePath;
        }

        /// <summary>
        /// Updates the status of a job application and returns a response indicating the result.
        /// </summary>
        /// <param name="applicationId">The ID of the application to update.</param>
        /// <param name="newStatus">The new status to set for the application.</param>
        /// <returns>A response object containing the result of the update operation.</returns>
        public Response UpdateStatus(int applicationId, enmJobApplicationStatus newStatus)
        {
            _objResponse = new();

            string result = _objDBContext.UpdateJobApplicationStatus(applicationId, newStatus);

            if(result == "Success")
            {
                _objResponse.Message = result;
                return _objResponse;
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = result;
                return _objResponse;
            }


        }

        #endregion
    }
}
