using System.Threading.Tasks;

namespace Unik.Marketing.Api.Messaging
{
    public interface IEventBus
    {
        Task Publish(IEvent @event);
    }
}
