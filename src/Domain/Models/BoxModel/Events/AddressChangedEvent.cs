using System;
using Akkatecture.Aggregates;
using Correct.Storage.Domain.Models.BoxModel.ValueObjects;
using JetBrains.Annotations;

namespace Correct.Storage.Domain.Models.BoxModel.Events
{
    public class AddressChangedEvent : AggregateEvent<BoxAggregate, BoxId>
    {
        public AddressChangedEvent([CanBeNull] Address newAddress)
        {
            NewAddress = newAddress;
        }

        [CanBeNull] public Address NewAddress { get; }
    }
}