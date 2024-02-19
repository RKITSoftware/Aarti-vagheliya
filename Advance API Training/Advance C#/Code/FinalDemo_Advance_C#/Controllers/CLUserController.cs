﻿using FinalDemo_Advance_C_.Authentication;
using FinalDemo_Advance_C_.Bussiness_Logic;
using FinalDemo_Advance_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace FinalDemo_Advance_C_.Controllers
{
    /// <summary>
    /// Controller for managing user operations
    /// </summary>
    [RoutePrefix("api/user")]
    public class CLUserController : ApiController
    {
        private readonly BLUser _objBLUser;

        /// <summary>
        /// Constructor to initialize BLUser instance
        /// </summary>
        public CLUserController()
        {
            _objBLUser = new BLUser();
        }

        [HttpGet]
        [Route("token")]
        [BasicAuthentication]
        public IHttpActionResult GetToken()
        {
            string authToken = Request.Headers.Authorization.Parameter;
            byte[] authByte = Convert.FromBase64String(authToken);
            authToken = Encoding.UTF8.GetString(authByte);
            string[] usernamepassword = authToken.Split(':');
            string username = usernamepassword[0];
            string password = usernamepassword[1];
            var user = _objBLUser.GetAllUsers().FirstOrDefault(u => u.R01F02 == username && u.R01F03 == password);

            if(user != null)
            {
                return Ok(BLTokenManager.GenerateToken(username));
            }
            return BadRequest("Enter valid user details.");
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns>List of all users</returns>
        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAllUsers()
        {
            List<USR01> users = _objBLUser.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user">User object to add</param>
        /// <returns>Success message or error</returns>
        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddUser(USR01 user)
        {
            string result = _objBLUser.Insert(user);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="id">ID of the user to update</param>
        /// <param name="user">User object with updated data</param>
        /// <returns>Success message or error</returns>
        [HttpPut]
        [Route("update")]
        public IHttpActionResult UpdateUser(int id, USR01 user)
        {
            user.R01F01 = id; // Ensure the correct ID is set
            string result = _objBLUser.Update(user);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a user by ID
        /// </summary>
        /// <param name="id">ID of the user to delete</param>
        /// <returns>Success message or error</returns>
        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult DeleteUser(int id)
        {
            string result = _objBLUser.Delete(id);
            return Ok(result);
        }
    }
}
