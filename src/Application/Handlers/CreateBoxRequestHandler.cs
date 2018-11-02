using System.Threading;
using System.Threading.Tasks;
using Chessie.ErrorHandling.CSharp;
using Correct.Storage.Application.Requests;
using Correct.Storage.Domain.Models.BoxModel;
using Correct.Storage.Domain.Models.BoxModel.Commands;
using Correct.Storage.Domain.Models.BoxModel.ValueObjects;
using MediatR;

namespace Correct.Storage.Application.Handlers
{
    public class CreateBoxRequestHandler : IRequestHandler<CreateBoxRequest, CreateBoxRequest.Response>
    {
        private readonly IMediator _mediator;

        public CreateBoxRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CreateBoxRequest.Response> Handle(CreateBoxRequest request,
            CancellationToken cancellationToken)
        {
            var boxId = BoxId.ForBarcode(request.Barcode);
            var command = new CreateBoxCommand(boxId, new Barcode(request.Barcode));
            var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
            if (result.IsOk)
            {
                return new CreateBoxRequest.Response(true, null, boxId.Value);
            }

            var failureMessage = string.Join("\r\n", result.FailedWith());
            return new CreateBoxRequest.Response(false, failureMessage, null);
        }
    }
}