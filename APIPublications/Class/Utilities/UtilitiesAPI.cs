using Microsoft.Extensions.Configuration;

namespace APIPublications.Class.Utilities
{
    public class UtilitiesAPI
    {
        private IConfiguration _configuration;

        public UtilitiesAPI(IConfiguration L_ob_configuration)
        {
            _configuration = L_ob_configuration;
        }

        /// <summary>
        /// Get the database connection from the file appsettings.
        /// </summary>
        /// <param name="L_st_key"></param>
        /// <returns>string</returns>
        public string GetDatabaseConnection(string key)
        {
            return _configuration.GetConnectionString(key);
        }

        /// <summary>
        /// Get the configuration of the file appsettings
        /// </summary>
        /// <param name="L_st_key"></param>
        /// <returns>string</returns>
        public string GetEnvironmentVariable(string key)
        {
            return _configuration[key];
        }
        /// <summary>
        /// gets the configuration of the appsettings file.
        /// </summary>
        /// <param name="L_st_key"></param>
        /// <returns>string</returns>
        public string GetConfigurationAppSettings(string key)
        {
            return _configuration.GetSection(key).Get<string>();
        }
    }
}