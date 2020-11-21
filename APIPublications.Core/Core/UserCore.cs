using APIPublications.Core.Utilities;
using APIPublications.Data.DAO;
using APIPublications.Model.request;
using APIPublications.Model.response;
using System;

namespace APIPublications.Core.Core
{
    public class UserCore
    {
        private readonly string DatabaseConnecion;

        public UserCore(string databaseConnection)
        {
            DatabaseConnecion = databaseConnection;
        }

        #region Business methods

        /// <summary>
        /// Create a new user in the application.
        /// </summary>
        /// <param name="userRequestModel"></param>
        /// <returns>UserResponseModel</returns>
        public UserResponseModel NewUser(UserRequestModel userRequestModel)
        {
            try
            {
                return RegisterUser(userRequestModel, 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Authenticate a user in the application.
        /// </summary>
        /// <param name="userRequestModel"></param>
        /// <returns>UserResponseModel</returns>
        public UserResponseModel AuthenticateUser(UserRequestModel userRequestModel)
        {
            try
            {
                return RegisterUser(userRequestModel, 0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Business methods

        #region Methods with connection to the database

        /// <summary>
        /// Invokes the data persistence layer to manipulate and obtain information.
        /// </summary>
        /// <param name="userRequestModel"></param>
        /// <param name="action"></param>
        /// <returns>UserResponseModel</returns>
        private UserResponseModel RegisterUser(UserRequestModel userRequestModel, int action)
        {
            try
            {
                UserDAO userDAO = new UserDAO(DatabaseConnecion);
                return UserUtilities.TransformToModel(userDAO.RegisterUser(UserUtilities.TransformToEntity(userRequestModel), action));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods with connection to the database
    }
}