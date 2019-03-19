using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Unik.Marketing.Api.Messaging
{
    public class EventBus : IEventBus
    {
        private readonly IServiceProvider _serviceProvider;

        public EventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task Publish(IEvent @event)
        {
            var type = typeof(IEventHandler<>).MakeGenericType(@event.GetType());

            IEnumerable<dynamic> handlers = _serviceProvider.GetServices(type);

            return Task.WhenAll(handlers.Select(x => (Task)x.Handle((dynamic)@event)));
        }
    }
}
