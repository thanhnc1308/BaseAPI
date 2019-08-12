using Base.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Services
{
    public class DatabaseService : IDatabaseService
    {
        private static readonly HttpContext _httpContext;

        #region Private Method

        // Generate sql for getting edit version
        private string GetEditVersionColumn(string tableName)
        {
            return $"{Constants.DefaultSchemaName}.{tableName}.xmin as edit_version";
        }

        //private string GetIpAddress(HttpContext context = null)
        //{
        //    return (_httpContext.HttpContext ?? context).connection.RemoteIpAddress.ToString();
        //}
        #endregion
    }
}
