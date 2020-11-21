using APIPublications.Core.Utilities;
using APIPublications.Data.DAO;
using APIPublications.Model.request;
using APIPublications.Model.response;
using System;
using System.Collections.Generic;

namespace APIPublications.Core.Core
{
    public class PostCore
    {
        private readonly string DatabaseConnection;

        public PostCore(string databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }

        #region Business methods

        /// <summary>
        /// Generate a new publication in the database.
        /// </summary>
        /// <param name="publicationRequestModel"></param>
        /// <returns></returns>
        public bool NewPost(PublicationRequestModel publicationRequestModel)
        {
            try
            {
                return ManipulationDataPublication(publicationRequestModel, 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get the post of n user.
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns>List<PublicationResponseModel></returns>
        public List<PublicationResponseModel> ListPostOfAnUser(int idUser)
        {
            try
            {
                return ListPublications(new PublicationRequestModel() { IdUserPost = idUser }, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete an post from a user u tthe aplication.
        /// </summary>
        /// <param name="idPost"></param>
        /// <returns></returns>
        public bool DeletePost(int idPost)
        {
            try
            {
                return ManipulationDataPublication(new PublicationRequestModel() { IdPost = idPost }, 3);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Business methods

        #region Methods with connection to the database

        /// <summary>
        /// Gets the post of the database
        /// </summary>
        /// <param name="publicationRequestModel"></param>
        /// <param name="action"></param>
        /// <returns>List<PublicationResponseModel></returns>
        private List<PublicationResponseModel> ListPublications(PublicationRequestModel publicationRequestModel, int action)
        {
            try
            {
                PublicationDAO publicationDAO = new PublicationDAO(DatabaseConnection);
                return PublicationUtilities.TransformToModelCollection(publicationDAO.ListPublications(PublicationUtilities.TransformToEntity(publicationRequestModel), action));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Register or delete posts of an user.
        /// </summary>
        /// <param name="publicationRequestModel"></param>
        /// <param name="action"></param>
        /// <returns>bool</returns>
        private bool ManipulationDataPublication(PublicationRequestModel publicationRequestModel, int action)
        {
            try
            {
                PublicationDAO publicationDAO = new PublicationDAO(DatabaseConnection);
                return publicationDAO.ManipulationDataPublication(PublicationUtilities.TransformToEntity(publicationRequestModel), action);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods with connection to the database
    }
}