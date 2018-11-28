using Akka.Actor;
using Akkatecture.Aggregates;
using Akkatecture.Extensions;
using Akkatecture.Specifications.Provided;
using Correct.Storage.Domain.Extensions;
using Correct.Storage.Domain.Models.BoxModel.Commands;
using Correct.Storage.Domain.Models.BoxModel.Events;
using Correct.Storage.Domain.Models.BoxModel.Specifications;
using Correct.Storage.Domain.Models.BoxModel.ValueObjects;
using JetBrains.Annotations;
using Serilog;
using Address = Correct.Storage.Domain.Models.BoxModel.ValueObjects.Address;

namespace Correct.Storage.Domain.Models.BoxModel
{
    [UsedImplicitly]
    public class BoxAggregate
        : AggregateRoot<BoxAggregate, BoxId, BoxState>
    {
        private readonly ILogger _logger;

        public BoxAggregate(BoxId id) : base(id)
        {
            _logger = Serilog.Log.ForContext<BoxAggregate>();
            Command<CreateBoxCommand>(CreateBox);
            Command<ChangeAddressCommand>(ChangeAddress);
        }

        private bool ChangeAddress(ChangeAddressCommand cmd)
        {
            _logger.LogHandlingCommand(cmd);
            var spec = new AggregateIsNewSpecification()
                .Not().And(new ChangeAddressSpecification(cmd.NewAddress));

            var specResult = spec.AsChessieResult(this);
            if (specResult.IsOk)
            {
                Emit(new AddressChangedEvent(cmd.NewAddress));
            }

            Sender.Tell(specResult);
            _logger.LogHandlingCommandResult(cmd, specResult);
            return true;
        }

        private bool CreateBox(CreateBoxCommand cmd)
        {
            _logger.LogHandlingCommand(cmd);
            var spec = new AggregateIsNewSpecification()
                .And(new CreateBoxSpecification(cmd.Barcode));
            var specResult = spec.AsChessieResult(this);
            if (specResult.IsOk) Emit(new BoxCreatedEvent(cmd.Barcode));
            Sender.Tell(specResult);
            _logger.LogHandlingCommandResult(cmd, specResult);
            return true;
        }
    }

    [UsedImplicitly]
    public class BoxState : AggregateState<BoxAggregate, BoxId>,
        IEmit<BoxCreatedEvent>
    {
        public Barcode Barcode { get; private set; }
        public Address Address { get; private set; }

        public void Apply(BoxCreatedEvent aggregateEvent)
        {
            Barcode = aggregateEvent.Barcode;
        }
    }
}