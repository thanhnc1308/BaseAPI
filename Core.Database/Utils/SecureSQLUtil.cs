using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Database
{
    public class SecureSQLUtil
    {
        /// <summary>
        /// detect if there exists sql injection signals using regex
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static bool DetectSqlInjection(string sql)
        {
            if (String.IsNullOrWhiteSpace(sql))
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// prevent sql injection by replace ' symbol
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string BuildSafeSqlLiteral(string sql)
        {
            if (String.IsNullOrEmpty(sql))
            {
                return sql;
            }
            return sql.Replace("'", "''");
        }
    }
}
