using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Database;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace Core.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TContext> : ControllerBase
        where TModel : BaseModel
        where TContext : BaseContext
    {
        private DatabaseType dbType;
        private readonly ILogger<BaseController<TModel, TContext>> _log;
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDatabaseService _db;
        private readonly IAuthService _auth;
        private string _connectionString { get; set; }
        //private IElasticClient _elasticClient;
        private readonly IEventBus _eventBus;

        public BaseController(DatabaseType dbType, ILogger<BaseController<TModel, TContext>> log, IDatabaseService db, IAuthService auth)
        {
            this.dbType = dbType;
            _log = log;
            _db = db;
            _auth = auth;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<ServiceResponse> GetAll(string filter = "", string sort = "", string customFilter = "", string columns = "", string view ="")
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                List<TModel> data = default(List<TModel>);

                // get data

                //using (var db = _db.GetContext<TModel>())
                //{
                //    data = await db.Set<TModel>().Where(_ => _.id = 1).Take(Constants.MaxReturnRecord).AsNoTracking().ToListAsync();
                //}

                /*
                 * if using var
                 */
                //var data = await _db.GetAllAsync<TModel>(filter, sort, customFilter, columns, view);
                //if (data == null)
                //{
                //    return response.OnError(ServiceResponseCode.NotFound);
                //}

                if (data?.Count < 0)
                {
                    response.OnError(ServiceResponseCode.NotFound);
                }
                else
                {
                    response.OnSuccess(data);
                }
            }
            catch (Exception e)
            {
                response.OnException(e);
                _log.LogError(e, e.Message);
            }

            return response;
        }

        [HttpGet("{id}")]
        public virtual async Task<ServiceResponse> GetByIdAsync(string id)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return response.OnError(ServiceResponseCode.InvalidData);
                }

                var data = _db.GetByIdAsync<TModel>(dbType, id);

                if (data == null)
                {
                    return response.OnError(ServiceResponseCode.NotFound);
                }
                else
                {
                    return response.OnSuccess(data);
                }
            }
            catch (Exception e)
            {
                response.OnException(e);
                _log.LogError(e, e.Message);
            }
            return response;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("paging/{pageNumber}/{pageSize}")]
        public virtual async Task<ServiceResponse> GetPaging(int pageNumber, int pageSize)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                int total = 0;
                List<TModel> data = default(List<TModel>);

                if (pageSize > 100) // Constants.MaxReturnRecord
                {
                    pageSize = 100;
                }

                if (pageNumber < 0)
                {
                    pageNumber = 1;
                }

                //using (var db = _db)
                //{
                //    data = await db.Set<TModel>().Where().Skip(pageSize * (pageNumber - 1)).Take(pageSize).AsNotTracking().ToListAsync();
                //    total = db.Set<TModel>().Count();
                //}

                if (data?.Count <= 0)
                {
                    response.OnError(ServiceResponseCode.NotFound);
                }
                else
                {
                    PagingResponse page = new PagingResponse(data, total);
                    response.OnSuccess(page);
                }
            }
            catch (Exception e)
            {
                response.OnException(e);
                _log.LogError(e, e.Message);
            }

            return response;
        }

        [HttpPost]
        public virtual async Task<ServiceResponse> Insert(TModel request)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                if (request == null)
                {
                    response.OnError(ServiceResponseCode.InvalidData);
                }

                response = await ValidateOnInsert(request);
                if (!response.Success)
                {
                    return response;
                }

                await OnBeforeInsert(request);
                response = await _db.Insert<TModel>(dbType, request);
                if (!response.Success)
                {
                    return response;
                }

                await OnAfterInsert(request, response);

                // Do something common here
                InsertAuditingLog(request);

            }
            catch (Exception e)
            {
                response.OnException(e);
                _log.LogError(e, e.Message);
            }
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public virtual async Task<ServiceResponse> DeleteById(TModel model)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                bool success = true;

                //model.userId = _auth.GetUserId();
                //using ()
                //{
                //    // FindAsync deleteModel = ?
                //    // if deletedModel = null --> res.NotFound
                //    // if deletedModel.EditVersion != model.EditVersion --> ObsoleteVersion
                //    // ValidateOnDelete
                //    // await Delete()
                //    // OnAfterDeleted // event after delete
                //}

                if (!success)
                {
                    response.OnError(ServiceResponseCode.Error);
                }
            }
            catch (Exception e)
            {
                response.OnException(e);
                _log.LogError(e, e.Message);
            }

            return response;
        }

        #region Protected Methods
        protected virtual async Task<ServiceResponse> ValidateOnInsert(object request)
        {
            ServiceResponse response = new ServiceResponse();
            return response;
        }

        protected virtual async Task<ServiceResponse> ValidateOnUpdate(object request)
        {
            ServiceResponse response = new ServiceResponse();
            return response;
        }

        protected virtual async Task<ServiceResponse> ValidateOnDelete(object request)
        {
            ServiceResponse response = new ServiceResponse();
            return response;
        }

        protected virtual async Task OnBeforeInsert(TModel model, TContext context)
        {
        }

        protected virtual async Task OnAfterInsert(TModel model, TContext context)
        {
        }
        protected virtual async Task OnCustomActionInsert(TModel model, TContext context)
        {
        }
        #endregion

        #region Private Methods
        private void InsertAuditingLog(TModel request)
        {

        }
        #endregion
    }
}