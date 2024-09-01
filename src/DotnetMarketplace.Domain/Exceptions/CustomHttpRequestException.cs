using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotnetMarketplace.Core.Exceptions
{
    public class CustomHttpRequestException : Exception
    {
        public HttpStatusCode StatusCode;
        public CustomHttpRequestException() { }

        public CustomHttpRequestException(string msg, Exception innerException)
            :base(msg,innerException)
        {
        }

        public CustomHttpRequestException(HttpStatusCode code)
        {
            StatusCode = code;
        }
    }
}
