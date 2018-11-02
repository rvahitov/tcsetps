using System.Threading;
using System.Threading.Tasks;
using Correct.Storage.Application.Requests;
using Correct.Storage.Portal.Exceptions;
using MediatR;
using RestSharp;

namespace Correct.Storage.Portal.Handlers
{
    public class CreateBoxRequestHandler : IRequestHandler<CreateBoxRequest, CreateBoxRequest.Response>
    {
        private readonly IRestClient _restClient;

        public CreateBoxRequestHandler(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<CreateBoxRequest.Response> Handle(CreateBoxRequest request,
            CancellationToken cancellationToken)
        {
            var restRequest = new RestRequest("api/box", Method.POST);
            restRequest.AddJsonBody(request);
            var response = await _restClient
                .ExecuteTaskAsync<CreateBoxRequest.Response>(restRequest, cancellationToken)
                .ConfigureAwait(false);
            if (response.IsSuccessful)
            {
                return response.Data;
            }

            if (response.ErrorException != null) throw response.ErrorException;
            throw new StatusCodeException(response.StatusCode, response.StatusDescription);
        }
    }
}