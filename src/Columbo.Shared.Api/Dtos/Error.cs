using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Columbo.Shared.Api.Dtos
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public string ExceptionName { get; set; }

        [DataMember]
        public string Message { get; set; }

        public Error(string exceptionName, string message)
        {
            ExceptionName = exceptionName;
            Message = message;
        }
    }
}
