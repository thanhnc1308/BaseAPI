using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Model;
using BaseAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Base.Core.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TContext> : ControllerBase
    {
        private readonly ILogger<BaseController<TModel, TContext>> _log;
        private readonly IDatabaseService _db;

        // get all data
        [HttpGet]
        public virtual async Task<ServiceResponse> GetAll()
        {
            ServiceResponse res = new ServiceResponse();
            try
            {
                List<TModel> data = default(List<TModel>);

                // get data

                //using (var db = _db.GetContext<TModel>())
                //{
                //    data = await db.Set<TModel>().Where(_ => _.id = 1).Take(Constants.MaxReturnRecord).AsNoTracking().ToListAsync();
                //}

                if (data?.Count < 0)
                {
                    res.OnError(Core.ServiceResponseCode.NotFound);
                }
                else
                {
                    res.OnSuccess(data);
                }
            }
            catch (Exception ex)
            {
                res.OnException(ex);
                _log.LogError(ex, ex.Message);
            }

            return res;
        }

        [HttpGet("paging/{pageNumber}/{pageSize}")]
        public virtual async Task<ServiceResponse> GetPaging(int pageNumber, int pageSize)
        {
            ServiceResponse res = new ServiceResponse();

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
                    res.OnError(Core.ServiceResponseCode.NotFound);
                }
                else
                {
                    PagingResponse page = new PagingResponse(data, total);
                    res.OnSuccess(page);
                }
            }
            catch (Exception ex)
            {
                res.OnException(ex);
                _log.LogError(ex, ex.Message);
            }

            return res;
        }

        [HttpGet("{id}")]
        public virtual async Task<ServiceResponse> GetById(string id)
        {
            ServiceResponse res = new ServiceResponse();

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return res.OnError(Core.ServiceResponseCode.InvalidData);
                }

                var data = 1; // await _db.GetById<TModel>()

                if (data == null)
                {
                    res.OnError(Core.ServiceResponseCode.NotFound);
                }
                else
                {
                    res.OnSuccess(data);
                }
            }
            catch (Exception ex)
            {
                res.OnException(ex);
                _log.LogError(ex, ex.Message);
            }

            return res;
        }
    }
}