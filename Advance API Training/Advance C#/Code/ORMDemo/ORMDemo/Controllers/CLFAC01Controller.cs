using ORMDemo.BL;
using ORMDemo.Models.DTO;
using ORMDemo.Models.POCO;
using System.Collections.Generic;
using System.Web.Http;

namespace ORMDemo.Controllers
{
    /// <summary>
    /// Controller for managing operations related to FAC01 entity.
    /// </summary>
    [RoutePrefix("api/CLFAC01")]
    public class CLFAC01Controller : ApiController
    {
        #region Private Member

        //Private instance of BLFac01 Class.
        private BLFAC01 _objBLFAC01;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor initialize the object
        /// </summary>
        public CLFAC01Controller()
        {
            _objBLFAC01 = new BLFAC01();
        }


        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves all records of FAC01 entity.
        /// </summary>
        [HttpGet]
        [Route("Select")]
        public IHttpActionResult Select()
        {
            return Ok(_objBLFAC01.Select());
        }

        /// <summary>
        /// Retrieves a single record of FAC01 entity by its ID.
        /// </summary>
        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult SingleById(int id)
        {
            return Ok(_objBLFAC01.SingleById(id));
        }

        /// <summary>
        /// Retrieves records of FAC01 entity by multiple IDs.
        /// </summary>
        [HttpGet]
        [Route("SelectByIds")]
        public IHttpActionResult SelectByIds([FromUri] List<int> ids)
        {
            return Ok(_objBLFAC01.SelectByIds(ids));
        }

        /// <summary>
        /// Inserts a new record into the FAC01 entity.
        /// </summary>
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult Insert(DtoFAC01 objDtoFAC01)
        {
            _objBLFAC01.PreSave(objDtoFAC01);
            return Ok(_objBLFAC01.Insert());
        }

        /// <summary>
        /// Inserts a new record into the FAC01 entity.
        /// </summary>
        [HttpPost]
        [Route("InsertOnly")]
        public IHttpActionResult InsertOnly()
        {
            return Ok(_objBLFAC01.InsertOnly());
        }

        /// <summary>
        /// Inserts multiple records into the FAC01 entity.
        /// </summary>
        [HttpPost]
        [Route("InsertAll")]
        public IHttpActionResult InsertAll(List<DtoFAC01> lstDtoFAC01)
        {
            _objBLFAC01.PreSave(lstDtoFAC01);
            return Ok(_objBLFAC01.InsertAll());
        }

        /// <summary>
        /// Updates a record in the FAC01 entity.
        /// </summary>
        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(int id, DtoFAC01 objDtoFAC01)
        {
            _objBLFAC01.PreSave(objDtoFAC01);
            return Ok(_objBLFAC01.Update(id));
        }

        /// <summary>
        /// Updates a record in the FAC01 entity.
        /// </summary>
        [HttpPut]
        [Route("UpdateOnly")]
        public IHttpActionResult UpdateOnly(int id)
        {
            return Ok(_objBLFAC01.UpdateOnly(id));
        }

        /// <summary>
        /// Updates only specific fields of a record in the FAC01 entity.
        /// </summary>
        [HttpPut]
        [Route("UpdateOnlyFields")]
        public IHttpActionResult UpdateOnlyFields(string name)
        {
            return Ok(_objBLFAC01.UpdateOnlyFields(name));
        }

        /// <summary>
        /// Deletes a record from the FAC01 entity by its ID.
        /// </summary>
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_objBLFAC01.Delete(id));
        }

        /// <summary>
        /// Deletes a record from the FAC01 entity by its ID.
        /// </summary>
        [HttpDelete]
        [Route("DeleteById")]
        public IHttpActionResult DeleteById(int id)
        {
            return Ok(_objBLFAC01.DeleteById(id));
        }

        /// <summary>
        /// Deletes multiple records from the FAC01 entity by their IDs.
        /// </summary>
        [HttpDelete]
        [Route("DeleteByIds")]
        public IHttpActionResult DeleteByIds([FromBody] List<int> ids)
        {
            return Ok(_objBLFAC01.DeleteByIds(ids));
        }

        /// <summary>
        /// Retrieves schema tables related to the FAC01 entity.
        /// </summary>
        [HttpGet]
        [Route("GetSchemaTables")]
        public IHttpActionResult GetSchemaTables()
        {
            return Ok(_objBLFAC01.GetSchemaTables());
        }

        /// <summary>
        /// Adds a new column to the schema of the FAC01 entity.
        /// </summary>
        [HttpGet]
        [Route("AddNewColumn")]
        public IHttpActionResult AddNewColumn()
        {
            return Ok(_objBLFAC01.AddNewColumn());
        }

        /// <summary>
        /// Creates an index on the schema of the FAC01 entity.
        /// </summary>
        [HttpGet]
        [Route("CreateIndex")]
        public IHttpActionResult CreateIndex()
        {
            return Ok(_objBLFAC01.CreateIndex());
        }

        /// <summary>
        /// Retrieves a scalar value from the FAC01 entity.
        /// </summary>
        [HttpGet]
        [Route("Scalar")]
        public IHttpActionResult Scalar()
        {
            var result = _objBLFAC01.Scalar();
            return Ok(result);
        }

        /// <summary>
        /// Groups data from the FAC01 entity.
        /// </summary>
        [HttpGet]
        [Route("GroupBy")]
        public IHttpActionResult GroupBy()
        {
            var result = _objBLFAC01.GroupBy();
            return Ok(result);
        }

        /// <summary>
        /// Performs a lookup query on the FAC01 entity.
        /// </summary>
        [HttpGet]
        [Route("LookUpQuery")]
        public IHttpActionResult LookUpQuery()
        {
            var result = _objBLFAC01.LookupQuery<FAC01>();
            return Ok(result);
        }

        /// <summary>
        /// Performs join operation.
        /// </summary>
        /// <returns>Data of Joined table.</returns>
        [HttpGet]
        [Route("Join")]
        public IHttpActionResult Join()
        {
            return Ok(_objBLFAC01.Join());
        }

        #endregion
    }
}
