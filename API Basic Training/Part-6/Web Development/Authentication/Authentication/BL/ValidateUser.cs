namespace Authentication.BL
{
    /// <summary>
    /// Utility class for user validation.
    /// </summary>
    public class ValidateUser
    {
        /// <summary>
        /// Validates user credentials.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <returns>Returns true if the credentials are valid, otherwise false.</returns>
        public bool Login(string username, string password)
        {
            if(username == "ABC" && password =="ABC123")
            {
                return true;    
            }
            else
            {
                return false;
            }
        }
    }
}