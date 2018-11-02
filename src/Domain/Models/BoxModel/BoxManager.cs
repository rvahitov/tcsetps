using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Correct.Storage.Domain.Models.BoxModel
{
    public class BoxManager
        : AggregateManager<BoxAggregate, BoxId, Command<BoxAggregate, BoxId>>
    {
    }
}