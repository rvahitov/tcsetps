using System;
using Akkatecture.ValueObjects;
using JetBrains.Annotations;

namespace Correct.Storage.Domain.Models.BoxModel.ValueObjects
{
    public class Barcode : SingleValueObject<string>
    {
        public Barcode([NotNull] string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        }
    }
}