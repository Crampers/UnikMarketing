using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Domain.EventStore
{
    public interface IEventPersistence
    {
        Task Persist(Guid id, IEvent @event);

        Task<IEvent[]> Load(Guid id);
    }
}