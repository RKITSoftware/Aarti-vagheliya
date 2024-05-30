using Job_Finder.Model.POCO;

namespace Job_Finder.BusinessLogic
{
    /// <summary>
    /// Handles login-related business logic.
    /// </summary>
    public class BLLogin
    {
        #region Private Members

        /// <summary>
        /// Handles business logic operations related to USR01 entity.
        /// </summary>
        private BLUSR01Handler _objBLUSR01Handler = new BLUSR01Handler();

        #endregion

        #region Public Methods

        /// <summary>
        /// Validates the user credentials.
        /// </summary>
        /// <param name="userName">The username to validate.</param>
        /// <param name="passWord">The password to validate.</param>
        /// <returns>The validated user object if credentials are valid; otherwise, null.</returns>
        public USR01 ValidateUser(string userName, string passWord)
        {
           var user = _objBLUSR01Handler.GetAllUsers().FirstOrDefault(x => x.R01F02 == userName && x.R01F03 == passWord);

            return (user);
        }

        #endregion
    }


}
