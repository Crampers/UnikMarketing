using System.Threading.Tasks;

namespace Unik.Marketing.Api.Messaging
{
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}
