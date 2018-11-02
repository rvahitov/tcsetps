using System;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Akkatecture.Commands;
using Chessie.ErrorHandling;
using Correct.Storage.Domain.Models.BoxModel.ValueObjects;
using JetBrains.Annotations;
using MediatR;

namespace Correct.Storage.Domain.Models.BoxModel.Commands
{
    public class CreateBoxCommand : Command<BoxAggregate, BoxId>, IRequest<Result<Unit, string>>
    {
        public Barcode Barcode { get; }

        public CreateBoxCommand([NotNull] BoxId aggregateId, [NotNull] Barcode barcode) : base(aggregateId)
        {
            Barcode = barcode ?? throw new ArgumentNullException(nameof(barcode));
        }
    }

    internal class CreateBoxCommandHandler: IRequestHandler<CreateBoxCommand, Result<Unit, string>>
    {
        private readonly IActorRef _boxManager;

        public CreateBoxCommandHandler(IActorRef boxManager)
        {
            _boxManager = boxManager;
        }

        public Task<Result<Unit, string>> Handle(CreateBoxCommand command, CancellationToken cancellationToken)
        {
            return _boxManager.Ask<Result<Unit, string>>(command, cancellationToken);
        }
    }
}