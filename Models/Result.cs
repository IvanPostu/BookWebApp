using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Result
    {
        public Result(bool hasError, int errorCode, string errorMessage)
        {
            HasError = hasError;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        [DataMember(Order = 1)]
        public bool HasError { get; set; }

        [DataMember(Order = 2)]
        public int ErrorCode { get; set; }

        [DataMember(Order = 3)]
        public String ErrorMessage { get; set; }
    }
}
