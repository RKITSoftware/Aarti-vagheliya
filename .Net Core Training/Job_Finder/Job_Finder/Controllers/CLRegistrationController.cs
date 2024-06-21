﻿using Job_Finder.BusinessLogic;
using Job_Finder.Interface;
using Job_Finder.Model;
using Job_Finder.Model.DTO;
using Job_Finder.Model.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Job_Finder.Controllers
{
    /// <summary>
    /// Handle Registration and login functionality.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLRegistrationController : ControllerBase
    {
        #region Pivate Member

        /// <summary>
        /// Handler for business logic related to users.
        /// </summary>
        private BLUSR01Handler _objBLUSR01Handler;

        /// <summary>
        /// Handler for login-related business logic.
        /// </summary>
        private BLLogin _objBLogin = new();

        /// <summary>
        /// Handler for token management.
        /// </summary>
        private BLTokenManager _objBLTokenManager = new();

        /// <summary>
        /// Represents the service responsible for handling email operations.
        /// </summary>
        private readonly IEmailService _emailService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CLRegistrationController"/> class.
        /// </summary>
        public CLRegistrationController(IEmailService emailService)
        {
            _objBLUSR01Handler = new();
            _emailService = emailService;

        }

        #endregion

        #region Public Method

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="Userdata">The user data for registration.</param>
        /// <returns>An IActionResult containing the response of the registration process.</returns>
        [HttpPost("Registration")]
        [AllowAnonymous]
        public IActionResult Registration(DTOUSR01 Userdata)
        {
            _objBLUSR01Handler.objOperation = Enum.enmOperationType.I;

            _objBLUSR01Handler.PreSave(Userdata);

            Response response = _objBLUSR01Handler.Validation();
            if (!response.isError)
            {
                response = _objBLUSR01Handler.Save();
                _emailService.SendEmail(Userdata.R01F04, "User Registered.");
            }
            return Ok(response);
        }

        /// <summary>
        /// Authenticates a user and generates a token.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>An IActionResult containing the authentication token.</returns>
        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login(string userName, string password)
        {
            USR01 user = _objBLogin.ValidateUser(userName, password);

            string token = _objBLTokenManager.GenerateToken(user);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Username or password is incorrect" });
            }

            return Ok(new { token });
        }

        #endregion
    }
}
 