using Base.Models;
using BaseAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Services
{
    public interface IDatabaseService
    {
        /// <summary>
        /// generate a select by id sql query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">primary key of record</param>
        /// <returns>sql query select by id</returns>
        string GenerateSelectById<T>(string id) where T : BaseModel;

        /// <summary>
        /// generate a select by id sql query
        /// </summary>
        /// <param name="id">primary key of record</param>
        /// <param name="tableName">name of table of model</param>
        /// <returns></returns>
        string GenerateSelectById(string id, string tableName);

        /// <summary>
        /// generate a delete by id sql query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        string GenerateDeleteById<T>(T model = null) where T : BaseModel;

        Task<ServiceResponse> Insert();

        Task<ServiceResponse> InsertBatch();

        Task<ServiceResponse> Update();

        Task<ServiceResponse> UpdateBatch();

        Task<ServiceResponse> Delete();

        Task<ServiceResponse> DeleteBatch();

    }
}
