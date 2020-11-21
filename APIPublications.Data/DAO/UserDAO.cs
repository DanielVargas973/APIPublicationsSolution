using APIPublications.Data.Conf;
using APIPublications.Entity.Entity;
using System;
using System.Data;
using System.Data.SqlClient;

namespace APIPublications.Data.DAO
{
    public class UserDAO
    {
        private readonly ConnectionData ConnectionData;

        public UserDAO(string databaseConnection)
        {
            ConnectionData = new ConnectionData(databaseConnection);
        }

        /// <summary>
        /// Records and return user information.
        /// If the user was already registered, it returns a status false.
        /// </summary>
        /// <param name="userEntity"></param>
        /// <param name="action"></param>
        /// <returns>UserEntity</returns>
        public UserEntity RegisterUser(UserEntity userEntity, int action)
        {
            try
            {
                using (SqlConnection sqlConnection = ConnectionData.CreateConnection())
                {
                    SqlCommand sqlCommand = new SqlCommand("SPUser", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@UserNames", Utilities.ValidateNullString(userEntity.UserNames));
                    sqlCommand.Parameters.AddWithValue("@UserSurnames", Utilities.ValidateNullString(userEntity.UserSurnames));
                    sqlCommand.Parameters.AddWithValue("@UserEmail", Utilities.ValidateNullString(userEntity.UserEmail));
                    sqlCommand.Parameters.AddWithValue("@UserPassword", Utilities.ValidateNullString(userEntity.UserPassword));
                    sqlCommand.Parameters.AddWithValue("@Action", action);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        userEntity.Status = Convert.ToBoolean(sqlDataReader["Status"]);
                        userEntity.IdUser = Convert.ToInt32(sqlDataReader["IdUser"]);
                        userEntity.UserNames = Utilities.ValidateNullString(sqlDataReader["UserNames"].ToString());
                        userEntity.UserSurnames = Utilities.ValidateNullString(sqlDataReader["UserSurnames"].ToString());
                        userEntity.UserEmail = Utilities.ValidateNullString(sqlDataReader["UserEmail"].ToString());
                        userEntity.UserPassword = Utilities.ValidateNullString(sqlDataReader["UserPassword"].ToString());
                    }
                    sqlConnection.Close();
                };
                return userEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}