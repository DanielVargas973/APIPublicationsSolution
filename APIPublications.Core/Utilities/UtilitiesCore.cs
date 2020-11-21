using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace APIPublications.Core.Utilities
{
    public class UtilitiesCore
    {
        /// <summary>
        /// Convert te date to Iso8601.
        /// </summary>
        /// <param name="L_st_entryDate"></param>
        /// <returns>string</returns>
        public static string DateTimeToISO8601Time(DateTime entryDateTime)
        {
            try
            {
                return entryDateTime.ToString("yyyy-MM-ddTHH:mm:sszzz");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Convert the date to Datetime.
        /// </summary>
        /// <param name="L_in_entryUnixDate"></param>
        /// <returns>DateTime</returns>
        public static DateTime Iso8601ToDateTime(string dateISO8601)
        {
            try
            {
                DateTime L_dt_dateTime;

                if (string.IsNullOrEmpty(dateISO8601))
                    L_dt_dateTime = DateTime.Parse(new DateTime().ToString(), null, DateTimeStyles.RoundtripKind);
                else
                    L_dt_dateTime = DateTime.Parse(dateISO8601, null, DateTimeStyles.RoundtripKind);

                return L_dt_dateTime;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Encript using SHA256
        /// </summary>
        /// <param name="str"></param>
        /// <returns>string</returns>
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}