using System;

namespace APIPublications.Data.Conf
{
    public class Utilities
    {
        /// <summary>
        /// Validates if the string is null.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string ValidateNullString(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return "";
            else
                return cadena;
        }

        /// <summary>
        /// If the year is less than 1700 it assigns the current date.
        /// </summary>
        /// <param name="L_dt_value"></param>
        /// <returns></returns>
        public static DateTime ValidateDate(DateTime L_dt_value)
        {
            L_dt_value = L_dt_value.Year < 1700 ? DateTime.Now : L_dt_value;
            return L_dt_value;
        }
    }
}