using System;
using Akkatecture.Aggregates;
using Correct.Storage.Domain.Models.BoxModel.ValueObjects;
using JetBrains.Annotations;

namespace Correct.Storage.Domain.Models.BoxModel.Events
{
    public class BoxCreatedEvent : AggregateEvent<BoxAggregate, BoxId>
    {
        public Barcode Barcode { get; }

        public BoxCreatedEvent([NotNull] Barcode barcode)
        {
            Barcode = barcode ?? throw new ArgumentNullException(nameof(barcode));
        }
    }
}