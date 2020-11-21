using APIPublications.Data.Conf;
using APIPublications.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APIPublications.Data.DAO
{
    public class PublicationDAO
    {
        private readonly ConnectionData ConnectionData;

        public PublicationDAO(string databaseConnection)
        {
            ConnectionData = new ConnectionData(databaseConnection);
        }

        /// <summary>
        /// Get the posts from the table.
        /// </summary>
        /// <param name="publicationEntity"></param>
        /// <param name="action"></param>
        /// <returns>List<PublicationEntity></returns>
        public List<PublicationEntity> ListPublications(PublicationEntity publicationEntity, int action)
        {
            try
            {
                List<PublicationEntity> publicationEntities = new List<PublicationEntity>();
                using (SqlConnection sqlConnection = ConnectionData.CreateConnection())
                {
                    SqlCommand sqlCommand = new SqlCommand("SPPublication", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@IdPost", publicationEntity.IdPost);
                    sqlCommand.Parameters.AddWithValue("@IdUserPost", publicationEntity.IdUserPost);
                    sqlCommand.Parameters.AddWithValue("@PublicationTitle", Utilities.ValidateNullString(publicationEntity.PublicationTitle));
                    sqlCommand.Parameters.AddWithValue("@PublicationContent", Utilities.ValidateNullString(publicationEntity.PublicationContent));
                    sqlCommand.Parameters.AddWithValue("@CreationDate", Utilities.ValidateDate(publicationEntity.CreationDate));
                    sqlCommand.Parameters.AddWithValue("@Action", action);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        publicationEntity.IdPost = Convert.ToInt32(sqlDataReader["IdPost"]);
                        publicationEntity.IdUserPost = Convert.ToInt32(sqlDataReader["IdUserPost"]);
                        publicationEntity.PublicationTitle = Utilities.ValidateNullString(sqlDataReader["PublicationTitle"].ToString());
                        publicationEntity.PublicationContent = Utilities.ValidateNullString(sqlDataReader["PublicationContent"].ToString());
                        publicationEntity.CreationDate = Convert.ToDateTime(sqlDataReader["CreationDate"]);
                        publicationEntities.Add(publicationEntity);
                    }
                    sqlConnection.Close();
                };
                return publicationEntities;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Register or delete posts.
        /// </summary>
        /// <param name="publicationEntity"></param>
        /// <param name="action"></param>
        /// <returns>bool</returns>
        public bool ManipulationDataPublication(PublicationEntity publicationEntity, int action)
        {
            try
            {
                using (SqlConnection sqlConnection = ConnectionData.CreateConnection())
                {
                    SqlCommand sqlCommand = new SqlCommand("SPPublication", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@IdPost", publicationEntity.IdPost);
                    sqlCommand.Parameters.AddWithValue("@IdUserPost", publicationEntity.IdUserPost);
                    sqlCommand.Parameters.AddWithValue("@PublicationTitle", Utilities.ValidateNullString(publicationEntity.PublicationTitle));
                    sqlCommand.Parameters.AddWithValue("@PublicationContent", Utilities.ValidateNullString(publicationEntity.PublicationContent));
                    sqlCommand.Parameters.AddWithValue("@CreationDate", publicationEntity.CreationDate);
                    sqlCommand.Parameters.AddWithValue("@Action", action);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                };
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}