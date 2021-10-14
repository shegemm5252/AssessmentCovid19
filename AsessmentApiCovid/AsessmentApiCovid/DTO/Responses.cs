using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.DTO
{
    public class Responses<T>
    {
        public string ResponseCode { get; set; }

        public string ResponseStatus { get; set; }

        public string ResponseMessage { get; set; }

        public T Detail { get; set; }

        public static Responses<T> GetResponses(string _responseCode, string _responseStatus, string _responseMessage, T _detail)
        {
            return new Responses<T>()
            {
                ResponseCode = _responseCode,
                ResponseStatus = _responseStatus,
                ResponseMessage = _responseMessage,
                Detail = _detail
            };
        }
    }
}
