using System.Collections.Generic;
using Akkatecture.Specifications;
using Correct.Storage.Domain.Models.BoxModel.ValueObjects;

namespace Correct.Storage.Domain.Models.BoxModel.Specifications
{
    public class ChangeAddressSpecification : Specification<BoxAggregate>
    {
        private readonly Address _newAddress;

        public ChangeAddressSpecification(Address newAddress)
        {
            _newAddress = newAddress;
        }

        protected override IEnumerable<string> IsNotSatisfiedBecause(BoxAggregate account)
        {
            if (Equals(account.State.Address, _newAddress))
            {
                yield return "Короб имеет тот же адрес";
            }
        }
    }
}