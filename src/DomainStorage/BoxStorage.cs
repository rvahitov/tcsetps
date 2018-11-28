using System.Threading.Tasks;
using Akkatecture.Aggregates;
using Akkatecture.Subscribers;
using Correct.Storage.DataAccessLayer;
using Correct.Storage.DataAccessLayer.Entities;
using Correct.Storage.Domain.Models.BoxModel;
using Correct.Storage.Domain.Models.BoxModel.Events;
using Microsoft.EntityFrameworkCore;

namespace Correct.Storage.DomainStorage
{
    public class BoxStorage : DomainEventSubscriber,
        ISubscribeToAsync<BoxAggregate, BoxId, BoxCreatedEvent>
    {
        private readonly DbContextOptions _dbContextOptions;

        public BoxStorage(DbContextOptions dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public async Task HandleAsync(IDomainEvent<BoxAggregate, BoxId, BoxCreatedEvent> domainEvent)
        {
            var entity = new BoxEntity
            {
                AggregateId = domainEvent.AggregateIdentity.Value,
                Barcode = domainEvent.AggregateEvent.Barcode.Value,
                Created = domainEvent.Timestamp,
                Modified = domainEvent.Timestamp
            };
            using (var db = new StorageDbContext(_dbContextOptions))
            {
                await db.AddAsync(entity).ConfigureAwait(false);
                await db.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}