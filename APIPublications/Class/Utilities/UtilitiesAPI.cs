using Microsoft.Extensions.Configuration;

namespace APIPublications.Class.Utilities
{
    public class UtilitiesAPI
    {
        private IConfiguration M_ob_configuration;

        public UtilitiesAPI(IConfiguration L_ob_configuration)
        {
            M_ob_configuration = L_ob_configuration;
        }

        /// <summary>
        /// Get the database connection from the file appsettings.
        /// </summary>
        /// <param name="L_st_key"></param>
        /// <returns>string</returns>
        public string GetDatabaseConnection(string L_st_key)
        {
            return M_ob_configuration.GetConnectionString(L_st_key);
        }
    }
}