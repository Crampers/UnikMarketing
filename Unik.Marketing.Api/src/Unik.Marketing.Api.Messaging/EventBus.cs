using System.Threading.Tasks;

namespace Unik.Marketing.Api.Messaging
{
    public class EventBus : IEventBus
    {
        public Task Publish(IEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}
