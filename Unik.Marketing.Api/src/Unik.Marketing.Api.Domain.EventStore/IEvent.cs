namespace Unik.Marketing.Api.Domain.EventStore
{
    public interface IEvent
    {
        int Version { get; set; }
    }
}