using CRUD_Operation.DataBase;
using CRUD_Operation.Models;
using CRUD_Operation.Models.DTO;
using CRUD_Operation.Models.POCO;

namespace CRUD_Operation.BL
{
    /// <summary>
    /// Business logic class for performing CRUD operations on fruits.
    /// </summary>
    public class BLFRT01
    {
        #region Private Member

        /// <summary>
        /// Instance of RES01 class.
        /// </summary>
        private RES01 _objRES01 = new RES01();

        /// <summary>
        /// Instance of DBFRT01 class.
        /// </summary>
        private DBFRT01 _objDBFRT01 = new DBFRT01();

        /// <summary>
        /// Instance of BLMapper<DtoFRT01, FRT01> class.
        /// </summary>
        private BLMapper<DtoFRT01, FRT01> _objBLMapper = new BLMapper<DtoFRT01, FRT01>();

        /// <summary>
        /// Instance of FRT01 class.
        /// </summary>
        private FRT01 _objFRT01 = new FRT01();

        /// <summary>
        /// Instance of BLConvertor class.
        /// </summary>
        private BLConvertor _objBLConvertor = new BLConvertor();

        #endregion

        #region Public Methods

        /// <summary>
        /// Maps DTO to POCO before saving.
        /// </summary>
        /// <param name="objDtoFRT01">DTO object containing fruit data.</param>
        public void PreSave(DtoFRT01 objDtoFRT01)
        {
             _objFRT01 = _objBLMapper.Map(objDtoFRT01);
        }

        /// <summary>
        /// Validates fruit data.
        /// </summary>
        /// <returns>Returns validation result.</returns>
        public RES01 Validation()
        {
            if (!_objDBFRT01.TableExists(typeof(FRT01)))
            {
                _objDBFRT01.CreateTable();
            }
            if (!string.IsNullOrEmpty(_objFRT01.T01F02) &&
                !string.IsNullOrEmpty(_objFRT01.T01F03) &&
                _objFRT01.T01F04 > 0 )
            {
                _objRES01.isError = false;
                _objRES01.Message = "Validated.";

                return _objRES01;
            }
            _objRES01.isError = true;
            _objRES01.Message = "Invalid Data";

            return _objRES01;
        }

        /// <summary>
        /// Inserts a new fruit record into the database.
        /// </summary>
        /// <returns>Returns insertion result.</returns>
        public RES01 Insert()
        {
            string result = _objDBFRT01.AddFruit(_objFRT01);
            if (result == "success")
            {
                _objRES01.isError = false;
                _objRES01.Message = result;
                return _objRES01;
            }
            _objRES01.isError = true;
            _objRES01.Message = result;
            return _objRES01;
        }

        /// <summary>
        /// Updates an existing fruit record in the database.
        /// </summary>
        /// <param name="id">The ID of the fruit to update.</param>
        /// <returns>Returns update result.</returns>
        public RES01 Update()
        {
            string result = _objDBFRT01.UpdateFruit( _objFRT01);
            if (result == "success")
            {
                _objRES01.isError = false;
                _objRES01.Message = result;
                return _objRES01;
            }
            _objRES01.isError = true;
            _objRES01.Message = result;
            return _objRES01;
        }

        /// <summary>
        /// Deletes a fruit record from the database.
        /// </summary>
        /// <param name="id">The ID of the fruit to delete.</param>
        /// <returns>Returns deletion result.</returns>
        public RES01 Delete(int id) 
        {
            string result = _objDBFRT01.DeleteFruit(id);
            if (result == "success")
            {
                _objRES01.isError = false;
                _objRES01.Message = result;
                return _objRES01;
            }
            _objRES01.isError = true;
            _objRES01.Message = result;
            return _objRES01;
        }

        /// <summary>
        /// Retrieves all fruit records from the database.
        /// </summary>
        /// <returns>Returns all fruit records.</returns>
        public RES01 Select()
        {
            int result = _objDBFRT01.GetAllFruits().Count;
            if (result >= 0)
            {
                _objRES01.isError = false;
                _objRES01.Message = "Ok";
                _objRES01.Response = _objBLConvertor.ToDataTable(_objDBFRT01.GetAllFruits());
                return _objRES01;
            }
            _objRES01.isError = true;
            _objRES01.Message = "Error";
            return _objRES01;
        }

        #endregion
    }
}