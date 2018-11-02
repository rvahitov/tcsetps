using System.Collections.Generic;
using Akkatecture.Specifications;
using Correct.Storage.Domain.Models.BoxModel.ValueObjects;
using JetBrains.Annotations;

namespace Correct.Storage.Domain.Models.BoxModel.Specifications
{
    public class CreateBoxSpecification : Specification<BoxAggregate>
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly Barcode _barcode;

        public CreateBoxSpecification([NotNull] Barcode barcode)
        {
            _barcode = barcode;
        }

        protected override IEnumerable<string> IsNotSatisfiedBecause(BoxAggregate account)
        {
            //TODO: Add barcode validation here
            yield break;
        }
    }
}