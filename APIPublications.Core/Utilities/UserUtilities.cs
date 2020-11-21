using APIPublications.Entity.Entity;
using APIPublications.Model.request;
using APIPublications.Model.response;
using System;

namespace APIPublications.Core.Utilities
{
    public class UserUtilities
    {
        /// <summary>
        /// Transform the object of type entity to model.
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns>UserModel</returns>
        public static UserResponseModel TransformToModel(UserEntity userEntity)
        {
            try
            {
                return new UserResponseModel(userEntity.IdUser, userEntity.UserNames, userEntity.UserSurnames, userEntity.UserEmail,
                    userEntity.Status);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Transform the object of type model to entity.
        /// Encript the password using SHA256.
        /// </summary>
        /// <param name="userRequestModel"></param>
        /// <returns>UserEntity</returns>
        public static UserEntity TransformToEntity(UserRequestModel userRequestModel)
        {
            try
            {
                return new UserEntity(userRequestModel.UserNames, userRequestModel.UserSurnames, userRequestModel.UserEmail,
                    UtilitiesCore.GetSHA256(userRequestModel.UserPassword));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}