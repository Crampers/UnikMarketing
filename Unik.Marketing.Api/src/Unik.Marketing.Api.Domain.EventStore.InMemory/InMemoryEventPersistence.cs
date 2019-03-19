using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Domain.EventStore.InMemory
{
    public class InMemoryEventPersistence : IEventPersistence
    {
        private readonly Dictionary<Guid, List<IEvent>> _storage = new Dictionary<Guid, List<IEvent>>();

        public Task Persist(Guid id, IEvent @event)
        {
            return Task.Run(() =>
            {
                if (!_storage.ContainsKey(id))
                {
                    _storage.Add(id, new List<IEvent>());
                }

                _storage[id].Add(@event);
            });
        }

        public Task<IEvent[]> Load(Guid id)
        {
            return Task.FromResult(
                _storage.TryGetValue(id, out var events)
                    ? events.ToArray()
                    : null
            );
        }
    }
}