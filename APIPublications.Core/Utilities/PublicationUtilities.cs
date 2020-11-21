using APIPublications.Entity.Entity;
using APIPublications.Model.request;
using APIPublications.Model.response;
using System;
using System.Collections.Generic;

namespace APIPublications.Core.Utilities
{
    public class PublicationUtilities
    {
        /// <summary>
        /// Transform the object of type entity to model.
        /// Convert the Date of DateTime to ISO8601.
        /// </summary>
        /// <param name="publicationEntity"></param>
        /// <returns>PublicationResponseModel</returns>
        public static PublicationResponseModel TransformToModel(PublicationEntity publicationEntity)
        {
            try
            {
                return new PublicationResponseModel(publicationEntity.IdPost, publicationEntity.IdUserPost, publicationEntity.PublicationTitle,
                    publicationEntity.PublicationContent, UtilitiesCore.DateTimeToISO8601Time(publicationEntity.CreationDate));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Transform the object of type model to entity.
        /// Convert the Date of Iso8601 to DateTime.
        /// </summary>
        /// <param name="publicationRequestModel"></param>
        /// <returns>PublicationEntity</returns>
        public static PublicationEntity TransformToEntity(PublicationRequestModel publicationRequestModel)
        {
            try
            {
                return new PublicationEntity(publicationRequestModel.IdPost, publicationRequestModel.IdUserPost, publicationRequestModel.PublicationTitle,
                    publicationRequestModel.PublicationContent, UtilitiesCore.Iso8601ToDateTime(publicationRequestModel.CreationDate));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Transform the collection of type entity to a collection of type model.
        /// </summary>
        /// <param name="publicationEntities"></param>
        /// <returns></returns>
        public static List<PublicationResponseModel> TransformToModelCollection(List<PublicationEntity> publicationEntities)
        {
            try
            {
                List<PublicationResponseModel> publicationResponseModels = new List<PublicationResponseModel>();
                foreach (PublicationEntity publicationEntity in publicationEntities)
                {
                    publicationResponseModels.Add(TransformToModel(publicationEntity));
                }
                return publicationResponseModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}