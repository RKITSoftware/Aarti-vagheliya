namespace Token_Custom.Models
{
    /// <summary>
    /// Represents a user entity with properties such as Id, Username, Password, and Role.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Represents the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Represents the password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Represents the role of the user.
        /// </summary>
        public string Role { get; set; }

    }
}