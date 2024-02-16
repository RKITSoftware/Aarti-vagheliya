using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    [RoutePrefix("api/suppliers")]
    public class CLSupplierController : ApiController
    {
        private readonly BLSupplier _objBLSupplier = new BLSupplier();

        [HttpGet]
        [Route("GetAllSuppliers")]
        public IHttpActionResult GetAllSuppliers()
        {
            
            List<SUP01> suppliers = _objBLSupplier.GetAllSuppliers();
            if (suppliers != null)
                return Ok(suppliers);
            else
                return InternalServerError();
        }

        [HttpPost]
        [Route("AddSupplier")]
        public IHttpActionResult AddSupplier(SUP01 supplier)
        {
            if (_objBLSupplier.AddSupplier(supplier))
                return Ok("Supplier added successfully.");
            else
                return InternalServerError();
        }

        [HttpPut]
        [Route("UpdateSupplier")]
        public IHttpActionResult UpdateSupplier(int supplierId, SUP01 supplier)
        {
            if (_objBLSupplier.UpdateSupplier(supplierId, supplier))
                return Ok("Supplier updated successfully.");
            else
                return InternalServerError();
        }

        [HttpDelete]
        [Route("DeleteSupplier")]
        public IHttpActionResult DeleteSupplier(int supplierId)
        {
            if (_objBLSupplier.DeleteSupplier(supplierId))
                return Ok("Supplier deleted successfully.");
            else
                return InternalServerError();
        }
    }
}

