using Base.Core;
using BaseAPI.Database;
using BaseAPI.Models;
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

        #region Public Methods
        public string GenerateSelectById<T>(string id) where T : BaseModel
        {
            string sql = "";
            id = SecureSQLUtil.BuildSafeSQL(id);
            var model = Activator.CreateInstance<T>();
            string tableName = model.GetTableName();
            sql = $"SELECT {Constant.DefaultSchemaName}.{tableName}.*, {GetEditVersionColumn(tableName)} FROM {Constant.DefaultSchemaName}.{tableName} WHERE {model.GetPrimaryKeyFieldName()} = {GetWhereValue(id)}";
            return sql;
        }

        public string GenerateSelectById(string id, string tableName)
        {
            string sql = "";
            id = SecureSQLUtil.BuildSafeSQL(id);
            Type modelType = GetModelType(tableName);
            var model = (BaseModel)Activator.CreateInstance(modelType);
            sql = $"SELECT {Constant.DefaultSchemaName}.{tableName}.*, {GetEditVersionColumn(tableName)} FROM {Constant.DefaultSchemaName}.{tableName} WHERE {model.GetPrimaryKeyFieldName()} = {GetWhereValue(id)}";
            return sql;
        }
        #endregion

        #region Private Methods

        // Generate sql for getting edit version
        private string GetEditVersionColumn(string tableName)
        {
            return $"{Constant.DefaultSchemaName}.{tableName}.xmin as edit_version";
        }

        private string GetWhereValue(string value)
        {
            string result = String.Empty;
            Guid guidValue = Guid.Empty;
            long longValue = 0;

            if (Guid.TryParse(value, out guidValue)
            {
                result = $"'{guidValue}'";
            }
            else if (long.TryParse(value, out longValue)
            {
                result = $"'{longValue}'";
            }
            else
            {
                result = $"'{guidValue}'";
            }

            return result;
        }

        private Type GetModelType(string tableName)
        {
            Type modelType = Type.GetType($"{Constant.ModelNameSpace}.{tableName}, {Constant.ModelNameSpace}");

            return modelType;
        }

        //private string GetIpAddress(HttpContext context = null)
        //{
        //    return (_httpContext.HttpContext ?? context).connection.RemoteIpAddress.ToString();
        //}
        #endregion
    }
}
