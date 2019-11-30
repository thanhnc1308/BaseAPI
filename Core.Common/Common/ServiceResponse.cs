using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Model
{
    public class ServiceResponse
    {
        public bool Success { get; set; } = true;
        public ServiceResponseCode Code { get; set; } = ServiceResponseCode.Success;
        public int SubCode { get; set; }
        public string UserMessage { get; set; }
        public string SystemMessage { get; set; }
        public object Data { get; set; }
        public DateTime ServerTime { get; set; } = DateTime.Now;

        #region Method
        public override string ToString()
        {
            if (Success)
            {
                return $"Success";
            }
            else
            {
                return $"Failed - code {Code} - {SubCode} - UserMessage - {UserMessage}";
            }
        }

        public ServiceResponse OnSuccess(object data = null)
        {
            this.Data = data;
            return this;
        }

        public ServiceResponse OnForbidden(object data = null)
        {
            this.Success = false;
            this.Code = ServiceResponseCode.Forbidden;
            this.SystemMessage = "Forbidden";
            this.UserMessage = "Forbidden";
            this.Data = data;
            return this;
        }

        public ServiceResponse OnException(Exception ex)
        {
            if (ex != null)
            {
                this.Success = false;
                this.Code = ServiceResponseCode.Exception;
                this.SystemMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    this.SystemMessage += Environment.NewLine + ex.InnerException.Message;
                }
            }
            return this;
        }

        public ServiceResponse OnError(ServiceResponseCode code, int subCode = 0, object data = null, string userMessage = "An error occurs when processing request", string systemMessage = "An error occurs when processing request")
        {
            this.Success = false;
            this.Code = code;
            this.SubCode = subCode;
            this.UserMessage = userMessage;
            this.SystemMessage = systemMessage;

            if (string.IsNullOrEmpty(systemMessage))
            {
                this.SystemMessage = code + "";
            }
            return this;
        }
        #endregion
    }
}
