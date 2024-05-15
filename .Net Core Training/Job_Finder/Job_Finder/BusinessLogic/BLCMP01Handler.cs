using Job_Finder.DataBase;
using Job_Finder.Enum;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using OfficeOpenXml;
using System.ComponentModel.Design;
using System.Data;

namespace Job_Finder.BusinessLogic
{
    public class BLCMP01Handler
    {
        private DBContext _objDBContext = new DBContext();

        private Response _objResponse;

        private CMP01 _objCMP01 = new CMP01();

        private readonly BLHelper _objBLHelper = new BLHelper();

        public enmOperationType OperationType { get; set; }

        public ICRUDService<CMP01> objCRUDCMP01;

        public BLCMP01Handler(ICRUDService<CMP01> objCRUDCMP01)
        {
            this.objCRUDCMP01 = objCRUDCMP01;
        }

        public void PreSave(DtoCMP01 objDtoCMP01)
        {
            _objCMP01 = _objBLHelper.Map<DtoCMP01, CMP01>(objDtoCMP01);
            objCRUDCMP01.obj = _objCMP01;
            objCRUDCMP01.objOperation = OperationType;
        }

        public Response Validation()
        {
            _objResponse = new Response();

            if (OperationType == enmOperationType.I)
            {
                if (_objCMP01 == null && _objCMP01.P01F05 <= 10)
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

        public Response GetCompanyWiseJobListing(int companyid)
        {
            _objResponse = new Response();

            _objResponse.response = _objDBContext.GetCompanyWiseJobListing(companyid);

            return _objResponse;
        }

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
            string fileName = $"{companyName}_JobListing_{DateTime.Now:dd-MM-yyyy}.xlsx";
            string filePath = Path.Combine(jobListingDirectory, fileName);

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
    }
}
