﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenBasedAuthentication.Models
{
    /// <summary>
    /// Represents a user entity with authentication and authorization information.
    /// </summary>
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username for authentication.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password for authentication.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email address associated with the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the role of the user for authorization purposes.
        /// </summary>
        public string Role { get; set; }
    }
}