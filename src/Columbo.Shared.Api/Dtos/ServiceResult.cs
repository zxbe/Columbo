using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Columbo.Shared.Api.Dtos
{
    [DataContract]
    public class ServiceResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }
        [DataMember]
        public Error Error { get; set; }

        protected ServiceResult(bool isSuccess, Error error = null)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static ServiceResult Ok()
        {
            return new ServiceResult(true);
        }

        public static ServiceResult Fault(string exceptionName, string errorMessage)
        {
            return new ServiceResult(false, new Error(exceptionName, errorMessage));
        }

        public static ServiceResult Fault(Exception exception)
        {
            return new ServiceResult(false, new Error(exception.GetType().ToString(), exception.Message));
        }
    }
}
