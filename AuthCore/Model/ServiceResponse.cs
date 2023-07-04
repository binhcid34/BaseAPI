using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCore.Enums;
using WebCore.Shared.Constants;

namespace WebCore.Model
{
    public class ServiceResponse
    {
        public int Code { get; set; } = 0;
        public dynamic? Data { get; set; }
        public string ErrorMessage { get; set; }
        public bool GetLastData { get; set; } = true;
        public string OtherMessage { get; set; }
        public DateTime ServerTime { get; set; } = DateTime.Now;
        public int SubCode { get; set; } = 0;
        public bool Success { get; set; } = true;
        public string SystemMessage { get; set; }
        public string UserMessage { get; set; }

        public ServiceResponse()
        {
        }
        public ServiceResponse(object? data)
        {
            this.Data = data;
        }
        public  ServiceResponse OnSuccess(object? data)
        {
            this.Data = data;
            return this;
        }
        public ServiceResponse OnError(object? data, string message = MessageString.DEFAULT_ERROR_MESSAGE)
        {
            this.Code = (int)CodeResponse.Error;
            this.Success = false;
            this.Data = data;
            this.ErrorMessage = message;
            this.UserMessage = MessageString.DEFAULT_ERROR_USER_MESSAGE;
            return this;
        }
        public ServiceResponse OnException(string message = MessageString.DEFAULT_ERROR_MESSAGE)
        {
            this.Code = (int)CodeResponse.Exception;
            this.Success = false;
            this.ErrorMessage = message;
            this.UserMessage = MessageString.DEFAULT_ERROR_USER_MESSAGE;
            return this;
        }


    }
}
