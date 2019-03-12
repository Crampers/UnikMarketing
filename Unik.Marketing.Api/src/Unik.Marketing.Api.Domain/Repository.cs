using System;
using System.Threading.Tasks;
using Unik.Marketing.Api.Caching;
using Unik.Marketing.Api.Domain.EventStore;

namespace Unik.Marketing.Api.Domain
{
    public class Repository<TAggregate> : IRepository<TAggregate>
        where TAggregate : AggregateRoot, new()
    {
        private readonly IEventStore _eventStore;
        private readonly ICache<Guid, TAggregate> _cache;

        public Repository(IEventStore eventStore, ICache<Guid, TAggregate> cache)
        {
            _eventStore = eventStore;
            _cache = cache;
        }

        public Task Save(TAggregate aggregate)
        {
            return _eventStore.Save(aggregate.Id, aggregate.FlushUncommittedChanges());
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