using JetBrains.Annotations;
using MediatR;

namespace Correct.Storage.Application.Requests
{
    public class CreateBoxRequest : IRequest<CreateBoxRequest.Response>
    {
        public string Barcode { get; set; }

        public class Response : RequestResponse<Response>
        {
            public Response(bool isSuccess, string failureMessage, string boxId) : base(isSuccess, failureMessage)
            {
                BoxId = boxId;
            }

            /// <summary>
            ///     Domain id
            /// </summary>
            [CanBeNull]
            public string BoxId { get; }
        }
    }
}