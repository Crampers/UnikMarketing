using System;
using System.Threading.Tasks;
using Unik.Marketing.Api.Business.EventStore;

namespace Unik.Marketing.Api.Business.Domain
{
    public class Repository<TAggregate> : IRepository<TAggregate> 
        where TAggregate : AggregateRoot, new()
    {
        private readonly IEventStore _eventStore;

        public Repository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Task Save(TAggregate aggregate)
        {
            return _eventStore.Save(aggregate.Id, aggregate.FlushUncommittedChanges());
        }

        public async Task<TAggregate> Get(Guid id)
        {
            var history = await _eventStore.GetHistory(id);
            var aggregate = new TAggregate();

            aggregate.LoadsFromHistory(history);

            return aggregate;
        }
    }
}