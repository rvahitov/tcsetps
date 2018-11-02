using JetBrains.Annotations;

namespace Correct.Storage.Application.Requests
{
    public abstract class RequestResponse<TResponse> where TResponse: RequestResponse<TResponse>
    {
        public bool IsSuccess { get; }
        [CanBeNull] public string FailureMessage { get; }

        protected RequestResponse(bool isSuccess, string failureMessage)
        {
            IsSuccess = isSuccess;
            FailureMessage = failureMessage;
        }
    }
}