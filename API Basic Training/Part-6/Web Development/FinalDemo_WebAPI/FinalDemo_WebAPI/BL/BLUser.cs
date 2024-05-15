using FinalDemo_WebAPI.Models;
using System.Collections.Generic;

namespace FinalDemo_WebAPI.BL
{
    /// <summary>
    /// Business Logic class for managing users.
    /// </summary>
    public class BLUser
    {
        #region Private member

        //Private instance of Response class.
        private Response _objResponse;

        //Private instance of BLHelper class.
        private BLHelper _objBLHelper = new BLHelper();

        #endregion

        #region Public Member

        // Static list to store user information
        public static List<User> lstUsers = new List<User>();

        #endregion

        #region Constructor

        // Static constructor to initialize the list
        static BLUser()
        {
            // Initialize the list with sample users
            lstUsers.Add(new User { Id = BLHelper.GenerateId(lstUsers), UserName = "Customer", PassWord = "customer", Email = "customer@gamil.com", Roles = "Customer" });
            lstUsers.Add(new User { Id = BLHelper.GenerateId(lstUsers), UserName = "Supplier", PassWord = "supplier", Email = "supplier@gamil.com", Roles = "Supplier" });
            lstUsers.Add(new User { Id = BLHelper.GenerateId(lstUsers), UserName = "Seller", PassWord = "seller", Email = "seller@gamil.com", Roles = "Seller" });
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A Response object containing the list of users if available, otherwise an error message.</returns>
        public Response GetAllUsers()
        {
            _objResponse = new Response();

            if (lstUsers.Count > 0)
            {
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ToDataTable(lstUsers);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }
                return _objResponse;
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>A Response object containing the user if found, otherwise an error message.</returns>
        public Response GetUserById(int userId)
        {
            //lstUsers.Select(u => u.UserId == userId); // for filtering use select method
            
            _objResponse = new Response();

            User user = lstUsers.Find(u => u.Id == userId);
            if(user != null)
            {
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ObjectToDataTable(user);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The User object to add.</param>
        /// <returns>A Response object containing the added user if successful, otherwise an error message.</returns>
        public Response AddUser(User user)
        {
            _objResponse = new Response();

            if(user != null)
            {
                user.Id = BLHelper.GenerateId(lstUsers);
                lstUsers.Add(user);
                _objResponse.Message = "Ok";
                _objResponse.response = _objBLHelper.ObjectToDataTable(user);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Data not available.";
            }
            return _objResponse;
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="updatedUser">The updated User object.</param>
        /// <returns>A Response object containing the updated user if successful, otherwise an error message.</returns>
        public Response UpdateUser(int userId, User updatedUser)
        {
            _objResponse = new Response();

            // Find the existing user
            User existingUser = lstUsers.Find(u => u.Id == userId);

            if (existingUser != null)
            {
                // Update the existing user
                existingUser.UserName = updatedUser.UserName;
                existingUser.PassWord = updatedUser.PassWord;
                existingUser.Email = updatedUser.Email;
                existingUser.Roles = updatedUser.Roles;

                _objResponse.Message = "User updated successfully.";
                _objResponse.response = _objBLHelper.ObjectToDataTable(existingUser);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "User not found.";
            }

            return _objResponse;
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>A Response object containing the deleted user if successful, otherwise an error message.</returns>
        public Response DeleteUser(int userId)
        {
            _objResponse = new Response();

            int index = lstUsers.FindIndex(c => c.Id == userId);

            if (index != -1)
            {
                User user = lstUsers[index];
                lstUsers.RemoveAt(index);
                _objResponse.Message = "User deleted successfully.";
                _objResponse.response = _objBLHelper.ObjectToDataTable(user);
            }
            else
            {
                _objResponse.isError = true;
                _objResponse.Message = "Invalid index or user not found.";
            }

            return _objResponse;
        }

        #endregion

    }
}
