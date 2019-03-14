using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unik.Marketing.Api.Messaging;

namespace Unik.Marketing.Api.Domain.EventStore
{
    public interface IEventStore
    {
        Task Save(Guid id, IEnumerable<IEvent> events);

        Task<IEvent[]> GetHistory(Guid id);
    }
}