using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Messaging
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<IEventHandler<IEvent>>> _subscribers = new Dictionary<Type, List<IEventHandler<IEvent>>>();

        public void Subscribe(Type eventType, IEventHandler<IEvent> eventHandler)
        {
            if (!_subscribers.ContainsKey(eventType))
            {
                _subscribers.Add(eventType, new List<IEventHandler<IEvent>>());
            }

            _subscribers[eventType].Add(eventHandler);
        }

        public Task Publish(IEvent @event)
        {
            if (_subscribers.TryGetValue(@event.GetType(), out var subscribers))
            {
                return Task.WhenAll(subscribers.Select(x => x.Handle(@event)));
            }

            return Task.FromResult(0);
        }
    }
}
