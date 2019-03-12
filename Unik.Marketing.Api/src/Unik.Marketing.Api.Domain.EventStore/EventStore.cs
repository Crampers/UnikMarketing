using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.EventStore
{
    public class EventStore : IEventStore
    {
        private readonly IEventPersistence _persistence;

        public EventStore(IEventPersistence persistence)
        {
            _persistence = persistence;
        }

        public Task Save(Guid id, IEnumerable<IEvent> events)
        {
            return Task.WhenAll(events.Select(@event => _persistence.Persist(id, @event)));
        }

        public Task<IEvent[]> GetHistory(Guid id)
        {
            return _persistence.Load(id);
        }
    }
}
