using FinalDemo_WebAPI.Models;
using System.Collections.Generic;

namespace FinalDemo_WebAPI.UserRepository
{
    /// <summary>
    /// Business Logic class for managing users.
    /// </summary>
    public class BLUser
    {
        #region Private member

        // Static variable to maintain a unique identifier for users
        private static int _userId = 0;
        #endregion

        #region Public Member

        // Static list to store user information
        public static List<User> _users = new List<User>
        {
            new User { UserId = GenerateUserId(), UserName = "Customer", PassWord = "customer", Email = "customer@gamil.com", Roles = "Customer" },
            new User { UserId = GenerateUserId(), UserName = "Supplier", PassWord = "supplier", Email = "supplier@gamil.com", Roles = "Supplier" },
            new User { UserId = GenerateUserId(), UserName = "Seller", PassWord = "seller", Email = "seller@gamil.com", Roles = "Seller" },

        };

        #endregion

        #region Public methods

        #region GetAllUsers

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>An IEnumerable of User.</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        #endregion

        #region GetUserById

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>A User object if found, otherwise null.</returns>
        public User GetUserById(int userId)
        {
            return _users.Find(u => u.UserId == userId);
        }

        #endregion

        #region AddUser

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The User object to add.</param>
        /// <returns>The added User object.</returns>
        public User AddUser(User user)
        {
            user.UserId = GenerateUserId();
            _users.Add(user);
            return user;
        }

        #endregion

        #region UpdateUser

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="updatedUser">The updated User object.</param>
        /// <returns>The updated User object if successful, otherwise null.</returns>
        public User UpdateUser(int userId, User updatedUser)
        {
            var existingUser = _users.Find(u => u.UserId == userId);
            if (existingUser != null)
            {
                existingUser.UserName = updatedUser.UserName;
                existingUser.PassWord = updatedUser.PassWord;
                existingUser.Email = updatedUser.Email; 
                existingUser.Roles = updatedUser.Roles;
                return existingUser;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region DeleteUser

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>The deleted User object if successful, otherwise null.</returns>
        public User DeleteUser(int userId)
        {
            var user = _users.Find(u => u.UserId == userId);
            if (user != null)
            {
                _users.Remove(user);
                return user;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #endregion

        #region Private methods

        #region GenerateUserId

        /// <summary>
        /// Generates a unique ID for users.
        /// </summary>
        /// <returns>The generated unique ID.</returns>
        private static int GenerateUserId()
        {
            return ++_userId;
        }

        #endregion

        #endregion
    }
}
