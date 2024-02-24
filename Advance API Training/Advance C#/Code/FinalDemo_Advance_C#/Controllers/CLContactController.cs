using FinalDemo_Advance_C_.Authentication;
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
    /// <summary>
    /// Represents a controller for managing contacts.
    /// </summary>
    [RoutePrefix("api/contacts")]
    public class CLContactController : ApiController
    {
        #region Private Member

        // Instance of the contact business logic class
        private readonly BLContact _objBLContact = new BLContact();

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves all contacts.
        /// </summary>
        /// <returns>The list of contacts.</returns>
        [HttpGet]
        [Route("GetAllContacts")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO,Accountant"))]
        public IHttpActionResult GetAllContacts()
        {
            List<CNT01> contacts = _objBLContact.GetAllContacts();
            if (contacts != null)
                return Ok(contacts);
            else
                return InternalServerError();
        }

        /// <summary>
        /// Adds a new contact.
        /// </summary>
        /// <param name="contact">The contact to add.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPost]
        [Route("AddContact")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult AddContact(CNT01 contact)
        {
            if (_objBLContact.AddContact(contact)) // Attempts to add the contact
                return Ok("Contact added successfully."); // Returns success message
            else
                return InternalServerError(); // Returns an internal server error response
        }

        /// <summary>
        /// Updates an existing contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact to update.</param>
        /// <param name="contact">The updated contact data.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpPut]
        [Route("UpdateContact")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult UpdateContact(int contactId, CNT01 contact)
        {
            if (_objBLContact.UpdateContact(contactId, contact))
                return Ok("Contact updated successfully.");
            else
                return InternalServerError();
        }

        /// <summary>
        /// Deletes a contact.
        /// </summary>
        /// <param name="contactId">The ID of the contact to delete.</param>
        /// <returns>The HTTP action result indicating success or failure.</returns>
        [HttpDelete]
        [Route("DeleteContact")]
        [BearerAuthentication] // Performs bearer token authentication
        [Authorize(Roles = ("Admin,DEO"))]
        public IHttpActionResult DeleteContact(int contactId)
        {
            if (_objBLContact.DeleteContact(contactId)) // Attempts to delete the contact
                return Ok("Contact deleted successfully."); // Returns success message
            else
                return InternalServerError(); // Returns an internal server error response
        }

        #endregion
    }
}
