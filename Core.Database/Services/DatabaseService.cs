﻿using Core.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Database
{
    public class DatabaseService : IDatabaseService
    {
        private static readonly HttpContext _httpContext;

        public Task<ServiceResponse> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> DeleteBatch()
        {
            throw new NotImplementedException();
        }

        public string GenerateDeleteById<T>(T model = null) where T : BaseModel
        {
            throw new NotImplementedException();
        }

        public string GenerateSelectById<T>(string id) where T : BaseModel
        {
            throw new NotImplementedException();
        }

        public string GenerateSelectById(string id, string tableName)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> Insert()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> InsertBatch()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> Update()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateBatch()
        {
            throw new NotImplementedException();
        }

        //#region Public Methods
        //public string GenerateSelectById<T>(string id) where T : BaseModel
        //{
        //    string sql = "";
        //    id = SecureSQLUtil.BuildSafeSqlLiteral(id);
        //    var model = Activator.CreateInstance<T>();
        //    string tableName = model.GetTableName();
        //    sql = $"SELECT {Constant.DefaultSchemaName}.{tableName}.*, {GetEditVersionColumn(tableName)} FROM {Constant.DefaultSchemaName}.{tableName} WHERE {model.GetPrimaryKeyFieldName()} = {GetWhereValue(id)}";
        //    return sql;
        //}

        //public string GenerateSelectById(string id, string tableName)
        //{
        //    string sql = "";
        //    id = SecureSQLUtil.BuildSafeSqlLiteral(id);
        //    Type modelType = GetModelType(tableName);
        //    var model = (BaseModel)Activator.CreateInstance(modelType);
        //    sql = $"SELECT {Constant.DefaultSchemaName}.{tableName}.*, {GetEditVersionColumn(tableName)} FROM {Constant.DefaultSchemaName}.{tableName} WHERE {model.GetPrimaryKeyFieldName()} = {GetWhereValue(id)}";
        //    return sql;
        //}


        //#endregion

        //#region Private Methods

        //// Generate sql for getting edit version
        //private string GetEditVersionColumn(string tableName)
        //{
        //    return $"{Constant.DefaultSchemaName}.{tableName}.xmin as edit_version";
        //}

        //private string GetWhereValue(string value)
        //{
        //    string result = String.Empty;
        //    Guid guidValue = Guid.Empty;
        //    long longValue = 0;

        //    if (Guid.TryParse(value, out guidValue)
        //    {
        //        result = $"'{guidValue}'";
        //    }
        //    else if (long.TryParse(value, out longValue)
        //    {
        //        result = $"'{longValue}'";
        //    }
        //    else
        //    {
        //        result = $"'{guidValue}'";
        //    }

        //    return result;
        //}

        //private Type GetModelType(string tableName)
        //{
        //    Type modelType = Type.GetType($"{Constant.ModelNameSpace}.{tableName}, {Constant.ModelNameSpace}");

        //    return modelType;
        //}

        ////private string GetIpAddress(HttpContext context = null)
        ////{
        ////    return (_httpContext.HttpContext ?? context).connection.RemoteIpAddress.ToString();
        ////}
        //#endregion
    }
}
