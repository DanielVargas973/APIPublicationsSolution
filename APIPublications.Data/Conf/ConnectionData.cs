using System;
using System.Data.SqlClient;

namespace APIPublications.Data.Conf
{
    public class ConnectionData
    {
        public ConnectionData(string connection)
        {
            Connection = connection;
        }
        /// <summary>
        /// Create te connection instance.
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection CreateConnection()
        {
            try
            {
                SqlConnection = new SqlConnection(Connection);
                return SqlConnection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Connection { get; set; }
        public SqlConnection SqlConnection { get; set; }
    }
}