using System;
using System.Threading.Tasks;
using Unik.Marketing.Api.Caching;
using Unik.Marketing.Api.Domain.EventStore;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Domain
{
    public class Repository<TAggregate> : IRepository<TAggregate>
        where TAggregate : AggregateRoot, new()
    {
        private readonly IEventStore _eventStore;
        private readonly ICache<Guid, TAggregate> _cache;
        private readonly IEventBus _eventBus;

        public Repository(IEventStore eventStore, ICache<Guid, TAggregate> cache, IEventBus eventBus)
        {
            _eventStore = eventStore;
            _cache = cache;
            _eventBus = eventBus;
        }

        public async Task Save(TAggregate aggregate)
        {
            var events = aggregate.FlushUncommittedChanges();

            await _eventStore.Save(aggregate.Id, events);
            await _cache.Set(aggregate.Id, aggregate);

            foreach (var @event in events)
            {
                // TODO: Clarify whether published events should be ordered
                await _eventBus.Publish(@event);
            }
        }

        public Task<TAggregate> Get(Guid id)
        {
            return _cache.Get(id, GetFromEventStore);
        }

        private async Task<TAggregate> GetFromEventStore(Guid id)
        {
            var history = await _eventStore.GetHistory(id);
            var aggregate = new TAggregate();

            aggregate.LoadsFromHistory(history);

            return aggregate;
        }
    }
}