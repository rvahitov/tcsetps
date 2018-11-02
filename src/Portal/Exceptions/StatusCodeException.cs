using System;
using System.Net;

namespace Correct.Storage.Portal.Exceptions
{
    public class StatusCodeException : Exception
    {
        public StatusCodeException(HttpStatusCode statusCode, string reasonPhrase)
            : base($"Status code: {statusCode:G}; Reason: {reasonPhrase}")
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
        }

        public HttpStatusCode StatusCode { get; }
        public string ReasonPhrase { get; }
    }
}