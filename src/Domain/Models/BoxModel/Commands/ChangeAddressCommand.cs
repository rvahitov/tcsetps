using Akkatecture.Commands;
using Correct.Storage.Domain.Models.BoxModel.ValueObjects;
using JetBrains.Annotations;

namespace Correct.Storage.Domain.Models.BoxModel.Commands
{
    public class ChangeAddressCommand : Command<BoxAggregate, BoxId>
    {
        [CanBeNull] public Address NewAddress { get; }

        public ChangeAddressCommand(BoxId aggregateId, [CanBeNull] Address newAddress) : base(aggregateId)
        {
            NewAddress = newAddress;
        }
    }
}