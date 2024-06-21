using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using FinalDemo_Advance_C_.Models.DTO;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Represents a controller for managing contacts.
    /// </summary>
    [RoutePrefix("api/contacts")]
    [BearerAuthentication] // Performs bearer token authentication
    public class CLCON01Controller : ApiController
    {
        #region Private Member
 
        /// <summary>
        /// Instance of the contact business logic class
        /// </summary>
        private readonly BLCON01Handler _objBLCON01Handler;

        /// <summary>
        /// Private Instance of Response.
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLCON01Controller"/> class.
        /// </summary>
        public CLCON01Controller()
        {
            _objBLCON01Handler = new BLCON01Handler();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all contacts.
        /// </summary>
        /// <returns>HTTP response containing contacts.</returns>
        [HttpGet]
        [Route("GetAllContacts")]
        [Authorize(Roles = ("Ad,De,Ac"))]
        public IHttpActionResult GetAllContacts()
        {
            _objResponse = new Response();
            _objResponse = _objBLCON01Handler.Select();
            return Ok(_objResponse);
        }

        /// <summary>
        /// Adds a new contact.
        /// </summary>
        /// <param name="contact">Contact DTO.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPost]
        [Route("AddContact")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult AddContact(DtoCON01 contact)
        {
            _objBLCON01Handler.objOperation = Enums.enmOperationType.I;

            _objBLCON01Handler.PreSave(contact);

            Response response = _objBLCON01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLCON01Handler.Save();
            }

            return Ok(response);
        }

        /// <summary>
        /// Updates an existing contact.
        /// </summary>
        /// <param name="contact">Contact DTO.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateContact")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult UpdateContact(DtoCON01 contact)
        {
            _objBLCON01Handler.objOperation = Enums.enmOperationType.U;

            _objBLCON01Handler.PreSave(contact);

            Response response = _objBLCON01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLCON01Handler.Save();
            }

            return Ok(response);
        }

        /// <summary>
        /// Deletes a contact.
        /// </summary>
        /// <param name="contactId">Contact ID.</param>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteContact")]
        [Authorize(Roles = ("Ad,De"))]
        public IHttpActionResult DeleteContact(int contactId)
        {
            _objResponse = _objBLCON01Handler.Delete(contactId);

            return Ok(_objResponse);
        }

        #endregion
    }
}
